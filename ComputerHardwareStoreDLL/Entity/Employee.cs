using ComputerHardwareStoreDLL.Entity;
using MagazinKompTechnikiDLL;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace MagazinKompTechniki.Entity
{
    public class Employee : Human
    {
        private static ApplicationContext db = Context.Db;
        public int ID { get; set; }
        [Required] [MaxLength(50)] public string Login { get; set; }
        [Required] [Column(TypeName = "varchar(64)")] public string Password { get; set; }
        public class EmployeeInfo
        {
            public int ID { get; set; }
            public string SecondName { get; set; }
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string Login { get; set; }
        }
        /// <summary>
        /// Получение полного имени
        /// </summary>
        public override string GetFullName()
        {
            var temp = $"{SecondName} {FirstName} ";
            if (MiddleName != null) temp += $"{MiddleName}";
            return temp;
        }
        public class AuthorizedData
        {
            public string Login { get; set; }
            public string Password { get; set; }
        }
        /// <summary>
        /// Получение информации о сотрудниках
        /// </summary>
        public static List<EmployeeInfo> GetEmployeeInfo()
        {
            return (from e in db.Employee
                    where e.Login != "admin"
                    select new EmployeeInfo()
                    {
                        ID = e.ID,
                        SecondName = e.SecondName,
                        FirstName = e.FirstName,
                        MiddleName = e.MiddleName,
                        Login = e.Login,
                    }).ToList();
        }
        /// <summary>
        /// Получение сотрудников в том или ином виде
        /// </summary>
        public static Employee GetEmployeeById(int id)
        {
            return (from e in db.Employee
                    where e.ID == id
                    select e).FirstOrDefault();
        }
        public static Employee GetEmployeeByLogin(string login)
        {
            Employee employee;
            employee = (from e in db.Employee
                        where e.Login == login
                        select e).FirstOrDefault();
            return employee;
        }
        /// <summary>
        /// Вход в учётную запись
        /// </summary>
        public static Employee SingIn(string login, string password)
        {
            return db.Employee.Where(e => e.Login == login && e.Password == password).FirstOrDefault();
        }
        /// <summary>
        /// Добавление в базу данных
        /// </summary>
        public static void Add(Employee employee)
        {
            db.Employee.Add(employee);
            db.SaveChanges();
        }
    }
}
