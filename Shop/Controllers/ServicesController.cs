using Microsoft.AspNetCore.Mvc;
using Shop.interfaces;
using Shop.Models;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class ServicesController : Controller
    {
        //Calling any function will return an html page
        //Two variables from interfaces
        private readonly IAllServices _allServices;
        private readonly IServicesCategory _allCategories;

        //Writing data to variables via the constructor
        public ServicesController(IAllServices iAllServices, IServicesCategory iServicesCat)
        {
            _allServices = iAllServices;
            _allCategories = iServicesCat;
        }
        //We indicate the URL address at which this function will work
        [Route("Services/List")]
        [Route("Services/List/{category}")]
        //The method returns the entire html page. List of all services.
        public ViewResult List(string category) {
            //Create a variable that includes the parameter
            string _category = category;
            //We will put all services here
            IEnumerable<Service> services = null;
            string currCategory = "";
            //If the category line is completely empty, then all services will be displayed
            if (string.IsNullOrEmpty(category))
            {
                //Sort by id
                services = _allServices.Services.OrderBy(i => i.id);
            }
            else
            {
                //If the string is equal to the word "assembly" then "Equipment assembly" will be printed. Case-insensitive
                if (string.Equals("assembly", category, StringComparison.OrdinalIgnoreCase))
                {
                    services = _allServices.Services.Where(i => i.Category.categoryName.Equals("Equipment assembly")).OrderBy(i => i.id);
                    currCategory = "Equipment assembly";
                }
                //If the string is equal to the word "software" then "Software" will be printed. Case-insensitive
                else if (string.Equals("software", category, StringComparison.OrdinalIgnoreCase))
                {
                    services = _allServices.Services.Where(i => i.Category.categoryName.Equals("Software")).OrderBy(i => i.id);
                    currCategory = "Software";
                }

                
            }
            //Create an object
            var serviceObj = new ServicesListViewModel
            {
                allServices = services,
                currCategory = currCategory
            };

            ViewBag.Title = "Services page";

            //Returning the html page
            return View(serviceObj);
        }
    }
}
