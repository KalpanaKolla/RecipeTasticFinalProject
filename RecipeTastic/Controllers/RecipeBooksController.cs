using RecipeTastic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecipeTastic.ViewModels;

namespace RecipeTastic.Controllers
{
    public class RecipeBooksController : Controller
    {
        private ApplicationDbContext _context;
        public RecipeBooksController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult New()
        {
            var cuisines = _context.Cuisines.ToList();
            var viewModel = new RecipeBookViewModel
            {
                RecipeBook = new RecipeBook(),
                Cuisines = cuisines
            };
            return View("RecipeBookForm", viewModel);
        }
        // GET: Customers
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(RecipeBook recipeBook)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new RecipeBookViewModel
                {
                    RecipeBook = recipeBook,
                    Cuisines = _context.Cuisines.ToList()
                };
                return View("RecipeBookForm", viewModel);
            }
            if (recipeBook.RecipeBookId == 0)
            {
                _context.RecipeBooks.Add(recipeBook);
            }
            else
            {
                var recipeBookInDb = _context.RecipeBooks.Single(c => c.RecipeBookId == recipeBook.RecipeBookId);
                recipeBookInDb.RecipeTitle = recipeBook.RecipeTitle;
                recipeBookInDb.Ingredients = recipeBook.Ingredients;
                recipeBookInDb.CuisineId = recipeBook.CuisineId;
                recipeBookInDb.ReadyInMinutes = recipeBook.ReadyInMinutes;
                recipeBookInDb.Servings = recipeBook.Servings;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "RecipeBooks");
        }
        
        public ActionResult Edit(int recipeBookId)
        {
            var recipeBook = _context.RecipeBooks.SingleOrDefault(c => c.RecipeBookId == recipeBookId);
            if (recipeBook == null)
                return HttpNotFound();
            var viewModel = new RecipeBookViewModel
            {
                RecipeBook = recipeBook,
                Cuisines = _context.Cuisines.ToList()
            };
            return View("RecipeBookForm", viewModel);
        }
    }
}