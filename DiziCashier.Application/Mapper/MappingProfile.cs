using AutoMapper;
using DiziCashier.Application.Commands;
using DiziCashier.Application.Response;
using DiziCashier.Core.Entities;

namespace DiziCashier.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ItemCategory, ItemCategoryResponse>().ReverseMap();
            CreateMap<ItemCategory, CreateItemCategoryCommand>().ReverseMap();
            CreateMap<ItemCategory, EditItemCategoryCommand>().ReverseMap();
        }
    }
}
