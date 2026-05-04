using System;
using AppsInterface.Components.Models;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace AppsInterface.Components.Controllers;

public class AppsController
{
    static List<PublishedApp> availableApps = new()
    {
        new()
        {
            Name = "Conversor DES",
            Description = "Um app que ajuda na escrituração da DES de Belo Horizonte",
            DownloadPath = "//",
            Type = AppType.Fiscal
        },
        new()
        {
            Name = "Ordenador PDF",
            Description = "Um app que deixa você organizar seus PDFS de acordo com alguns campos",
            DownloadPath = "//",
            Type = AppType.Automatizador
        },
        new()
        {
            Name = "Cemig Converter",
            Description = "Um app que lê os QR codes das notas da CEMIG e criam um arquivo importador do Domínio.",
            DownloadPath = "//",
            Type = AppType.Fiscal
        },
        new()
        {
            Name = "Planilha Portal Nacional",
            Description = "Um appp doiiidimais doiiido",
            DownloadPath = "//",
            Type = AppType.Automatizador
        }
    };
    public static List<PublishedApp> GetAvailableApps() => availableApps;
    public static PublishedApp GetAppById(Guid Id)
    {
        PublishedApp? app = availableApps.FirstOrDefault(x => x.Id.Equals(Id));
        if(app is null) throw new ArgumentNullException("Id inexistente.");
        return app;
    }
}
