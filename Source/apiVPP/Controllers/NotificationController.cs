using apiVPP.DTOs.Request;
using apiVPP.DTOs.Response;
using apiVPP.Models;
using apiVPP.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apiVPP.Controllers
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
        public ActionResult<List<NotificationReponse>> GetAllNotifications()
        {
            var notifications = _notificationService.getAllNotification();
            return Ok(notifications);
        }

        [HttpGet("{id}")]
        public ActionResult<NotificationReponse> GetNotificationById(int id)
        {
            var notification = _notificationService.getNotificationById(id);
            if (notification == null)
            {
                return NotFound();
            }
            return Ok(notification);
        }

        [HttpPost]
        public ActionResult<Notification> AddNotification(NotificationRequest request)
        {
            var newNotification = _notificationService.AddNotificationr(request);
            return CreatedAtAction(nameof(GetNotificationById), new { id = newNotification.NotificationID }, newNotification);
        }

        [HttpPut("{id}")]
        public ActionResult<Notification> UpdateNotification(int id, NotificationRequest request)
        {
            var updatedNotification = _notificationService.UpdateNotification(request);
            if (updatedNotification == null)
            {
                return NotFound();
            }
            return Ok(updatedNotification);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteNotification(int id)
        {
            var result = _notificationService.DeleteNotification(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
