using ParkingAPI.Enums;
using ParkingAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingAPI.DTOs
{
    public class ControlDTO
    {
        public long companyID { get; set; }
        public int vehicleID { get; set; }
    }
}