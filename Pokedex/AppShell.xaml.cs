using Pokedex.View;

namespace Pokedex;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        
        Routing.RegisterRoute(nameof(DetailsPage), typeof(DetailsPage));
    }
}