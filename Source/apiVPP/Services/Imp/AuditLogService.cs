using apiVPP.Data;
using apiVPP.DTOs.Request;
using apiVPP.DTOs.Response;
using apiVPP.Mapper;
using apiVPP.Models;

namespace apiVPP.Services.Imp
{
    public class AuditLogService : IAuditLogService
    {
        private readonly Context _context;

        public AuditLogService(Context context)
        {
            _context = context;
        }
        public AuditLog AddAuditLog(AuditLogRequest request)
        {
            var audit = MapperConverterAuditLog.ToAuditLog(request);
            _context.AuditLogs.Add(audit);
            _context.SaveChanges();
            return audit;
        }

        public bool DeleteAuditLog(int id)
        {
            var audit = _context.AuditLogs.FirstOrDefault(e => e.Id == id);
            if (audit != null)
            {
                _context.AuditLogs.Remove(audit);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<AuditLogResponse> GetAllAuditLogs()
        {
            return _context.AuditLogs.Select(e => MapperConverterAuditLog.ToAuditLogResponseDTO(e)).ToList();
        }

        public AuditLogResponse GetAuditLogById(int id)
        {
            var audit = _context.AuditLogs.FirstOrDefault(a => a.Id == id);
            if (audit != null)
            {
                return MapperConverterAuditLog.ToAuditLogResponseDTO(audit);
            }
            else
            {
                return null;
            }
        }

        public AuditLog UpdateAuditLog(AuditLogRequest request)
        {
            var audit = MapperConverterAuditLog.ToAuditLog(request);
            var auditUpdate = _context.AuditLogs.FirstOrDefault(e => e.Id == audit.Id);
            if (auditUpdate != null)
            {
                auditUpdate.Id = audit.Id;
                auditUpdate.EmployeeID = audit.EmployeeID;
                auditUpdate.FieldChanged = audit.FieldChanged;
                auditUpdate.OldValue = audit.OldValue;
                auditUpdate.NewValue = audit.NewValue;
                auditUpdate.ChangeDate = audit.ChangeDate;
                auditUpdate.ChangedBy = audit.ChangedBy;
                _context.SaveChanges();
            }
            return auditUpdate;
        }
    }
}
