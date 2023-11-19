using ParkingAPI.DTOs;
using ParkingAPI.Helpers;
using System.ComponentModel.DataAnnotations;

namespace ParkingAPI.Models
{
    public class Company
    {
        [Key]
        public long id { get; set; }
        public string name { get; set; }
        public long cnpj { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public int qtyMotorcycleSpaces { get; set; }
        public int qtyCarsSpaces { get; set; }

        public Company()
        {
        }

        public Company(CompanyDTO companyDTO)
        {
            this.name = companyDTO.name;
            this.cnpj = CNPJ.parseCNPJ(companyDTO.cnpj);
            this.address = companyDTO.address;
            this.phone = companyDTO.phone;
            this.qtyMotorcycleSpaces = companyDTO.qtyMotorcycleSpaces;
            this.qtyCarsSpaces = companyDTO.qtyCarsSpaces;
        }

        public Company(int id, CompanyDTO companyDTO)
        {
            this.id = id;
            this.name = companyDTO.name;
            this.cnpj = CNPJ.parseCNPJ(companyDTO.cnpj);
            this.address = companyDTO.address;
            this.phone = companyDTO.phone;
            this.qtyMotorcycleSpaces = companyDTO.qtyMotorcycleSpaces;
            this.qtyCarsSpaces = companyDTO.qtyCarsSpaces;
        }
    }
}
