using System;
using System.ComponentModel.DataAnnotations;

namespace RecipeTastic.Models
{
    public class Item
    {
        public int ItemId { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name ="Recipe Name")]
        public string ItemName { get; set; }
        
        public Cuisine Cuisine { get; set; }
        [Display(Name ="Cuisine")]
        public int CuisineId { get; set; }

        public MealType MealType { get; set; }
        [Display(Name ="Meal Type")]
        public int MealTypeId { get; set; }
        
        [Display(Name ="Meal Date")]
        public DateTime? MealDate { get; set; }
    }
}



    