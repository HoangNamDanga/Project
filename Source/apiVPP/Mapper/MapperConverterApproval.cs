using apiVPP.DTOs.Request;
using apiVPP.DTOs.Response;
using apiVPP.Models;

namespace apiVPP.Mapper
{
    public class MapperConverterApproval
    {
        public static ApprovalResponse ToApprovalResponseDTO(Approval approval)
        {
            return new ApprovalResponse
            {
                ApprovedId = approval.ApprovedId,
                RequestID = approval.RequestID,
                ItemID = approval.ItemID,
                RequestDate = approval.RequestDate,
                ApprovedStatus = approval.ApprovedStatus,
            };
        }

        public static Approval ToApproval(ApprovalRequest request)
        {
            return new Approval
            {
                ApprovedId = request.ApprovedId,
                RequestID = request.RequestID,
                ItemID = request.ItemID,
                RequestDate = request.RequestDate,
                ApprovedStatus = request.ApprovedStatus,
                EmployeeID = request.EmployeeID
            };
        }
    }
}
