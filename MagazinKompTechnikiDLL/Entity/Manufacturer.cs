using System;
using System.ComponentModel.DataAnnotations;

namespace MagazinKompTechniki.Entity
{
    public class Manufacturer
    {
        public int ID { get; set; }
        [Required] [MaxLength(50)] public string ManufacturerName { get; set; }
        [MaxLength(100)] public string ManufacturerAdress { get; set; }
        [MaxLength(12)] public string ManufacturerPhone { get; set; }
    }
}
