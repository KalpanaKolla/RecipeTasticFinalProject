using Newtonsoft.Json;
using RecipeTastic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace RecipeTastic.Controllers
{
    public class RecipesController : Controller
    {
        // GET: Recipes
        public async System.Threading.Tasks.Task<ViewResult> Index(string ingredients)
        {
            List<RecipeByIngredient> RecipeInfo = new List<RecipeByIngredient>();
            var response = await SearchRecipeAsync(ingredients);
            RecipeInfo = JsonConvert.DeserializeObject<List<RecipeByIngredient>>(response);

            return View(RecipeInfo);
        }

        [HttpGet]
        private async System.Threading.Tasks.Task<string> SearchRecipeAsync(string ingredients)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "2f25c0629emsh890d8cd03a76a6ep18369cjsn37d5813e6ed2");
                var response = await client.GetStringAsync("https://spoonacular-recipe-food-nutrition-v1.p.rapidapi.com/recipes/findByIngredients?number=5&ranking=1&ingredients=" + ingredients);

                return response;
            }
        }
    }
}