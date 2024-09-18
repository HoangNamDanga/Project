using apiVPP.Models;

namespace apiVPP.DTOs.Request
{
    public class NotificationRequest
    {
        public int NotificationID { get; set; }
        public int EmployeeID { get; set; }
        public string Message { get; set; }
        public DateTime DateSent { get; set; }
    }
}
