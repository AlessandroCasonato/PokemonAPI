using AutoMapper;
using PokemonAPI.Entities.Dtos;

namespace PokemonAPI.Entities.Mappings.Profiles
{
    public class PokemonProfile : Profile
    {
        public PokemonProfile()
        {
            CreateMap<PokeApiDto, PokemonDto>().ForMember(dest => dest.Name, src => src.MapFrom(x => x.Name))
                .ForMember(dest => dest.Habitat, src => src.MapFrom(x => x.Habitat != null ? x.Habitat.Name : string.Empty))
                .ForMember(dest => dest.IsLegendary, src => src.MapFrom(x => x.IsLegendary))
                .ForMember(dest => dest.Description, src => src.MapFrom(x => x.FlavorTextEntries!.First
                    (x => x.Language!.Name == "en").FlavorText));
        }
    }
}
