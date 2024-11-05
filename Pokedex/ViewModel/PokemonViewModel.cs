using System.Collections.ObjectModel;
using System.Diagnostics;
using Microsoft.Toolkit.Mvvm.Input;
using Pokedex.Model;
using Pokedex.Service;
using Pokedex.View;

namespace Pokedex.ViewModel;

public partial class PokemonViewModel: BaseViewModel
{
    PokemonService _pokemonService;
    public ObservableCollection<Pokemon> Pokemons { get; } = new();
    public PokemonViewModel(PokemonService pokemonService)
    {
        Title = "Pokemons";
        _pokemonService = pokemonService;
    }

    [ICommand]
    async Task GetPokemonsAsync()
    {
        if (IsBusy)
        {
            return;
        }

        try
        {
            IsBusy = true;
            var pokemons = await _pokemonService.GetAllPokemonsAsync();
            if (pokemons.Count > 0)
            {
                Pokemons.Clear();
            }

            foreach (var pokemon in pokemons)
            {
                Pokemons.Add(pokemon);
            }

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            //esto se deberi pasar a una interficie
            await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }

    //refactorizar para que funcione por interficie de naavegacion
    [ICommand]
    async Task GoToDetailAsync(Pokemon pokemon)
    {
        if (pokemon is null)
        {
            return;
        }
        await Shell.Current.GoToAsync($"{nameof(DetailsPage)}",true,new Dictionary<string, object>() { { "Pokemon", pokemon } });
    }
}