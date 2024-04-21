using Microsoft.AspNetCore.Mvc;
using Shop.interfaces;
using Shop.Models;

//We create a controller that will inherit everything from the Controller class.
namespace Shop.Controllers
{
    public class OrderController : Controller
    {
        //We create two variables that access the IAllOrders interface and the ShopCart model.
        private readonly IAllOrders allOrders;
        private readonly ShopCart shopCart;

        public OrderController(IAllOrders allOrders, ShopCart shopCart)
        {
            this.allOrders = allOrders;
            this.shopCart = shopCart;
        }

        //We create a function that returns a form for entering user data. IActionResult allows you to receive data.
        public IActionResult Checkout()
        {
            return View();
        }

        //After clicking the Complete order button, the post method is called, which takes a parameter with the order
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            //We add services from the cart to the list
            shopCart.listShopItems = shopCart.getShopItems();
            //Action if there are no services in the cart
            if (shopCart.listShopItems.Count == 0)
            {
               return RedirectToAction("Empty");
            }
            //Action if there are services in the cart
            if (ModelState.IsValid)
            {
                allOrders.createOrder(order);
                return RedirectToAction("Complete");
            }
            return View(order);
        }
        //Message when there are services in the cart
        public IActionResult Complete()
        {
            ViewBag.Message = "Order processed successfully";
            return View();
        }

        //Message when there are no services in the cart
        public IActionResult Empty()
        {
            ViewBag.Message = "Service not selected!";
            return View();
        }
    }
}
