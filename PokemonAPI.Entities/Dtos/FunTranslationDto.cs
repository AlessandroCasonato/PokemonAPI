using Newtonsoft.Json;

namespace PokemonAPI.Entities.Dtos
{
    public class FunTranslationDto
    {
        [JsonProperty("contents")]
        public FunTranslationContent? Contents { get; set; }

    }
    public class FunTranslationContent
    {
        [JsonProperty("translated")]
        public string? TranslatedText { get; set; }

        [JsonProperty("text")]
        public string? OriginalText { get; set; }

        [JsonProperty("translation")]
        public string? TranslationType { get; set; }

    }
}
