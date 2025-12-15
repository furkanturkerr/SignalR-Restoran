using AutoMapper;
using DTOLayer.FeatureDTO;
using DTOLayer.SliderDTO;
using EntityLayer.Entities;

namespace SignalRApi.Mapping;

public class SliderMapping : Profile
{
    public SliderMapping()
    {
        CreateMap<Slider, ResultSliderDto>().ReverseMap();
        CreateMap<Slider, UpdateSliderDto>().ReverseMap();
        CreateMap<Slider, CreateSliderDto>().ReverseMap();
        CreateMap<Slider, GetSliderDto>().ReverseMap();
    }
}