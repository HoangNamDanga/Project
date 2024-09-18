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
    public class StationeryItemController : ControllerBase
    {
        private readonly IStationeryItemService _stationeryItemService;

        public StationeryItemController(IStationeryItemService stationeryItemService)
        {
            _stationeryItemService = stationeryItemService;
        }

        [HttpGet]
        public ActionResult<List<StationeryItemResponse>> GetAllStationeryItems()
        {
            var stationeryItems = _stationeryItemService.getAllStationeryItem();
            return Ok(stationeryItems);
        }

        [HttpGet("{id}")]
        public ActionResult<StationeryItem> GetStationeryItemById(int id)
        {
            var stationeryItem = _stationeryItemService.getStationeryItemById(id);
            if (stationeryItem == null)
            {
                return NotFound();
            }
            return Ok(stationeryItem);
        }

        [HttpPost]
        public ActionResult<StationeryItem> AddStationeryItem(StationeryItem request)
        {
            var newStationeryItem = _stationeryItemService.AddStationeryItem(request);
            return CreatedAtAction(nameof(GetStationeryItemById), new { id = newStationeryItem.ItemID }, newStationeryItem);
        }

        [HttpPut("{id}")]
        public ActionResult<StationeryItem> UpdateStationeryItem( StationeryItem request)
        {
            var updatedStationeryItem = _stationeryItemService.UpdateStationeryItem(request);
            if (updatedStationeryItem == null)
            {
                return NotFound();
            }
            return Ok(updatedStationeryItem);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteStationeryItem(int id)
        {
            var result = _stationeryItemService.DeleteStationeryItem(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
