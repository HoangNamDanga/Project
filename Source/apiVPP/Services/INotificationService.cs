using apiVPP.DTOs.Request;
using apiVPP.DTOs.Response;
using apiVPP.Models;

namespace apiVPP.Services
{
    public interface INotificationService
    {
        public List<NotificationReponse> getAllNotification();
        public Notification getNotificationById(int id);
        public bool DeleteNotification(int id);
        public Notification AddNotificationr(NotificationRequest request);
        public Notification UpdateNotification(NotificationRequest request);
    }
}
