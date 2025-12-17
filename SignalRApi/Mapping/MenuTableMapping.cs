using AutoMapper;
using DTOLayer.MenuTableDTO;
using EntityLayer.Entities;

namespace SignalRApi.Mapping;

public class MenuTableMapping : Profile
{
    public MenuTableMapping()
    {
        CreateMap<MenuTable, ResultMenuTableDto>().ReverseMap();
        CreateMap<MenuTable, UpdateMenuTableDto>().ReverseMap();
        CreateMap<MenuTable, CreateMenuTableDto>().ReverseMap();
        CreateMap<MenuTable, GetMenuTableDto>().ReverseMap();
    }
}