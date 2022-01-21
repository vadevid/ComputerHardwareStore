using MagazinKompTechnikiDLL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MagazinKompTechniki.Entity
{
    public class Guarantee
    {
        private static ApplicationContext db = Context.Db;
        public int ID { get; set; }
        [Required] public string DurationOfTheGuarantee { get; set; }
        [Required] public DateTime GuaranteeDate { get; set; }
        [Required] public double GuaranteeCost { get; set; }
        public static List<Guarantee> GetAllGuarantees()
        {
            return (from g in db.Guarantee
                    select g).ToList();
        }
        public static Guarantee GetGuaranteeByDuration(string duration)
        {
            return (from g in db.Guarantee
                    where g.DurationOfTheGuarantee == duration
                    select g).FirstOrDefault();
        }
        public static Guarantee GetGuaranteeById(int id)
        {
            return (from gu in db.Guarantee
                    where gu.ID == id
                    select gu).FirstOrDefault();
        }
    }
}
