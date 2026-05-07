using System.ComponentModel.DataAnnotations;
using AppsInterface.Components.Models.Enum.Ticket;

namespace AppsInterface.Components.Models;
public class Ticket
{
    public Guid TicketId { get; set; } = Guid.NewGuid();
    public Guid AppId { get; set; }
    [Required]
    [EmailAddress]
    public string AuthorEmail { get; set; } = "";
    public DateTime CreationTime { get; set; } = DateTime.Now;
    public string Title { get; set; } = "";
    public string Description { get; set;} = "";
    public TicketPriority Priority {get; set;}
    public TicketStatus Status { get; set; }
}