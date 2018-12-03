using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using RecipeTastic.Models;

namespace RecipeTastic.Controllers
{
    public class GroceriesController : Controller
    {
        private ApplicationDbContext _Context;
        public GroceriesController()
        {
            _Context = new ApplicationDbContext();

        }
        public ActionResult Index()
        {
            var Groceries = _Context.Groceries.ToList().Where(x => x.UserId == HttpContext.User.Identity.GetUserName());
            return View(Groceries);

        }
        public ActionResult New()
        {
            return View();
        }
        public ActionResult Add(Grocery grocery)
        {
            _Context.Groceries.Add(grocery);

            _Context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var grocery = _Context.Groceries.SingleOrDefault(g => g.GroceryId == id);
            if (grocery == null) return HttpNotFound(); return View(grocery);
        }

        [HttpPost]
        public ActionResult Update(Grocery Grocery)
        {
            var groceryInDb = _Context.Groceries.SingleOrDefault(g => g.GroceryId == Grocery.GroceryId);
            if (groceryInDb == null) return HttpNotFound();
            groceryInDb.GroceryName = Grocery.GroceryName;
            groceryInDb.GroceryComment = Grocery.GroceryComment;
            _Context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var grocery = _Context.Groceries.SingleOrDefault(g => g.GroceryId == id);
            if (grocery == null) return HttpNotFound();
            return View(grocery);
        }

        [HttpPost]
        public ActionResult DoDelete(Grocery Grocery)
        {
            var grocery = _Context.Groceries.SingleOrDefault(g => g.GroceryId == Grocery.GroceryId);
            if (grocery == null)
                return HttpNotFound();
            _Context.Groceries.Remove(grocery);
            _Context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}