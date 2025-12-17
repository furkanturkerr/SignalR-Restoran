using AutoMapper;
using DTOLayer.MessageDTO;
using EntityLayer.Entities;

namespace SignalRApi.Mapping;

public class MessageMapping : Profile
{
    public MessageMapping()
    {
        CreateMap<Message, CreateMessageDto>().ReverseMap();
        CreateMap<Message, ResultMessageDto>().ReverseMap();
        CreateMap<Message, UpdateMessageDto>().ReverseMap();
        CreateMap<Message, GetMessageDto>().ReverseMap();
    }
}