using apiVPP.Data;
using apiVPP.Models;

namespace apiVPP.Services.Imp
{
    public class StationeryRequestService : IStationeryRequestService
    {
        private readonly Context _context;

        public StationeryRequestService(Context context)
        {
            _context = context;
        }
        public StationeryRequest AddStationeryRequest(StationeryRequest request)
        {
            _context.StationeryRequests.Add(request);
            _context.SaveChanges();
            return request;
        }

        public StationeryRequest DeleteStationeryRequest(int id)
        {
            var request = _context.StationeryRequests.FirstOrDefault(e => e.RequestID == id);
            if (request != null)
            {
                _context.StationeryRequests.Remove(request);
                _context.SaveChanges();
                return request;
            }
            else
            {
                return null;
            }
        }

        public List<StationeryRequest> getAllStationeryRequest()
        {
            return _context.StationeryRequests.ToList();
        }

        public StationeryRequest getStationeryRequestById(int id)
        {
            var request = _context.StationeryRequests.FirstOrDefault(a => a.RequestID == id);
            if (request != null)
            {
                return request;
            }
            else
            {
                return null;
            }
        }

        public StationeryRequest UpdateStationeryRequest(StationeryRequest request)
        {
            var updateRequest = _context.StationeryRequests.FirstOrDefault(e => e.RequestID == request.RequestID);
            if (updateRequest != null)
            {
                updateRequest.EmployeeID = request.EmployeeID;
                updateRequest.ItemID = request.ItemID;
                updateRequest.RequestData = request.RequestData;
                updateRequest.Status = request.Status;
                updateRequest.QuantityRequested = request.QuantityRequested;
                updateRequest.SuperviorID = request.SuperviorID;
                updateRequest.ApprovedById = request.ApprovedById;
                _context.SaveChanges();
            }
            return updateRequest;
        }
    }
}
