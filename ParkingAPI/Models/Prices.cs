using ParkingAPI.DTOs;
using System.ComponentModel.DataAnnotations;

namespace ParkingAPI.Models
{
    public class Prices
    {
        [Key]
        public short id { get; set; }
        public short hours { get; set; }
        public double price { get; set; }

        public Prices()
        {
        }

        public Prices(PricesDTO pricesDTO)
        {
            this.hours = pricesDTO.hours;
            this.price = pricesDTO.price;
        }

        public Prices(short id, PricesDTO pricesDTO)
        {
            this.id = id;
            this.hours = pricesDTO.hours;
            this.price = pricesDTO.price;
        }
    }
}
