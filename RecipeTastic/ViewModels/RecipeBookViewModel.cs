using RecipeTastic.Models;
using System.Collections.Generic;

namespace RecipeTastic.ViewModels
{
    public class RecipeBookViewModel
    {
        public IEnumerable<Cuisine> Cuisines { get; set; }
        public RecipeBook RecipeBook { get; set; }
        public string Title
        {
            get
            {
                if (RecipeBook != null && RecipeBook.RecipeBookId != 0)
                    return "Edit Recipe";
                else
                    return "New Recipe";
            }

        }
    }
}