using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.NotificationDTO;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;
        public NotificationController(INotificationService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult NotificationList()
        {
            return Ok(_notificationService.TGetListAll());
        }

        [HttpGet("NotificationCountByStatusFalse")]
        public IActionResult NotificationCountByStatusFalse()
        {
            return Ok(_notificationService.TNotificationCountByStatusFalse());
        }

        [HttpGet("GetAllNotificationsByFalse")]
        public IActionResult GetAllNotificationsByFalse()
        {
            return Ok(_notificationService.TGetAllNotificationsByFalse());
        }

        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
        {
            createNotificationDto.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            createNotificationDto.Status = false;
            var value = _mapper.Map<Notification>(createNotificationDto);
            _notificationService.TAdd(value);
            return Ok("Bildirim eklendi");
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(int id)
        {
            var value = _notificationService.TGetById(id);
            _notificationService.TDelete(value);
            return Ok("Bildirim silindi");
        }
        
        [HttpGet("{id}")]
        public IActionResult GetNotification(int id)
        {
            var value = _notificationService.TGetById(id);
            return Ok(_mapper.Map<GetNotificationDto>(value));
        }

        [HttpPut]
        public IActionResult UpdateNotification( UpdateNotificationDto updateNotificationDto)
        {
            var notification = _mapper.Map<Notification>(updateNotificationDto);
            _notificationService.TUpdate(notification);
            return Ok("Bildirim güncellendi");
        }

        [HttpGet("NotificationRead/{id}")]
        public IActionResult NotificationRead(int id)
        {
            _notificationService.TNotificationRead(id);
            return Ok("Bildirim okundu");
        }
        
        [HttpGet("NotNotificationRead/{id}")]
        public IActionResult NotNotificationRead(int id)
        {
            _notificationService.TNotNotificationRead(id);
            return Ok("Bildirim okunmadı");
        }
    }
}
