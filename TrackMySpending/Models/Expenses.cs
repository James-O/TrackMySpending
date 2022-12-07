using Microsoft.AspNetCore.Cors;
//using Microsoft.Build.Framework;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackMySpending.Models
{
    public class Expenses
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Expense")]
        public string ExpenseName { get; set; }
        [Required]
        [Range(1,int.MaxValue, ErrorMessage ="Amount must be greater than 0!")]
        public double Amount { get;set; }

        [DisplayName("Expense Type")]
        public int ExpenseTypeId { get; set; }
        [ForeignKey("ExpenseTypeId")]
        public virtual ExpenseType ExpenseType { get; set; }

        [DisplayName("Item Borrowed")]
        public int ItemId { get; set; }
        [ForeignKey("ItemId")]
        public virtual Item Item { get; set; }

    }
}
