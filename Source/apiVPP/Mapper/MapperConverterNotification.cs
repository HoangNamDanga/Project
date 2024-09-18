using apiVPP.DTOs.Request;
using apiVPP.DTOs.Response;
using apiVPP.Models;

namespace apiVPP.Mapper
{
    public class MapperConverterNotification
    {
        public static NotificationReponse ToNotificatioResponseDTO(Notification notification)
        {
            return new NotificationReponse
            {
                NotificationID = notification.NotificationID,
                EmployeeID = notification.EmployeeID,
                Message = notification.Message,
                DateSent = notification.DateSent,
            };
        }

        public static Notification ToNotification(NotificationRequest request)
        {
            return new Notification
            {
                NotificationID = request.NotificationID,
                EmployeeID = request.EmployeeID,
                Message = request.Message,
                DateSent = request.DateSent,
            };
        }
    }
}
