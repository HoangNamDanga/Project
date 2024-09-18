using apiVPP.Data;
using apiVPP.DTOs.Request;
using apiVPP.DTOs.Response;
using apiVPP.Models;

namespace apiVPP.Services.Imp
{
    public class ApprovalService : IApprovalService
    {
        private readonly Context _context;

        public ApprovalService(Context context)
        {
            _context = context;
        }

        public Approval AddApproval(ApprovalRequest request)
        {
            var newApproval = new Approval
            {
                RequestID = request.RequestID,
                ItemID = request.ItemID,
                RequestDate = request.RequestDate,
                ApprovedStatus = request.ApprovedStatus,
                EmployeeID = request.EmployeeID
            };

            _context.Approvals.Add(newApproval);
            _context.SaveChanges();

            return newApproval;
        }

        public bool DeleteApproval(int id)
        {
            var approvalToDelete = _context.Approvals.FirstOrDefault(a => a.ApprovedId == id);

            if (approvalToDelete == null)
            {
                return false;
            }

            _context.Approvals.Remove(approvalToDelete);
            _context.SaveChanges();

            return true;
        }

        public List<ApprovalResponse> GetAllApprovals()
        {
            var approvals = _context.Approvals.ToList();
            var approvalResponses = approvals.Select(approval => new ApprovalResponse
            {
                ApprovedId = approval.ApprovedId,
                RequestID = approval.RequestID,
                ItemID = approval.ItemID,
                RequestDate = approval.RequestDate,
                ApprovedStatus = approval.ApprovedStatus,
                EmployeeID = approval.EmployeeID
            }).ToList();

            return approvalResponses;
        }

        public ApprovalResponse GetApprovalById(int id)
        {
            var approval = _context.Approvals.FirstOrDefault(a => a.ApprovedId == id);

            if (approval == null)
            {
                return null;
            }

            var approvalResponse = new ApprovalResponse
            {
                ApprovedId = approval.ApprovedId,
                RequestID = approval.RequestID,
                ItemID = approval.ItemID,
                RequestDate = approval.RequestDate,
                ApprovedStatus = approval.ApprovedStatus,
                EmployeeID = approval.EmployeeID
            };

            return approvalResponse;
        }

        public Approval UpdateApproval(ApprovalRequest request)
        {
            var existingApproval = _context.Approvals.FirstOrDefault(a => a.ApprovedId == request.ApprovedId);

            if (existingApproval == null)
            {
                return null;
            }

            existingApproval.RequestID = request.RequestID;
            existingApproval.ItemID = request.ItemID;
            existingApproval.RequestDate = request.RequestDate;
            existingApproval.ApprovedStatus = request.ApprovedStatus;
            existingApproval.EmployeeID = request.EmployeeID;

            _context.SaveChanges();
            return existingApproval;
        }
    }
}
