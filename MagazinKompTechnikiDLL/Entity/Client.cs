using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MagazinKompTechniki.Entity
{
    public class Client
    {
        public int ID { get; set; }
        [Required] [MaxLength(50)] public string SecondName { get; set; }
        [Required] [MaxLength(50)] public string FirstName { get; set; }
        [MaxLength(50)] public string MiddleName { get; set; }
        [MaxLength(50)] public string Adress { get; set; }

    }
}
