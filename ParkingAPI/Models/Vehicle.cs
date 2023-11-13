using ParkingAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace ParkingAPI.Models
{
    public class Vehicle
    {
        [Key]
        public int id { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public string color { get; set; }
        public string plate { get; set; }
        public VehicleType type { get; set; }
    }
}
