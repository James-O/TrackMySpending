using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using TrackMySpending.Data;
using TrackMySpending.Models;

namespace TrackMySpending.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ItemController(ApplicationDbContext db) 
        { 
            _db = db; 
        }
        public IActionResult Index()
        {
            //IEnumerable<Item> item = _db.Items;
            //IEnumerable<Item> item = _db.Items.ToList();
            //var item = _db.Items.ToList();
            var item = _db.Items;
            return View(item);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item item)
        {
            if (ModelState.IsValid)
            {
                _db.Items.Add(item);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(item);
        }
    }
}
