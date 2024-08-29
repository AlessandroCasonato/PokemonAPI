using AutoMapper.Internal;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PokemonAPI.BL.Interfaces;
using PokemonAPI.Entities.Dtos;
using System.Net;
using System.Net.Http;

namespace PokemonAPI.BL.ExternalServices
{
    public class PokeApiService : IPokeApiService
    {
        private readonly string _baseUrl = "https://pokeapi.co/api/v2";

        public async Task<PokeApiDto?> GetPokemonByNameAsync(string name)
        {
            using (var client = new HttpClient())
            {
                string url = $"{_baseUrl}/pokemon-species/{name}";
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                var dto = JsonConvert.DeserializeObject<PokeApiDto>(responseContent);
                return dto;
            }          
        }
    }
}
