using apiVPP.Models;
using apiVPP.Services;
using apiVPP.Services.Imp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apiVPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationRequestController : ControllerBase
    {
        private readonly IStationeryRequestService _stationeryRequestService;

        public StationRequestController(IStationeryRequestService stationeryRequestService)
        {
            _stationeryRequestService = stationeryRequestService;
        }

        [HttpPost]
        public ActionResult<StationeryRequest> AddStationeryRequest(StationeryRequest request)
        {
            var addedRequest = _stationeryRequestService.AddStationeryRequest(request);
            return Ok(addedRequest);
        }

        [HttpGet]
        public ActionResult<List<StationeryRequest>> GetAllStationeryRequests()
        {
            var requests = _stationeryRequestService.getAllStationeryRequest();
            return Ok(requests);
        }

        [HttpGet("{id}")]
        public ActionResult<StationeryRequest> GetStationeryRequestById(int id)
        {
            var request = _stationeryRequestService.getStationeryRequestById(id);
            if (request == null)
            {
                return NotFound();
            }
            return Ok(request);
        }


        [HttpPut("{id}")]
        public ActionResult<StationeryRequest> UpdateStationeryRequest(StationeryRequest request)
        {
            var updatedRequest = _stationeryRequestService.UpdateStationeryRequest(request);
            if (updatedRequest == null)
            {
                return NotFound();
            }
            return Ok(updatedRequest);
        }

        [HttpDelete("{id}")]
        public ActionResult<StationeryRequest> DeleteStationeryRequest(int id)
        {
            var deletedRequest = _stationeryRequestService.DeleteStationeryRequest(id);
            if (deletedRequest == null)
            {
                return NotFound();
            }
            return Ok(deletedRequest);
        }
    }
}
