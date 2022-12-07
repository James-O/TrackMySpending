using Microsoft.AspNetCore.Mvc;
using TrackMySpending.Models;
using TrackMySpending.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrackMySpending.Models.ViewModels;

namespace TrackMySpending.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ExpensesController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Expenses> expenses = _db.Expenses;
            foreach(var exp in expenses)
            {
                exp.ExpenseType = _db.ExpenseTypes.FirstOrDefault(a => a.Id == exp.ExpenseTypeId);
            };
            foreach(var item in expenses)
            {
                item.Item = _db.Items.FirstOrDefault(b => b.Id == item.ItemId);
            };
            return View(expenses);
        }
        //Get Create
        public IActionResult Create()
        {
            //IEnumerable<SelectListItem> ExpenseTypeDropDown = _db.ExpenseTypes.Select(a => new SelectListItem
            //{
            //    Text = a.Name,
            //    Value = a.Id.ToString()
            //});
            //ViewBag.ExpenseTypeDropDown = ExpenseTypeDropDown;
            ExpenseVM expenseVM = new ExpenseVM()//objt of the vm
            {
                Expenses = new Expenses(),//objt of vm ppties
                ExpenseTypeDropDown = _db.ExpenseTypes.Select(a => new SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString()
                }),
                BorrowedItemDropDown = _db.Items.Select(b=>new SelectListItem { Text=b.ItemName, Value=b.Id.ToString()})

            };
            return View(expenseVM);
        }
        //Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public IActionResult Create(Expenses expense)
        public IActionResult Create(ExpenseVM expense)
        {
            //if (ModelState.IsValid)
            //{
            /*_db.Expenses.Add(expense)*/
                _db.Expenses.Add(expense.Expenses);
                _db.SaveChanges();
                return RedirectToAction("Index");
            //}
            //return View(expense);
            
        }
        //Get Update
        public IActionResult Update(int? id)
        {
            //IEnumerable<SelectListItem> ExpenseTypeDropDown = _db.ExpenseTypes.Select(a => new SelectListItem
            //{
            //    Text = a.Name,
            //    Value = a.Id.ToString()
            //});
            //ViewBag.ExpenseTypeDropDown = ExpenseTypeDropDown;
            ExpenseVM expenseVM = new ExpenseVM()
            {
                Expenses = new Expenses(),
                ExpenseTypeDropDown = _db.ExpenseTypes.Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString() })
            };

            //var update = _db.Expenses.Find(id);
            expenseVM.Expenses = _db.Expenses.Find(id);
            if(expenseVM.Expenses != null)
            {
                return View(expenseVM);
            }
            return NotFound();
        }
        //GPost Update
        [HttpPost]
        public IActionResult Update(ExpenseVM expense)
        {
            if(expense.Expenses == null)
            {
                return NotFound();
            }
            _db.Expenses.Update(expense.Expenses);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int? id)
        {
           var del = _db.Expenses.Find(id);
            if(del == null)
            {
                return NotFound();
            }
            _db.Expenses.Remove(del);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
