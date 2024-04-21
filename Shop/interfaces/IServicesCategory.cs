using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.interfaces
{
    //The interface is responsible for receiving data of all categories
    public interface IServicesCategory
    {
        //The function returns all categories from the Category model
        IEnumerable<Category> AllCategories { get; }

    }
}
