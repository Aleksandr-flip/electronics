using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

//Creating a model with fields for entering registration data

namespace Shop.Models
{
    public class Order
    {
        //This field will not appear on the page
        [BindNever]
        public int id { get; set; }

        [Display(Name = "Enter your name")] //Display name
        [StringLength(25)]                  //Maximum number of characters
        [Required(ErrorMessage = "Enter your name")] //Error message
        public string name { get; set; }

        [Display(Name = "Enter last name")] //Display name
        [StringLength(25)]                  //Maximum number of characters
        [Required(ErrorMessage = "Enter last name")] //Error message
        public string surname { get; set; }

        [Display(Name = "Enter address")] //Display name
        [StringLength(35)]                //Maximum number of characters
        [Required(ErrorMessage = "Enter address")] //Error message
        public string adress { get; set; }

        [Display(Name = "Enter phone number")] //Display name
        [DataType(DataType.PhoneNumber)]       //Data type
        [StringLength(20)]                     //Maximum number of characters  
        [Required(ErrorMessage = "Enter phone number")] //Error message
        public string phone { get; set; }

        [Display(Name = "Enter Email")] //Display name
        [DataType(DataType.EmailAddress)] //Data type
        [StringLength(25)]              //Maximum number of characters
        [Required(ErrorMessage = "Enter Email")] //Error message
        public string email { get; set; }

        //This field will not appear on the page
        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime orderTime { get; set; }

        public List<OrderDetail> orderDetails { get; set; }
    }
}
