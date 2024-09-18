using apiVPP.Data;
using apiVPP.DTOs.Request;
using apiVPP.DTOs.Response;
using apiVPP.Mapper;
using apiVPP.Models;

namespace apiVPP.Services.Imp
{
    public class NotificationService : INotificationService
    {
        private readonly Context _context;

        public NotificationService(Context context)
        {
            _context = context;
        }
        public Notification AddNotificationr(NotificationRequest request)
        {
            var noti = MapperConverterNotification.ToNotification(request);
            _context.Notifications.Add(noti);
            _context.SaveChanges();
            return noti;
        }

        public bool DeleteNotification(int id)
        {
            var noti = _context.Notifications.FirstOrDefault(e => e.NotificationID == id);
            if (noti != null)
            {
                _context.Notifications.Remove(noti);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<NotificationReponse> getAllNotification()
        {
            return _context.Notifications.Select(e => MapperConverterNotification.ToNotificatioResponseDTO(e)).ToList();
        }

        public Notification getNotificationById(int id)
        {
            var noti = _context.Notifications.FirstOrDefault(a => a.NotificationID == id);
            if (noti != null)
            {
                return noti;
            }
            else
            {
                return null;
            }
        }

        public Notification UpdateNotification(NotificationRequest request)
        {
            var noti = MapperConverterNotification.ToNotification(request);
            var updateNoti = _context.Notifications.FirstOrDefault(e => e.NotificationID == noti.NotificationID);
            if (updateNoti != null)
            {
                updateNoti.NotificationID = request.NotificationID;
                updateNoti.Message = request.Message;
                updateNoti.EmployeeID = request.EmployeeID;
                updateNoti.Message = request.Message;
                _context.SaveChanges();
            }
            return updateNoti;
        }
    }
}
