using apiVPP.DTOs.Request;
using apiVPP.DTOs.Response;
using apiVPP.Models;

namespace apiVPP.Services
{
    public interface IApprovalService
    {
        List<ApprovalResponse> GetAllApprovals();
        ApprovalResponse GetApprovalById(int id);
        bool DeleteApproval(int id);
        Approval AddApproval(ApprovalRequest request);
        Approval UpdateApproval(ApprovalRequest request);
    }
}
