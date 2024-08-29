using AutoMapper;
using PokemonAPI.BL.Interfaces;
using PokemonAPI.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonAPI.BL.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IPokeApiService _pokeApiService;
        private readonly IFunTranslationService _funTranslationService;
        private IMapper _mapper;
        public PokemonService(IPokeApiService pokeApiService, 
            IFunTranslationService funTranslationService,
            IMapper mapper)
        {
            _pokeApiService = pokeApiService;
            _funTranslationService = funTranslationService;
            _mapper = mapper;
        }
        public async Task<PokemonDto> GetPokemonByNameAsync(string name, bool toTranslate = false)
        {
            var pokeApiDto = await _pokeApiService.GetPokemonByNameAsync(name);
            var pokemonDto = _mapper.Map<PokemonDto>(pokeApiDto); 
            return toTranslate ? await _funTranslationService.GetTranslatedPokemonAsync(pokemonDto) : pokemonDto;
        }

    }
}
