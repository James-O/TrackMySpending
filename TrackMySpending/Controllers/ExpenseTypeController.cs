using Microsoft.AspNetCore.Mvc;
using TrackMySpending.Models;
using TrackMySpending.Data;

namespace TrackMySpending.Controllers
{
    public class ExpenseTypeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ExpenseTypeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<ExpenseType> expenses = _db.ExpenseTypes;
            return View(expenses);
        }
        //Get Create
        public IActionResult Create()
        {
            return View();
        }
        //Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ExpenseType expense)
        {
            if (ModelState.IsValid)
            {
                _db.ExpenseTypes.Add(expense);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expense);
            
        }
        //Get Update
        public IActionResult Update(int? id)
        {
            var update = _db.ExpenseTypes.Find(id);
            if(update != null)
            {
                return View(update);
            }
            return NotFound();
        }
        //GPost Update
        [HttpPost]
        public IActionResult Update(ExpenseType expense)
        {
            if(expense == null)
            {
                return NotFound();
            }
            _db.ExpenseTypes.Update(expense);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int? id)
        {
           var del = _db.ExpenseTypes.Find(id);
            if(del == null)
            {
                return NotFound();
            }
            _db.ExpenseTypes.Remove(del);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
