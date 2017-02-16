using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interface;

namespace DataAccess.Model
{
    public class Order : IEntity
    {
        public virtual int Id { get; set; }
        public virtual DateTime OrderDate { get; set; }
        public virtual string OrderedPizza { get; set; }
        public virtual int PizzaCount { get; set; }
        public virtual decimal Price { get; set; }

        [Required(ErrorMessage = "Jmeno zakaznika je povinne")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Pouzijte pouze pismena")]
        public virtual string CustomerName { get; set; }

        [Required(ErrorMessage = "Adresa zakaznika je povinna")]
        public virtual string CustomerAddress { get; set; }

    }
}
