using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interface;
using System.Web.Mvc;

namespace DataAccess.Model
{
    public class Pizza : IEntity
    {
        public virtual int Id { get; set; }

        [Required(ErrorMessage = "Nazev pizzy je povinny")]
        public virtual string Name { get; set; }

        [Required(ErrorMessage = "Cena pizzy je povinna")]
        [Range(90, 180, ErrorMessage = "Cena pizzy muze byt mezi 90 - 180 Kc")]
        public virtual decimal Price { get; set; }
        
        public virtual Ingredience Ingredience { get; set; }
    }
}
