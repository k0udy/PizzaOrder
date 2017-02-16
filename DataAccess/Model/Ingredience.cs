using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interface;
using System.Web.Mvc;

namespace DataAccess.Model
{
    public class Ingredience : IEntity
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }
    }
}
