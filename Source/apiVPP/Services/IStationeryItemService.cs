using apiVPP.DTOs.Request;
using apiVPP.DTOs.Response;
using apiVPP.Models;

namespace apiVPP.Services
{
    public interface IStationeryItemService
    {
        public List<StationeryItem> getAllStationeryItem();
        public StationeryItem getStationeryItemById(int id);
        public bool DeleteStationeryItem(int id);
        public StationeryItem AddStationeryItem(StationeryItem request);
        public StationeryItem UpdateStationeryItem(StationeryItem request);
    }
}
