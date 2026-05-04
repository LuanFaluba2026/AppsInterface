namespace AppsInterface.Components.Models;
public class PublishedApp
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }
    public required string Description { get; set; }
    public string? IconPath { get; set; }
    public required string DownloadPath { get; set; }
    public AppType Type { get; set; }
}