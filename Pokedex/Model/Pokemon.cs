using System.Text.RegularExpressions;

namespace Pokedex.Model;

public class PokemonListResponse
{
    public int Count { get; set; }
    public string Next { get; set; }
    public object Previous { get; set; }
    public List<Pokemon> Results { get; set; }
}

public class Pokemon
{
    public int? Id => int.Parse(Regex.Match(Url, @"\d+/$").Value.TrimEnd('/'));
    public string? Name { get; set; }
    public string? Url { get; set; }
    public string? ImageUrl => $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/{Id}.png";
}

public class PokemonDetails
{
    public Sprites sprites { get; set; }
}

public class Sprites
{
    public string Back_Default { get; set; }
    public object Back_Female { get; set; }
    public string Back_Shiny { get; set; }
    public object Back_Shiny_female { get; set; }
    public string Front_Default { get; set; }
    public object Front_Female { get; set; }
    public string Front_Shiny { get; set; }
    public object Front_Shiny_Female { get; set; }
}
