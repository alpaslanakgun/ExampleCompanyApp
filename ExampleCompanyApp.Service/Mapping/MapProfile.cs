using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ExampleCompanyApp.Core;
using ExampleCompanyApp.Core.DTOs;
using ExampleCompanyApp.Core.Models;

namespace ExampleCompanyApp.Service.Mapping
{
    public class MapProfile:Profile
    {

        public MapProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<ProductFeature, ProductFeatureDto>().ReverseMap();
            CreateMap<ProductUpdateDto, Product>();
            CreateMap<Product, ProductWithCategoryDto>();
            CreateMap<Category, CategoryWithProductDto>();
        }

    }
}
