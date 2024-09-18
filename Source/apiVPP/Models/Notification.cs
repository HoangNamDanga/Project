namespace apiVPP.Models
{
    public class Notification
    {
        public int NotificationID { get; set; }
        public int EmployeeID { get; set; }
        public string Message { get; set; }
        public DateTime DateSent { get; set; }
        public Employee Employee { get; set; }
    }
}
