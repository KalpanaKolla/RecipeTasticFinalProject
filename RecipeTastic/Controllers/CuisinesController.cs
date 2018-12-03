using RecipeTastic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecipeTastic.Controllers
{
    public class CuisinesController : Controller
    {
        private ApplicationDbContext _context;
        public CuisinesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Items
        public ActionResult Index()
        {
            List<SelectListItem> cuisineList = new List<SelectListItem>();
            cuisineList.Add(new SelectListItem { Text = "Select Cuisine", Value = "0", Selected = true });
            var cuisines = _context.Cuisines.ToList();
            foreach (var c in cuisines)
            {
                cuisineList.Add(new SelectListItem { Text = c.CuisineName, Value = Convert.ToString(c.CuisineId) });
            }
            ViewBag.CuisineList = cuisineList;
            return View();
        }
        public JsonResult GetItemsByCuisineID(int cuisineId)
        {
            List<Item> items = new List<Item>();
            items = _context.Items.Where(x => x.CuisineId == cuisineId).ToList();

            return Json(items, JsonRequestBehavior.AllowGet);
        }
    }
}