using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pokedex.Model;
using Pokedex.ViewModel;

namespace Pokedex.View;

public partial class DetailsPage : ContentPage
{
    private readonly PokemonDetailsViewModel _viewModel;
    
    public DetailsPage(PokemonDetailsViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }
    
    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
    
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.GetPokemonAsync(_viewModel.Pokemon.Name);
    }
    
}