using apiVPP.Data;
using apiVPP.DTOs.Request;
using apiVPP.DTOs.Response;
using apiVPP.Mapper;
using apiVPP.Models;

namespace apiVPP.Services.Imp
{
    public class StationeryItemService : IStationeryItemService
    {
        private readonly Context _context;

        public StationeryItemService(Context context)
        {
            _context = context;
        }
        public StationeryItem AddStationeryItem(StationeryItem request)
        {
            _context.StationeryItems.Add(request);
            _context.SaveChanges();
            return request;
        }

        public bool DeleteStationeryItem(int id)
        {
            var station = _context.StationeryItems.FirstOrDefault(e => e.ItemID == id);
            if (station != null)
            {
                _context.StationeryItems.Remove(station);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<StationeryItem> getAllStationeryItem()
        {
            return _context.StationeryItems.ToList();
        }

        public StationeryItem getStationeryItemById(int id)
        {
            var station = _context.StationeryItems.FirstOrDefault(a => a.ItemID == id);
            if (station != null)
            {
                return station;
            }
            else
            {
                return null;
            }
        }

        public StationeryItem UpdateStationeryItem(StationeryItem request)
        {
            var updateStation = _context.StationeryItems.FirstOrDefault(e => e.ItemID == request.ItemID);
            if (updateStation != null)
            {
                updateStation.ItemID = request.ItemID;
                updateStation.ItemName = request.ItemName;
                updateStation.Quantity = request.Quantity;
                updateStation.Price = request.Price;
                updateStation.Fee = request.Fee;
                updateStation.ImageURL = request.ImageURL;
                _context.SaveChanges();
            }
            return updateStation;
        }
    }
}
