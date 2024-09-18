using apiVPP.DTOs.Account;
using apiVPP.Models;
using System.ComponentModel.DataAnnotations;

namespace apiVPP.DTOs.Response
{
    public class ApprovalResponse
    {
        public int ApprovedId { get; set; }
        public int RequestID { get; set; }
        public int ItemID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime RequestDate { get; set; }
        public RequestApproval ApprovedStatus { get; set; }
    }
}
