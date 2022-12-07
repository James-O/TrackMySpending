using MessagePack;
using Microsoft.Build.Framework;

namespace TrackMySpending.Models
{
    public class Item
    {
        public int Id { get; set; }
        [Required]
        public string Borrower { get; set; }
        [Required]
        public string Lender { get;set; }
        [Required]
        public string ItemName { get; set; }
    }
}
