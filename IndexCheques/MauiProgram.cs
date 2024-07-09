using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
using Infrastructure.Data;
using Infrastructure.Services;
using ApplicationCore.UseCases;
using ApplicationCore.Interfaces;
using IndexCheques.Presentation.ViewModels;
using Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace IndexCheques
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Configuración del contexto de base de datos
            var connectionString = @"Server=localhost\COMPAC;Database=adPATRONATOPROHOSPIT;User Id=sa;Password=$Index123459.;TrustServerCertificate=True;";
            builder.Services.AddDbContext<ContpaqiSQLContext>(options =>
                options.UseSqlServer(connectionString));

            // Registro de repositorios y servicios
            builder.Services.AddScoped<IDocumentRepo, DocumentRepo>();
            builder.Services.AddScoped<IDocumentService, GetDocumentListByFechaConceptoSerieService>();
            builder.Services.AddScoped<GetDocumentsByFechaConceptoSerieUseCase>();
            builder.Services.AddScoped<DocumentsViewModel>();

            // Registro de la página principal
            builder.Services.AddTransient<MainPage>();


//#if DEBUG
//            builder.Logging.AddDebug();
//#endif

            return builder.Build();
        }
    }
}
