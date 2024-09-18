using apiVPP.Models;

namespace apiVPP.DTOs.Response
{
    public class NotificationReponse
    {
        public int NotificationID { get; set; }
        public int EmployeeID { get; set; }
        public string Message { get; set; }
        public DateTime DateSent { get; set; }
    }
}
