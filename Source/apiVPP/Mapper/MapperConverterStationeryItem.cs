using apiVPP.DTOs.Request;
using apiVPP.DTOs.Response;
using apiVPP.Models;
using Azure;

namespace apiVPP.Mapper
{
    public class MapperConverterStationeryItem
    {
        public static StationeryItemResponse ToStationeryItemResponseDTO(StationeryItem stationeryItem)
        {
            var response = new StationeryItemResponse();
            response.ItemID = stationeryItem.ItemID;
            response.ItemName = stationeryItem.ItemName;
            response.Quantity = stationeryItem.Quantity;
            response.Price = stationeryItem.Price;
            response.Fee = stationeryItem.Fee;
            response.ImageURL = stationeryItem.ImageURL;
            return response;
        }

        public static StationeryItem requestStationeryItem(StationeryItemRequest request)
        {
            var stationeryItem = new StationeryItem();
            stationeryItem.ItemID = request.ItemID;
            stationeryItem.ItemName = stationeryItem.ItemName;
            stationeryItem.Quantity = stationeryItem.Quantity;
            stationeryItem.Price = stationeryItem.Price;
            stationeryItem.Fee = stationeryItem.Fee;
            stationeryItem.ImageURL = stationeryItem.ImageURL;
            return stationeryItem;
        }
    }
}
