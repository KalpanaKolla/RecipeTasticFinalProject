using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeTastic.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        
        public Cuisine Cuisine { get; set; }
        public int CuisineId { get; set; }

        public MealType MealType { get; set; }
        public int MealTypeId { get; set; }
        
        public DateTime MealDate { get; set; }
    }
}



    