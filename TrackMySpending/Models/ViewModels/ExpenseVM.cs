using Microsoft.AspNetCore.Mvc.Rendering;

namespace TrackMySpending.Models.ViewModels
{
    public class ExpenseVM
    {
        public Expenses Expenses { get; set; }
        public IEnumerable<SelectListItem> ExpenseTypeDropDown { get; set; }
        public IEnumerable<SelectListItem> BorrowedItemDropDown { get; set; }
    }
}
