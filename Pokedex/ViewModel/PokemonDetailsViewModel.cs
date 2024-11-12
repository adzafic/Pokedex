using System.ComponentModel;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Plugin.Maui.Audio;
using Pokedex.Model;
using Pokedex.Service;

namespace Pokedex.ViewModel;
[QueryProperty("Pokemon","Pokemon")]
public partial class PokemonDetailsViewModel: BaseViewModel
{
    private readonly PokemonService _pokemonService;
    private readonly IAudioManager _audioManager;
    public PokemonDetailsViewModel( PokemonService pokemonService, IAudioManager audioManager )
    {
        _pokemonService = pokemonService;
        _audioManager = audioManager;
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
    
    [ICommand]
    public async Task PlaySound()
    {
        Console.WriteLine("Play sound");
        var httpClient = new HttpClient();
        var response = await httpClient.GetAsync("https://download.samplelib.com/mp3/sample-3s.mp3", HttpCompletionOption.ResponseHeadersRead);
        var audiostream = await response.Content.ReadAsStreamAsync();
        var audioPlayer = _audioManager.CreatePlayer(audiostream);
        audioPlayer.Play();
        Console.WriteLine(audioPlayer.ToString());
    }

}