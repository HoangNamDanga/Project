using apiVPP.Models;

namespace apiVPP.DTOs.Request
{
    public class ApprovalRequest
    {
        public int ApprovedId { get; set; }
        public int RequestID { get; set; }
        public int ItemID { get; set; }
        public DateTime RequestDate { get; set; }
        public RequestApproval ApprovedStatus { get; set; }
        public int EmployeeID { get; set; }
    }
}
