using System.ComponentModel.DataAnnotations;

namespace RecipeTastic.Models
{
    public class Cuisine
    {
        public int CuisineId { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name ="Cuisine")]
        public string CuisineName { get; set; }
    }
}