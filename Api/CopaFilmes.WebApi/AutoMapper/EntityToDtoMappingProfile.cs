using AutoMapper;
using CopaFilmes.Domain.Model;
using CopaFilmes.WebApi.Messages.Campeonato.Response;

namespace CopaFilmes.WebApi.AutoMapper
{
    public class EntityToDtoMappingProfile : Profile
    {
        public EntityToDtoMappingProfile()
        {
            CreateMap<Resultado, ResultadoDto>();
            CreateMap<Filme, FilmeDto>();
            CreateMap<Filme, Messages.Filme.Response.FilmeDto>();
        }
    }
}
