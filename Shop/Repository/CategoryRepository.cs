using Shop.interfaces;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Repository
{
    //Connecting the AppDBContent file and getting data from it
    public class CategoryRepository : IServicesCategory
    {
        private readonly AppDBContent appDBContent;

        public CategoryRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        //We access appDBContent and get all categories
        public IEnumerable<Category> AllCategories => appDBContent.Category;
    }
}
