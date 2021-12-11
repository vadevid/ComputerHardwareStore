using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MagazinKompTechniki.Entity
{
    public class Employee
    {
        public int ID { get; set; }
        [Required] [MaxLength(50)] public string SecondName { get; set; }
        [Required] [MaxLength(50)] public string FirstName { get; set; }
        [MaxLength(50)] public string MiddleName { get; set; }
        [Required] [MaxLength(50)] public string Login { get; set; }
        [Required] [MaxLength(60)] public string Password { get; set; }
    }
}
