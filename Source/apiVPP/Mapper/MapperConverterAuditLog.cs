using apiVPP.DTOs.Request;
using apiVPP.DTOs.Response;
using apiVPP.Models;

namespace apiVPP.Mapper
{
    public class MapperConverterAuditLog
    {
        public static AuditLogResponse ToAuditLogResponseDTO(AuditLog auditLog)
        {
            return new AuditLogResponse
            {
                Id = auditLog.Id,
                EmployeeID = auditLog.EmployeeID,
                FieldChanged = auditLog.FieldChanged,
                OldValue = auditLog.OldValue,
                NewValue = auditLog.NewValue,
                ChangedBy = auditLog.ChangedBy,
                ChangeDate = auditLog.ChangeDate
            };
        }

        public static AuditLog ToAuditLog(AuditLogRequest request)
        {
            return new AuditLog
            {
                EmployeeID = request.EmployeeID,
                FieldChanged = request.FieldChanged,
                OldValue = request.OldValue,
                NewValue = request.NewValue,
                ChangedBy = request.ChangedBy,
                ChangeDate = request.ChangeDate
            };
        }
    }
}
