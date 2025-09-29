using Microsoft.EntityFrameworkCore;
using Project_API_Note.Model;

namespace Project_API_Note
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<LSNOTE> LSNOTEs { get; set; }
    }
}
