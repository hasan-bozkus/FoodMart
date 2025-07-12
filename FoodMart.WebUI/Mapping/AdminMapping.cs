using AutoMapper;
using FoodMart.DtoLayer.Dtos.AdminDtos;
using FoodMart.EntityLayer.Entities;

namespace FoodMart.WebUI.Mapping
{
    public class AdminMapping : Profile
    {
        public AdminMapping()
        {
            CreateMap<AppUser, CreateRegisterDto>().ReverseMap();
        }
    }
}
