using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MagazinKompTechniki.Entity
{
    public class Warehouse
    {
        public int ID { get; set; }
        [Required] [MaxLength(100)] public string WarehouseAdress { get; set; }
        [Required] public int Capacity { get; set; }
        [Required] public virtual List<Compartment> Compartments { get; set; }
        public Warehouse ()
        {
            Compartments = new List<Compartment> ();
        }
    }
}
