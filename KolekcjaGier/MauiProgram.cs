using Microsoft.Extensions.Logging;
using KolekcjaGier.ViewModels; // <--- TO MUSI BYĆ TUTAJ, NA GÓRZE!

namespace KolekcjaGier;

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

        // Rejestracja w kontenerze zależności (zostaje tutaj)
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<GryViewModel>();

        builder.Services.AddTransient<SzczegolyPage>();
        builder.Services.AddTransient<SzczegolyViewModel>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}