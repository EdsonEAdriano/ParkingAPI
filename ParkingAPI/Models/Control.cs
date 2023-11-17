﻿using ParkingAPI.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ParkingAPI.Models
{
    public class Control
    {
        [Key]
        public long id { get; set; }
        [ForeignKey("company")]
        public long companyID { get; set; }
        public Company company { get; set; }
        [ForeignKey("vehicle")]
        public int vehicleID { get; set; }
        public Vehicle vehicle { get; set; }
        public ControlStatus status { get; set; } = ControlStatus.Parked;
        public DateTime createDate { get; set; } = DateTime.Now;
        public DateTime exitDate { get; set; }
    }
}
