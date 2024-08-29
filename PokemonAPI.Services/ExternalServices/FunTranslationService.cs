using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PokemonAPI.BL.Interfaces;
using PokemonAPI.Entities.Dtos;

namespace PokemonAPI.BL.ExternalServices
{
    public class FunTranslationService : IFunTranslationService
    {
        private readonly string _baseUrl = "https://api.funtranslations.com/translate";
        private readonly ILogger<FunTranslationService> _logger;

        public FunTranslationService(ILogger<FunTranslationService> logger)
        {
            _logger = logger;
        }
        public async Task<PokemonDto> GetTranslatedPokemonAsync(PokemonDto pokemon)
        {
            try
            {
                if (pokemon.Habitat == "cave" || pokemon.IsLegendary)
                {
                    pokemon.Description = await GetTranslation(pokemon.Description, "yoda") ?? pokemon.Description;
                }
                else
                {
                    pokemon.Description = await GetTranslation(pokemon.Description, "shakespeare") ?? pokemon.Description;
                }
                return pokemon;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return pokemon;
            }
        }

        private async Task<string?> GetTranslation(string text, string translation)
        {
            using (var client = new HttpClient())
            {
                string url = $"{_baseUrl}/{translation}";
                var content = new FormUrlEncodedContent(
                [
                    new KeyValuePair<string, string>("text", text)
                ]);
                var response = await client.PostAsync(url, content);
                response.EnsureSuccessStatusCode();
                var responseContent = await response.Content.ReadAsStringAsync();
                var dto = JsonConvert.DeserializeObject<FunTranslationDto>(responseContent);       
                return dto.Contents?.TranslatedText;
            }
        }
    }
}
