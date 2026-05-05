using AppsInterface.Components.Models;
using AppsInterface.Components.Models.Enum.Ticket;

namespace AppsInterface.Components.Controllers;
public class TicketsController
{
    static List<Ticket> tickets = new List<Ticket>()
    {
        new Ticket
        {
            AppId = Guid.Parse("e4ac7258-eabf-4902-ac0d-c77d1c3393ff"),
            Title = "NÃO FUNCIONA ESSA MERDA!!!",
            Description = "Estou a 2 anos tentando mas não vai...",
            Priority = TicketPriority.Alta,
            Status = TicketStatus.Aberto
        },
        new Ticket
        {
            AppId = Guid.Parse("e4ac7258-eabf-4902-ac0d-c77d1c3393ff"),
            Title = "asmuei",
            Description = "ablualbuabalbalbwl...",
            Priority = TicketPriority.Baixa,
            Status = TicketStatus.Aberto
        },
        new Ticket
        {
            AppId = Guid.Parse("730530f5-64c4-400b-9192-e20b40c81226"),
            Title = "as vezes no silencio da noite eu fico imagninando nos dois!!!",
            Description = "Eu fico ali sonhando acordado, o antes, o agora e o depois",
            Priority = TicketPriority.Baixa,
            Status = TicketStatus.Concluído
        },
        new Ticket
        {
            AppId = Guid.Parse("741d6cb6-2b2a-42da-a417-42df1ec3b45d"),
            Title = "Tucutá tá, tucutá",
            Description = "Mc brinquedo crente",
            Priority = TicketPriority.Alta,
            Status = TicketStatus.Aberto
        }
    };
    public static List<Ticket> GetTicketsByAppId(Guid id)
    {
        var ticketsReturn = tickets.Where(x => x.AppId == id).ToList();
        return ticketsReturn;
    }
}