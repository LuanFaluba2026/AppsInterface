using System.Diagnostics;
using AppsInterface.Components.Models.Enum;
using AppsInterface.Database;
using Microsoft.EntityFrameworkCore;

namespace AppsInterface.Components.Services;
public class UploadCleanupService : BackgroundService
{
    private readonly IServiceScopeFactory scopeFactory;
    public UploadCleanupService(IServiceScopeFactory scopeFactory)
    {
        this.scopeFactory = scopeFactory;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Debug.WriteLine("Excluindo arquivos incompletos");
        while(!stoppingToken.IsCancellationRequested)
        {
            using var scope = scopeFactory.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var uploadsIncompletos = await db.PublishedApps.Where(x => x.Status != DownloadStatus.Completed && x.CreatedAt < DateTime.UtcNow.AddMinutes(-30)).ToListAsync();
            foreach(var app in uploadsIncompletos)
            {
                if(File.Exists(app.DownloadPath))
                    File.Delete(app.DownloadPath);
                db.PublishedApps.Remove(app);
            }
            await db.SaveChangesAsync();
            await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
        }
    }
}