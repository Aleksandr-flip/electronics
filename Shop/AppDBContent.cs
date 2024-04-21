using Microsoft.EntityFrameworkCore;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop
{
    //The class is used to work with databases
    public class AppDBContent : DbContext
    {
        //Create a default constructor. Pass data to the base constructor
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options)
        {

        }
        //Registering the tables that will be in the database

        public DbSet<Service> Service { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ShopCartItem> ShopCartItem { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
    }
}
