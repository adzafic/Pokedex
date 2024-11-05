using System.ComponentModel;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Pokedex.Model;
using Pokedex.Service;

namespace Pokedex.ViewModel;
[QueryProperty("Pokemon","Pokemon")]
public partial class PokemonDetailsViewModel: BaseViewModel
{
    private readonly PokemonService _pokemonService;
    public PokemonDetailsViewModel( PokemonService pokemonService)
    {
        _pokemonService = pokemonService;
    }

    [ObservableProperty] 
    Pokemon _pokemon;
    
    [ObservableProperty]
    PokemonDetails _pokemonDetails;

    public async Task GetPokemonAsync(string id)
    {
        PokemonDetails = await _pokemonService.GetPokemonAsync(id);
        Console.WriteLine(PokemonDetails.ToString());
    }

}