using AutoMapper;
using FoodMart.DtoLayer.Dtos.PeopleViewingDtos;
using FoodMart.EntityLayer.Entities;

namespace FoodMart.WebUI.Mapping
{
    public class PeopleViewingMapping : Profile
    {
        public PeopleViewingMapping()
        {
            CreateMap<PeopleViewing, ResultPeopleViewingDto>().ReverseMap();
            CreateMap<PeopleViewing, CreatePeopleViewingDto>().ReverseMap();
            CreateMap<PeopleViewing, GetPeopleViewingByIdDto>().ReverseMap();
            CreateMap<PeopleViewing, UpdatePeopleViewingDto>().ReverseMap();
        }
    }
}
