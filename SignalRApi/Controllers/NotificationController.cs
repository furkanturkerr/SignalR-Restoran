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
        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
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
            Notification notification = new Notification()
            {
                Description = createNotificationDto.Description,
                Type = createNotificationDto.Type,
                Status = false,
                Icon = createNotificationDto.Icon,
                Date = Convert.ToDateTime(DateTime.Now.ToShortDateString())
            };
            _notificationService.TAdd(notification);
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
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateNotification( UpdateNotificationDto updateNotificationDto)
        {
            Notification notification = new Notification()
            {
                NotificationId = updateNotificationDto.NotificationId,
                Description = updateNotificationDto.Description,
                Type = updateNotificationDto.Type,
                Status = updateNotificationDto.Status,
                Icon = updateNotificationDto.Icon,
                Date = updateNotificationDto.Date
            };
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
