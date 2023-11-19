using ParkingAPI.DTOs;
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

        public Vehicle()
        {

        }

        public Vehicle(VehicleDTO vehicleDTO)
        {
            this.brand = vehicleDTO.brand;
            this.model = vehicleDTO.model;
            this.color = vehicleDTO.color;
            this.plate = vehicleDTO.plate;
            this.type = vehicleDTO.type;
        }

        public Vehicle(int id, VehicleDTO vehicleDTO)
        {
            this.id = id;   
            this.brand = vehicleDTO.brand;
            this.model = vehicleDTO.model;
            this.color = vehicleDTO.color;
            this.plate = vehicleDTO.plate;
            this.type = vehicleDTO.type;
        }
    }
}
