using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apiVPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationeryController : ControllerBase
    {
        [HttpGet("get-stationery")]
        public IActionResult Stationeries() 
        {
            return Ok(new JsonResult(new { message = "only Authorized employees can view stationery" }));
        }
    }
}
