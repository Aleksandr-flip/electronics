using Shop.interfaces;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.descriptions
{
    //Temporary storage of the list of services before creating the database
    public class DescriptionServices : IAllServices {
        //A variable that refers to the DescriptionCategory class and calls the desired list element
        private readonly IServicesCategory _categoryServices = new DescriptionCategory();

        public IEnumerable<Service> Services {
            get {
                //We return the list of services
                return new List<Service>
                {
                    //Individual objects based on the Service class
                    new Service {
                        //Service name
                        name = "Cable assembly",
                        //A short description of the service
                        shortDesc = "Assembly and testing of connecting cables",
                        //Long description of the service
                        longDesc = "Assembly and testing of connecting cables",
                        //Url address of the service image
                        img = "/img/1559021864_15.jpg",
                        //Service price
                        price = 2000,
                        //Services displayed on the main page
                        isFavourit = true,
                        //Number of services available
                        available = true,
                        //The category to which the service is assigned
                        Category = _categoryServices.AllCategories.First()
                    },
                    new Service {
                        name = "Software installation",
                        shortDesc = "Installing software on various electronic modules",
                        longDesc = "Installing software on various electronic modules",
                        img = "/img/1559021927_37.jpg",
                        price = 1500,
                        isFavourit = false,
                        available = true,
                        Category = _categoryServices.AllCategories.Last()
                    },
                    new Service {
                        name = "Assembly of electronic modules",
                        shortDesc = "Assembly of individual electronic equipment modules",
                        longDesc = "Assembly of individual electronic equipment modules",
                        img = "/img/1559021804_2.jpg",
                        price = 3200,
                        isFavourit = true,
                        available = true,
                        Category = _categoryServices.AllCategories.First()
                    },
                    new Service {
                        name = "Complete assembly of final equipment",
                        shortDesc = "The final stage of assembling the final equipment ready for operation",
                        longDesc = "The final stage of assembling the final equipment ready for operation",
                        img = "/img/1559021902_12.jpg",
                        price = 5000,
                        isFavourit = false,
                        available = false,
                        Category = _categoryServices.AllCategories.First()
                    },
                    new Service {
                        name = "Testing of electronic modules",
                        shortDesc = "Identifying problems in the operation of individual electronic modules",
                        longDesc = "Identifying problems in the operation of individual electronic modules",
                        img = "/img/1559021828_8.jpg",
                        price = 2200,
                        isFavourit = true,
                        available = true,
                        Category = _categoryServices.AllCategories.Last()
                    }
                };
              }
        
        }
        public IEnumerable<Service> getFavServices { get; set; }

        public Service getObjectService(int serviceId)
        {
            throw new NotImplementedException();
        }
    }
}
