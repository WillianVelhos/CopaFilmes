using AutoMapper;

namespace CopaFilmes.WebApi.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DtoToEntityMappingProfile());
                cfg.AddProfile(new EntityToDtoMappingProfile());
            });
        }
    }
}
