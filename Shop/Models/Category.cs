using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    //Model for displaying categories
    public class Category
    {
        //Unique identificator
        public int id { set; get; }
        //Name of category
        public string categoryName { set; get; }
        //Category Description
        public string desc { set; get; }
        //List of services belonging to one category
        public List<Service> services { set; get; }
    }
}
