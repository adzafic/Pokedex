using Microsoft.Extensions.Logging;
using Plugin.Maui.Audio;
using Pokedex.Service;
using Pokedex.View;
using Pokedex.ViewModel;

namespace Pokedex;

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

#if DEBUG
        builder.Logging.AddDebug();
#endif
        builder.AddAudio();
        builder.Services.AddSingleton<PokemonService>();
        builder.Services.AddSingleton<PokemonViewModel>();
        builder.Services.AddTransient<PokemonDetailsViewModel>();
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddTransient<DetailsPage>();
        
        return builder.Build();
    }
}