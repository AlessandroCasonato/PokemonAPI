using PokemonAPI.Entities.Dtos;

namespace PokemonAPI.BL.Interfaces
{
    public interface IFunTranslationService
    {
        public Task<PokemonDto> GetTranslatedPokemonAsync(PokemonDto pokemon);

    }
}
