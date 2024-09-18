using System.ComponentModel.DataAnnotations;

namespace apiVPP.Models
{
    public enum RequestApproval
    {
        Approved = 1,
        Rejected = 2
    }
    public class Approval
    {
        [Key]
        public int ApprovedId { get; set; }

        public int RequestID { get; set; }
        public StationeryRequest StationeryRequest { get; set; }


        public int ItemID { get; set; }
        public StationeryItem StationeryItem { get; set; }

        public DateTime RequestDate { get; set; }
        public RequestApproval ApprovedStatus { get; set; }
        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }
    }
}
