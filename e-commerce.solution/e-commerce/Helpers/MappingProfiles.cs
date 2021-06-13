using AutoMapper;
using Core.Entites;
using e_commerce.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_commerce.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(x=> x.ProductBrand, y=> y.MapFrom(s=> s.ProductBrand.Name))
                .ForMember(x=> x.ProductType, y=> y.MapFrom(s=> s.ProductType.Name))
                .ForMember(x=> x.PictureUrl, o=> o.MapFrom<ProductUrlResolver>());
        }
    }
}
