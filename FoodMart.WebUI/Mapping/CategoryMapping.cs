using AutoMapper;
using FoodMart.DtoLayer.Dtos.CategoryDtos;
using FoodMart.EntityLayer.Entities;

namespace FoodMart.WebUI.Mapping
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, GetCategoryByIdDto>().ReverseMap();
        }
    }
}
