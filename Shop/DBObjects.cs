using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop
{
    //Creating objects
    //All functions within a class are static so that they can be accessed from other classes by function name
    public class DBObjects
    {
        //The function will add objects to the database when the program starts
        public static void Initial(AppDBContent content)
        {
            //Add all categories to the database if there are no categories in the database
            if (!content.Category.Any())
                content.Category.AddRange(Categories.Select(c => c.Value));

            //Add all services to the database if there are no services in the database
            if (!content.Service.Any())
            {
                content.AddRange(
                    new Service
                    {
                        name = "Cable assembly",
                        shortDesc = "Assembly and testing of connecting cables",
                        longDesc = "Assembly and testing of connecting cables",
                        img = "/img/1559021864_15.jpg",
                        price = 2000,
                        isFavourit = true,
                        available = true,
                        Category = Categories["Equipment assembly"]
                    },
                    new Service
                    {
                        name = "Software installation",
                        shortDesc = "Installing software on various electronic modules",
                        longDesc = "Installing software on various electronic modules",
                        img = "/img/1559021927_37.jpg",
                        price = 1500,
                        isFavourit = false,
                        available = true,
                        Category = Categories["Software"]
                    },
                    new Service
                    {
                        name = "Assembly of electronic modules",
                        shortDesc = "Assembly of individual electronic equipment modules",
                        longDesc = "Assembly of individual electronic equipment modules",
                        img = "/img/1559021804_2.jpg",
                        price = 3200,
                        isFavourit = true,
                        available = true,
                        Category = Categories["Equipment assembly"]
                    },
                    new Service
                    {
                        name = "Complete assembly of final equipment",
                        shortDesc = "The final stage of assembling the final equipment ready for operation",
                        longDesc = "The final stage of assembling the final equipment ready for operation",
                        img = "/img/1559021902_12.jpg",
                        price = 5000,
                        isFavourit = false,
                        available = false,
                        Category = Categories["Equipment assembly"]
                    },
                    new Service
                    {
                        name = "Testing of electronic modules",
                        shortDesc = "Identifying problems in the operation of individual electronic modules",
                        longDesc = "Identifying problems in the operation of individual electronic modules",
                        img = "/img/1559021828_8.jpg",
                        price = 2200,
                        isFavourit = true,
                        available = true,
                        Category = Categories["Software"]
                    }
                    );
            }
            //We save all changes to the database
            content.SaveChanges();
        }
        private static Dictionary<string, Category> category;
        //The function returns a dictionary with two data types
        public static Dictionary<string, Category> Categories
        {
            get
            {
                //If there is nothing inside the variable, then we add new objects to the variable
                if (category == null)
                {
                    //Created a list, an array of objects
                    var list = new Category[]
                    {
                        //Categories that we place in the list and database if there are no objects in it
                        new Category { categoryName = "Equipment assembly", desc = "Assembly services for specialized electronic equipment"},
                        new Category { categoryName = "Software", desc = "Software installation and testing"}
                    };

                    //Allocating memory for a variable
                    category = new Dictionary<string, Category>();
                    //Inside this variable, through a loop, we add all the elements that are in the list array
                    //Each time we create a new variable and iterate through the list
                    foreach (Category el in list)
                        //For each iteration we add a new object to category
                        category.Add(el.categoryName, el);
                }
                //Return a list if it contains objects
                return category;
            }
        }
    }
}
