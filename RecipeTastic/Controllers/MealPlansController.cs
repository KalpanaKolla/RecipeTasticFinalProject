using RecipeTastic.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;


namespace RecipeTastic.Controllers
{
    public class MealPlansController : Controller
    {
        private ApplicationDbContext _context;
        public MealPlansController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: MealPlans
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetItems()
        {
            List<Item> items = new List<Item>();
            items = _context.Items.Include(i => i.MealType).ToListAsync().Result;
            return Json(items, JsonRequestBehavior.AllowGet);


        }
    }
}