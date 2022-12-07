using Microsoft.EntityFrameworkCore;
using TrackMySpending.Models;

namespace TrackMySpending.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options)
            :base(options) { }
        public DbSet<Item> Items { get; set; }
        public DbSet<Expenses> Expenses { get; set; }
        public DbSet<ExpenseType> ExpenseTypes { get; set; }
    }
}
