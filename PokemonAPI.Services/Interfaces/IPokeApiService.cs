using PokemonAPI.Entities.Dtos;

namespace PokemonAPI.BL.Interfaces
{
    public interface IPokeApiService
    {
        public Task<PokeApiDto?> GetPokemonByNameAsync(string name);
    }
}
