using AppsInterface.Components.Models;
using Microsoft.EntityFrameworkCore;

namespace AppsInterface.Database;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    public DbSet<PublishedApp> PublishedApps { get; set; }
    public DbSet<Ticket> Tickets { get; set;}
    public DbSet<User> Users { get; set; }
}