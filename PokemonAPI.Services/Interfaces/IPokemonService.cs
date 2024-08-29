using PokemonAPI.Entities.Dtos;

namespace PokemonAPI.BL.Interfaces
{
    public interface IPokemonService
    {
        public Task<PokemonDto> GetPokemonByNameAsync(string name, bool toTranslate = false);
    }
}
