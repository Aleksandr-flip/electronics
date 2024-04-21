using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.ViewModels
{
    public class ServicesListViewModel
    {
        //A function that will receive all services
        public IEnumerable<Service> allServices { get; set; }
        //We will place the category we are working with in this variable 
        public string currCategory { get; set; }
    }
}
