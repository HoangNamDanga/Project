namespace apiVPP.Models
{
    public enum RequestStatus
    {
        Pending = 1,
        Approved = 2,
        Rejected = 3,
        Cancelled = 4,
        Withdrawn = 5
    }
    public class StationeryRequest
    {
        public int RequestID { get; set; }
        public int EmployeeID { get; set; }
        public int ItemID { get; set; }
        public DateTime RequestData { get; set; }
        public RequestStatus Status { get; set; }
        public int QuantityRequested { get; set; }
        public int? SuperviorID {  get; set; }
        public int? ApprovedById { get; set; }
        public Employee Employee { get; set; }
        public Employee Supervisor { get; set; }
        public Employee ApprovedBy { get; set; }
        public StationeryItem StationeryItem { get; set; }
    }
}
