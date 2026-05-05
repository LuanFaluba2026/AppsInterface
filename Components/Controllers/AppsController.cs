using System;
using AppsInterface.Components.Models;
using AppsInterface.Components.Models.Enum;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace AppsInterface.Components.Controllers;

    public class AppsController
{
    static List<PublishedApp> availableApps = new()
    {
        new()
        {
            Id = Guid.Parse("e4ac7258-eabf-4902-ac0d-c77d1c3393ff"),
            Name = "Conversor DES",
            Description = "Um app que ajuda na escrituração da DES de Belo Horizonte",
            DownloadPath = "//",
            Type = AppType.Fiscal
        },
        new()
        {
            Id = Guid.Parse("730530f5-64c4-400b-9192-e20b40c81226"),
            Name = "Ordenador PDF",
            Description = "Um app que deixa você organizar seus PDFS de acordo com alguns campos",
            DownloadPath = "//",
            Type = AppType.Automatizador
        },
        new()
        {
            Id = Guid.Parse("741d6cb6-2b2a-42da-a417-42df1ec3b45d"),
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
        },
        new()
        {
            Name = "Planilha Portal Nacional",
            Description = "Um appp doiiidimais doiiido",
            DownloadPath = "//",
            Type = AppType.Automatizador
        },
        new()
        {
            Name = "Planilha Portal Nacional",
            Description = "Um appp doiiidimais doiiido",
            DownloadPath = "//",
            Type = AppType.Automatizador
        },
        new()
        {
            Name = "Planilha Portal Nacional",
            Description = "Um appp doiiidimais doiiido",
            DownloadPath = "//",
            Type = AppType.Automatizador
        },
        new()
        {
            Name = "Planilha Portal Nacional",
            Description = "Um appp doiiidimais doiiido",
            DownloadPath = "//",
            Type = AppType.Automatizador
        },
        new()
        {
            Name = "Planilha Portal Nacional",
            Description = "Um appp doiiidimais doiiido",
            DownloadPath = "//",
            Type = AppType.Automatizador
        },
        new()
        {
            Name = "Planilha Portal Nacional",
            Description = "Um appp doiiidimais doiiido",
            DownloadPath = "//",
            Type = AppType.Automatizador
        },
        new()
        {
            Name = "Planilha Portal Nacional",
            Description = "Um appp doiiidimais doiiido",
            DownloadPath = "//",
            Type = AppType.Automatizador
        },
        new()
        {
            Name = "Planilha Portal Nacional",
            Description = "Um appp doiiidimais doiiido",
            DownloadPath = "//",
            Type = AppType.Automatizador
        },
        new()
        {
            Name = "Planilha Portal Nacional",
            Description = "Um appp doiiidimais doiiido",
            DownloadPath = "//",
            Type = AppType.Automatizador
        },
        new()
        {
            Name = "Planilha Portal Nacional",
            Description = "Um appp doiiidimais doiiido",
            DownloadPath = "//",
            Type = AppType.Automatizador
        },
        new()
        {
            Name = "Planilha Portal Nacional",
            Description = "Um appp doiiidimais doiiido",
            DownloadPath = "//",
            Type = AppType.Automatizador
        },
        new()
        {
            Name = "Planilha Portal Nacional",
            Description = "Um appp doiiidimais doiiido",
            DownloadPath = "//",
            Type = AppType.Automatizador
        },
        new()
        {
            Name = "Planilha Portal Nacional",
            Description = "Um appp doiiidimais doiiido",
            DownloadPath = "//",
            Type = AppType.Automatizador
        },
        new()
        {
            Name = "Planilha Portal Nacional",
            Description = "Um appp doiiidimais doiiido",
            DownloadPath = "//",
            Type = AppType.Automatizador
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
    public static PublishedApp? GetAppById(Guid Id)
    {
        PublishedApp? app = availableApps.FirstOrDefault(x => x.Id.Equals(Id));
        if(app is null) return null;
        return app;
    }
}
