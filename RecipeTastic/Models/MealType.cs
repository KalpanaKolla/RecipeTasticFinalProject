using System.ComponentModel.DataAnnotations;

namespace RecipeTastic.Models
{
    public class MealType
    {
        public int MealTypeId { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name ="Meal Type")]
        public string MealTypeName { get; set; }
    }
}