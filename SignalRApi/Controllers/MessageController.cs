using BusinessLayer.Abstract;
using DTOLayer.MessageDTO;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
    
        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public IActionResult AboutMessage()
        {
            var values = _messageService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
            Message about = new Message()
            {
                Mail =  createMessageDto.Mail,
                PhoneNumber =  createMessageDto.PhoneNumber,
                NameSurname = createMessageDto.NameSurname,
                MessageDate =  DateTime.Now,
                Subject = createMessageDto.Subject,
                MessageContent =  createMessageDto.MessageContent,
                Status = false
            };
            _messageService.TAdd(about);
            return Ok("Mesaj Gönderildi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id)
        {
            var value = _messageService.TGetById(id);
            _messageService.TDelete(value);
            return Ok("Mesaj silindi");
        }

        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            Message about = new Message()
            {
                MessageId =  updateMessageDto.MessageId,
                Mail =  updateMessageDto.Mail,
                PhoneNumber =  updateMessageDto.PhoneNumber,
                NameSurname = updateMessageDto.NameSurname,
                MessageDate =  DateTime.Now,
                Subject = updateMessageDto.Subject,
                MessageContent =  updateMessageDto.MessageContent,
                Status =  updateMessageDto.Status
            };
            _messageService.TUpdate(about);
            return Ok("Mesaj alanı güncellendi");
        }
    
        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            var value = _messageService.TGetById(id);
            return Ok(value);
        }
    }
}
