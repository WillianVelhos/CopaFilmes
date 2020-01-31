using AutoMapper;
using CopaFilmes.Domain.Model;
using CopaFilmes.WebApi.Messages.Campeonato.Request;

namespace CopaFilmes.WebApi.AutoMapper
{
    public class DtoToEntityMappingProfile : Profile
    {
        public DtoToEntityMappingProfile()
        {
            CreateMap<FilmeDto, Filme>()
               .ConstructUsing(c => new Filme(c.Id, c.Titulo, c.Ano, c.Nota));
        }
    }
}
