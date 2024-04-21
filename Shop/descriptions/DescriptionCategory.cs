using Shop.interfaces;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.descriptions
{
    //Temporary storage of the list of categories before creating the database
    public class DescriptionCategory : IServicesCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                //Returning a list of categories
                return new List<Category>
                {
                    //Individual objects based on the Category class
                    new Category { categoryName = "Equipment assembly", desc = "Assembly services for specialized electronic equipment"},
                    new Category { categoryName = "Software", desc = "Software installation and testing"}
                };
            }
        }
    }
}
