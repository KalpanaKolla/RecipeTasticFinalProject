﻿
namespace RecipeTastic.Models
{
    public class RecipeByIngredient
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Image { get; set; }

        public string ImageType { get; set; }
        public int UsedIngredientCount { get; set; }
        public int MissedIngredientCount { get; set; }
        public int Likes { get; set; }
    }
}