using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeTastic.Models
{
    public class Grocery
    {
        public int GroceryId { get; set; }
        public string GroceryName { get; set; }
        public string GroceryComment { get; set; }
        public string UserId { get; set; } = HttpContext.Current.User.Identity.GetUserName();
    }
}