using MagazinKompTechnikiDLL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagazinKompTechniki.Entity
{
    public class Employee
    {
        public int ID { get; set; }
        [Required] [MaxLength(50)] public string SecondName { get; set; }
        [Required] [MaxLength(50)] public string FirstName { get; set; }
        [MaxLength(50)] public string MiddleName { get; set; }
        [Required] [MaxLength(50)] public string Login { get; set; }
        [Required] [Column(TypeName = "varchar(64)")] public string Password { get; set; }

        private static ApplicationContext db = Context.Db;


        public static List<EmployeeInfo> GetEmployeeInfo()
        {                     
            return (from e in db.Employee where e.Login != "admin"
                    select new EmployeeInfo()
                    {
                        ID = e.ID,
                        SecondName = e.SecondName,
                        FirstName = e.FirstName,
                        MiddleName = e.MiddleName,
                        Login = e.Login,
                    }).ToList();                       
        }

        public static Employee SingIn(string login, string password)
        {
            return db.Employee.Where(e => e.Login == login && e.Password == password).FirstOrDefault();
        }

        public class EmployeeInfo
        {
            public int ID { get; set; }
            public string SecondName { get; set; }
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string Login { get; set; }
        }
        public class AuthorizedData
        {
            public string Login { get; set; }
            public string Password { get; set; }
        }
        public static void Add (Employee employee)
        {
            db.Employee.Add(employee);
            db.SaveChanges();
        }
        public string FullName
        {
            get
            {
                var temp = $"{SecondName} {FirstName.Substring(0, 1)}.";
                if (MiddleName != null) temp += $"{MiddleName.Substring(0, 1)}.";
                return temp;
            }
        }

        public static Employee GetEmployeeByLogin (string login)
        {
            Employee employee;
            employee = (from e in db.Employee
                        where e.Login == login
                        select e).FirstOrDefault();
            return employee;
        }
    }
}
