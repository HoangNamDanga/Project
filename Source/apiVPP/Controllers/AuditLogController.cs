using apiVPP.DTOs.Request;
using apiVPP.DTOs.Response;
using apiVPP.Models;
using apiVPP.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apiVPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditLogController : ControllerBase
    {
        private readonly IAuditLogService _auditLogService;

        public AuditLogController(IAuditLogService auditLogService)
        {
            _auditLogService = auditLogService;
        }

        [HttpGet]
        public ActionResult<List<AuditLogResponse>> GetAllAuditLogs()
        {
            var auditLogs = _auditLogService.GetAllAuditLogs();
            return Ok(auditLogs);
        }

        [HttpGet("{id}")]
        public ActionResult<AuditLogResponse> GetAuditLogById(int id)
        {
            var auditLog = _auditLogService.GetAuditLogById(id);
            if (auditLog == null)
            {
                return NotFound();
            }
            return Ok(auditLog);
        }

        [HttpPost]
        public ActionResult<AuditLog> AddAuditLog(AuditLogRequest request)
        {
            var newAuditLog = _auditLogService.AddAuditLog(request);
            return CreatedAtAction(nameof(GetAuditLogById), new { id = newAuditLog.Id }, newAuditLog);
        }

        [HttpPut("{id}")]
        public ActionResult<AuditLog> UpdateAuditLog(int id, AuditLogRequest request)
        {
            var updatedAuditLog = _auditLogService.UpdateAuditLog(request);
            if (updatedAuditLog == null)
            {
                return NotFound();
            }
            return Ok(updatedAuditLog);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteAuditLog(int id)
        {
            var result = _auditLogService.DeleteAuditLog(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
