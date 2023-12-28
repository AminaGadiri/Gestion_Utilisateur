using AutoMapper;
using Gestion_Catalogue1.DTO;
using Gestion_Catalogue1.Model;

namespace Gestion_Catalogue1.Mapping
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Catalogue, CatalogueDto>().ReverseMap();
            CreateMap<CatalogueDto, Catalogue>().ReverseMap();

            
        }
    }
}
