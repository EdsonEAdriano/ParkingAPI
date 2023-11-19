namespace ParkingAPI.DTOs
{
    public class CompanyDTO
    {
        public string name { get; set; }
        public string cnpj { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public int qtyMotorcycleSpaces { get; set; }
        public int qtyCarsSpaces { get; set; }
    }
}
