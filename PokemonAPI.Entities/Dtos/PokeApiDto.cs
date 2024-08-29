using Newtonsoft.Json;

namespace PokemonAPI.Entities.Dtos
{
    public class PokeApiDto
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("flavor_text_entries")]
        public FlavorTextEntry[]? FlavorTextEntries { get; set; }

        [JsonProperty("habitat")]
        public DefaultNestedObject? Habitat { get; set; }

        [JsonProperty("is_legendary")]
        public bool IsLegendary { get; set; }

    }

    public class FlavorTextEntry
    {
        [JsonProperty("flavor_text")]
        public string? FlavorText { get; set; }

        [JsonProperty("language")]
        public DefaultNestedObject? Language { get; set; }
    }
    public class DefaultNestedObject
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("url")]
        public string? Url { get; set; }
    }
}
