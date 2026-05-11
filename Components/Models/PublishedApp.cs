using AppsInterface.Components.Models.Enum;

namespace AppsInterface.Components.Models;
public class PublishedApp
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Version {get; set; }
    public DownloadStatus Status { get; set; } = DownloadStatus.Uploading; 
    public string DownloadPath { get; set; } = "";
    public AppType Type { get; set; }
}