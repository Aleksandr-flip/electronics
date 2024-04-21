using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    //A model that is responsible for each service inside the basket
    public class ShopCartItem
    {
        public int id { get; set; }
        public Service service { get; set; }
        public int price { get; set; }

        //Service ID inside the cart
        public string ShopCartId { get; set; }
    }
}
