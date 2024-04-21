using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    //A model that describes the entire basket
    public class ShopCart
    {
        //Connecting to the database, including the AppDBContent file
        private readonly AppDBContent appDBContent;

        public ShopCart(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public string ShopCartId { get; set; }

        //List of all items inside a cart based on the ShopCartItem model
        public List<ShopCartItem> listShopItems { get; set; }

        //This function determines the start of the session if a service has been added to the cart 
        public static ShopCart GetCart(IServiceProvider services)
        {
            //We connect a class to work with sessions. Create a new session
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            //Getting tables from the database
            var context = services.GetService<AppDBContent>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            //Create a new session and assign a value to it
            session.SetString("CartId", shopCartId);
            //We return an object inside which the context variable connecting AppDBContent is passed
            return new ShopCart(context) { ShopCartId = shopCartId };
        }
        //This feature allows you to add services to your cart
        public void AddToCart(Service service)
        {
            appDBContent.ShopCartItem.Add(new ShopCartItem
            {
                ShopCartId = ShopCartId,
                service = service,
                price = service.price
            });
            //Saving data
            appDBContent.SaveChanges();
        }
        //This function allows you to display all services in the cart
        public List<ShopCartItem> getShopItems()
        {
            return appDBContent.ShopCartItem.Where(c => c.ShopCartId == ShopCartId).Include(s => s.service).ToList();
        }
    }
}