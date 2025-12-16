using AutoMapper;
using DTOLayer.MessageDTO;
using EntityLayer.Entities;

namespace SignalRApi.Mapping;

public class MessageMapping : Profile
{
    public MessageMapping()
    {
        CreateMap<Message, CreateMessageDto>();
        CreateMap<Message, ResultMessageDto>();
        CreateMap<Message, UpdateMessageDto>();
        CreateMap<Message, GetMessageDto>();
    }
}