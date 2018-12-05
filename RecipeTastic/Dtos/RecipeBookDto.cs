using Microsoft.AspNet.Identity;
using RecipeTastic.Models;
using System.Web;

namespace RecipeTastic.Dtos
{
    public class RecipeBookDto
    {
        public int RecipeBookId { get; set; }
        public string RecipeTitle { get; set; }

        public Cuisine Cuisine { get; set; }
        public int CuisineId { get; set; }

        public string Ingredients { get; set; }
        public int ReadyInMinutes { get; set; }
        public int Servings { get; set; }

        public string UserId { get; set; } = HttpContext.Current.User.Identity.GetUserName();
    }
}