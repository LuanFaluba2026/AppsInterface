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
            Name = "Conversor DES",
            Description = "Aplicativo que automatiza processos de escrituração da DES de Belo Horizonte, possibilitando o registro de notas fiscais do Portal Nacional e de São Paulo.",
            DownloadPath = "DownloadApps/Conversor DES.rar",
            Type = AppType.Fiscal
        },
        new()
        {
            Name = "Conciliador Contábil",
            Description = "Aplicativo de automação que analisa o razão contábil e gera uma planilha completa de conciliação, agilizando a conferência, identificação de inconsistências e validação das informações contábeis.",
            DownloadPath = "DownloadApps/Conciliador Contábil.rar",
            Type = AppType.Contabil
        },
    };
    public static List<PublishedApp> GetAvailableApps() => availableApps;
    public static PublishedApp? GetAppById(Guid Id)
    {
        PublishedApp? app = availableApps.FirstOrDefault(x => x.Id.Equals(Id));
        if(app is null) return null;
        return app;
    }
}
