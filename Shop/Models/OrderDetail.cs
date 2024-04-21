using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Here we describe each service we purchase. We create variables that will connect this class with the Order and Service classes.

namespace Shop.Models
{
    public class OrderDetail
    {
        public int id { get; set; }

        public int orderID { get; set; }

        public int ServiceID { get; set; }

        public uint price { get; set; }

        public virtual Service service { get; set; }

        public virtual Order order { get; set; }

    }
}
