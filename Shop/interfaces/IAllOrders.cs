using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.interfaces
{
    public interface IAllOrders
    {
        //We create an interface with a function for creating an order. It takes the Order class and the order parameter as a parameter.
        void createOrder(Order order);
    }
}
