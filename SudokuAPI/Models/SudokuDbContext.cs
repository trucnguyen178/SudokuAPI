using Microsoft.EntityFrameworkCore;

namespace SudokuAPI.Models
{
    public class SudokuDbContext : DbContext
    {
        public SudokuDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<SudokuHistory> SudokuHistories { get; set; }
    }
}
