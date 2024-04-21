using Microsoft.AspNetCore.Mvc;
using Shop.interfaces;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    //Inheritance from controller class
    public class HomeController : Controller
    {
        private IAllServices _serviceRep;
        
        public HomeController(IAllServices serviceRep)
        {
            _serviceRep = serviceRep;
        }

        //Create a function that returns a template
        public ViewResult Index()
        {
            //We create a service object that will be displayed on the main page
            var homeServices = new HomeViewModel
            {
                favServices = _serviceRep.getFavServices
            };
            return View(homeServices);
        }
    }
}
