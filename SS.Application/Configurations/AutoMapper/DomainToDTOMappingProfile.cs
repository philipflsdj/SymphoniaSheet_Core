using AutoMapper;
using SS.Application.Configurations.DTOs.Categoria;
using SS.Application.Configurations.DTOs.Partitura;
using SS.Application.Configurations.DTOs.Usuario;
using SS.Domain.Models;
using SS.Domain.SeedWorks;


namespace SS.Application.Configurations.AutoMapper
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Usuario, UsuarioDto>();

            CreateMap<Categoria, CategoriaDto>();
            CreateMap<PagedResult<Categoria>, CategoriaPagedResultDto>();

            CreateMap<Partitura, PartituraDto>();
            CreateMap<Partitura, PartituraListDto>();
            CreateMap<PartituraMaterial, PartituraMaterialDto>();
        }
    }
}
