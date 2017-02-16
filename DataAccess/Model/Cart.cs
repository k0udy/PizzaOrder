using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interface;

namespace DataAccess.Model
{
    public class Cart: IEntity
    {

        public virtual int Id { get; set; }
        public virtual Pizza Pizza { get; set; }
        public virtual int Count { get; set; }
        public virtual List<Order> Order { get; set; }
    }
}
