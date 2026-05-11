using System.Security.Claims;
using AppsInterface.Components;
using AppsInterface.Components.Services;
using AppsInterface.Database;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContextFactory<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHostedService<UploadCleanupService>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<PasswordService>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = "/login";
});
builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

using (var scope = app.Services.CreateScope())
{
    var dbFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<AppDbContext>>();
    var passwordService = scope.ServiceProvider.GetRequiredService<PasswordService>();

    await using var db = await dbFactory.CreateDbContextAsync();

    if (!await db.Users.AnyAsync(u => u.IsAdmin))
    {
        var admin = new AppsInterface.Components.Models.User
        {
            Nome = "Administrador",
            Login = "admin",
            IsAdmin = true
        };

        admin.PasswordHash = passwordService.Hash(admin, "cgcadministrator30364400");

        db.Users.Add(admin);
        await db.SaveChangesAsync();
    }
}

app.MapPost("/auth/login", async (HttpContext context, IDbContextFactory<AppDbContext> dbFactory, PasswordService passwordService) =>
{
    var form = await context.Request.ReadFormAsync();
    var usuario = form["usuario"].ToString();
    var senha = form["senha"].ToString();
    await using var db = await dbFactory.CreateDbContextAsync();
    var user = await db.Users.FirstOrDefaultAsync(u => u.Login == usuario);
    if(user is null || !passwordService.Verify(user, senha!))
       return Results.Redirect("/login");
    
    var claims = new List<Claim>
    {
        new(ClaimTypes.Name, user.Nome),
        new(ClaimTypes.NameIdentifier, user.Id.ToString())
    };
    if(user.IsAdmin)
        claims.Add(new Claim(ClaimTypes.Role, "Admin"));
        
    var principal = new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));
    await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
    return Results.Redirect("/");
});
app.MapPost("/auth/logout", async (HttpContext context) =>
{
    await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    return Results.Redirect("/login");
});

app.Run();
