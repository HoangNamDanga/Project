using apiVPP.Models;

namespace apiVPP.Services
{
    public interface IStationeryRequestService
    {
        public List<StationeryRequest> getAllStationeryRequest();
        public StationeryRequest getStationeryRequestById(int id);
        public StationeryRequest DeleteStationeryRequest(int id);
        public StationeryRequest AddStationeryRequest(StationeryRequest request);
        public StationeryRequest UpdateStationeryRequest(StationeryRequest request);
    }
}
