using System.ComponentModel.DataAnnotations;

namespace ParkingAPI.Models
{
    public class Company
    {
        [Key]
        public long id { get; set; }
        public string name { get; set; }
        public string cnpj { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public int qtyMotorcycleSpaces { get; set; }
        public int qtyCarsSpaces { get; set; }
    }
}
