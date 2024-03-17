using AutoMapper;
using CLOUPARD.BLL.Models;
using CLOUPARD.DAL.Entities;
using CLOUPARD.Domain.DTO;

namespace CLOUPARD.Api;

public class AppMappingProfile : Profile
{
    public AppMappingProfile()
    {
        CreateMap<Product, ProductModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(x => x.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(x => x.Description))
            .ReverseMap();

        CreateMap<ProductDTO, Product>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(x => x.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(x => x.Description))
            .ReverseMap();

        CreateMap<ProductDTO, ProductModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(x => x.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(x => x.Description))
            .ReverseMap();
    }
}
