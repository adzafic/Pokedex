using Pokedex.ViewModel;

namespace Pokedex;

public partial class MainPage : ContentPage
{

    public MainPage(PokemonViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
    
}