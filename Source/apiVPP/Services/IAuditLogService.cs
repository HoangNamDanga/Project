using apiVPP.DTOs.Request;
using apiVPP.DTOs.Response;
using apiVPP.Models;

namespace apiVPP.Services
{
    public interface IAuditLogService
    {
        List<AuditLogResponse> GetAllAuditLogs();
        AuditLogResponse GetAuditLogById(int id);
        bool DeleteAuditLog(int id);
        AuditLog AddAuditLog(AuditLogRequest request);
        AuditLog UpdateAuditLog(AuditLogRequest request);
    }
}
