using Microsoft.AspNet.Identity;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace RecipeTastic.Models
{
    public class RecipeBook
    {
        public int RecipeBookId { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name ="Recipe Name")]
        public string RecipeTitle { get; set; }

        public Cuisine Cuisine { get; set; }
        [Display(Name ="Cuisine")]
        public int CuisineId { get; set; }

        public string Ingredients { get; set; }

        [Display(Name ="Ready In Minutes")]
        public int ReadyInMinutes { get; set; }

        public int Servings { get; set; }

        public string UserId { get; set; } = HttpContext.Current.User.Identity.GetUserName();
    }
}