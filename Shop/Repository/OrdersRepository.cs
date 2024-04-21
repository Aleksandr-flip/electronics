using Shop.interfaces;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Repository
{
    //This class will implement the IAllOrders interface. 
    public class OrdersRepository : IAllOrders
    {
        //We create two variables with the corresponding classes.
        private readonly AppDBContent appDBContent;
        private readonly ShopCart shopCart;

        //We create a constructor with the same name as the class. Takes two parameters and sets our two values in them as variables.
        public OrdersRepository(AppDBContent appDBContent, ShopCart shopCart)
        {
            this.appDBContent = appDBContent;
            this.shopCart = shopCart;
        }

        public void createOrder(Order order)
        {
            //We set the order time to whatever it is at the moment. And add the order to the Order table.
            order.orderTime = DateTime.Now;
            appDBContent.Order.Add(order);

            //We create a variable that will store the services that the user purchases.
            var items = shopCart.listShopItems;

            //Let's go through the items. Each time we create a new object in the orderDetail variable based on the OrderDetail class. The necessary parameters are specified.
            foreach (var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    ServiceID = el.service.id,
                    orderID = order.id,
                    price = el.service.price
                };

                //After each creation, the object is added to the database.
                appDBContent.OrderDetail.Add(orderDetail);
            }
            //We save all settings to the database.
            appDBContent.SaveChanges();
        }
    }
}
