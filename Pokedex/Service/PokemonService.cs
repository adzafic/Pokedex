using System.Net.Http.Json;
using Pokedex.Model;
using Pokedex.ViewModel;

namespace Pokedex.Service;

public class PokemonService
{
    private readonly HttpClient _httpClient;
    PokemonListResponse _pokemonListResponse = new ();
    List<Pokemon> _pokemons = new List<Pokemon>();
    PokemonDetails _pokemon = new();

    public PokemonService()
    {
        _httpClient = new HttpClient();
    }
    public async Task<List<Pokemon>> GetAllPokemonsAsync()
    {
        if (_pokemons?.Count > 0)
        {
            return _pokemons;
        }

        var url = "https://pokeapi.co/api/v2/pokemon?limit=150&offset=0";
        var response = await _httpClient.GetAsync(url);
        
        if (response.IsSuccessStatusCode)
        {
            _pokemonListResponse = await response.Content.ReadFromJsonAsync<PokemonListResponse>();
            _pokemons = _pokemonListResponse.Results;

        }
        return _pokemons;
    }

    public async Task<PokemonDetails> GetPokemonAsync(string id)
    {
        var url = $"https://pokeapi.co/api/v2/pokemon/{id}";
        var response = await _httpClient.GetAsync(url);
        
        if (response.IsSuccessStatusCode)
        {
            _pokemon = await response.Content.ReadFromJsonAsync<PokemonDetails>();

        }
        return _pokemon;
        
    }
}