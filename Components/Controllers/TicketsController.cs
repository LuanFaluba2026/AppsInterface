using AppsInterface.Components.Models;
using AppsInterface.Components.Models.Enum.Ticket;

namespace AppsInterface.Components.Controllers;
public class TicketsController
{
    static List<Ticket> tickets = new List<Ticket>()
    {
    };
    public static List<Ticket> GetTicketsByAppId(Guid id)
    {
        var ticketsReturn = tickets.Where(x => x.AppId == id).ToList();
        return ticketsReturn;
    }
}