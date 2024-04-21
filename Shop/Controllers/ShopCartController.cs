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
    //The controller binds the model and the template
    public class ShopCartController : Controller
    {
        private IAllServices _serviceRep;
        private readonly ShopCart _shopCart;

        public ShopCartController(IAllServices serviceRep, ShopCart shopCart)
        {
            _serviceRep = serviceRep;
            _shopCart = shopCart;
        }
        //This function allows you to display the shopping cart
        public ViewResult Index()
        {
            var items = _shopCart.getShopItems();
            //We install all services in the general list
            _shopCart.listShopItems = items;

            var obj = new ShopCartViewModel
            {
                shopCart = _shopCart
            };

            return View(obj);
        }
        //This function will redirect to another page
        public RedirectToActionResult addToCart(int id)
        {
            //Selecting the desired service from the list of all services from the database by its id
            var item = _serviceRep.Services.FirstOrDefault(i => i.id == id);
            if(item != null)
            {
                _shopCart.AddToCart(item);
            }
            //When clicking on the "add service" button, the user will be redirected to the cart page
            return RedirectToAction("Index");
        }
    }
}
