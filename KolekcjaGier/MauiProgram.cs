using Microsoft.Extensions.Logging;
using KolekcjaGier.ViewModels;
using KolekcjaGier.Services;

namespace KolekcjaGier;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        SQLitePCL.Batteries_V2.Init(); 

       
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // Rejestracja w kontenerze zależności (zostaje tutaj)
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<GryViewModel>();

        builder.Services.AddTransient<SzczegolyPage>();
        builder.Services.AddTransient<SzczegolyViewModel>();
        builder.Services.AddSingleton<GryBaza>();

        builder.Services.AddTransient<FormularzPage>();
        builder.Services.AddTransient<FormularzViewModel>();
#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}