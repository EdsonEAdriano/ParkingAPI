using ParkingAPI.Enums;

namespace ParkingAPI.DTOs
{
    public class VehicleDTO
    {
        public string brand { get; set; }
        public string model { get; set; }
        public string color { get; set; }
        public string plate { get; set; }
        public VehicleType type { get; set; }
    }
}
