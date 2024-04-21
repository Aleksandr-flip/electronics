using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    //The model describes the services
    public class Service
    {
        //Unique service identifier
        public int id { set; get; }
        //Service name
        public string name { set; get; }
        //A short description of the service
        public string shortDesc { set; get; }
        //Long description of the service
        public string longDesc { set; get; }
        //Url address of the service image
        public string img { set; get; }
        //Service price
        public ushort price { set; get; }
        //Services displayed on the main page
        public bool isFavourit { set; get; }
        //Number of services available
        public bool available { set; get; }
        //Unique identifier of the category to which the service is assigned
        public int categoryID { set; get; }
        //The category to which the service is assigned
        public virtual Category Category { set; get; }

    }
}
