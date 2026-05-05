using AppsInterface.Components.Models.Enum.Ticket;

namespace AppsInterface.Components.Models;
public class Ticket
{
    public Guid TicketId { get; set; } = Guid.NewGuid();
    public Guid AppId { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set;}
    public required TicketPriority Priority {get; set;}
    public required TicketStatus Status { get; set; }
}