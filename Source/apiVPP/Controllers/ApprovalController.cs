using apiVPP.DTOs.Request;
using apiVPP.Services;
using apiVPP.Services.Imp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apiVPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApprovalController : ControllerBase
    {
        private readonly IApprovalService _aprovalService;

        public ApprovalController(IApprovalService approvalService)
        {
            _aprovalService = approvalService;
        }

        [HttpGet]
        public IActionResult GetAllApprovals()
        {
            var approvals = _aprovalService.GetAllApprovals();
            return Ok(approvals);
        }

        [HttpGet("{id}")]
        public IActionResult GetApprovalById(int id)
        {
            var approval = _aprovalService.GetApprovalById(id);

            if (approval == null)
            {
                return NotFound();
            }

            return Ok(approval);
        }

        [HttpPost]
        public IActionResult AddApproval([FromBody] ApprovalRequest request)
        {
            var newApproval = _aprovalService.AddApproval(request);
            return Ok(newApproval);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateApproval([FromBody] ApprovalRequest request)
        {
            var updatedApproval = _aprovalService.UpdateApproval(request);

            if (updatedApproval == null)
            {
                return NotFound();
            }

            return Ok(updatedApproval);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteApproval(int id)
        {
            var result = _aprovalService.DeleteApproval(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
