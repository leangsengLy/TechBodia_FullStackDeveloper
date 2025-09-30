using Microsoft.EntityFrameworkCore;
using Project_API_Note.Model;

namespace Project_API_Note
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<LSNOTE> LSNOTEs { get; set; }
        public DbSet<LSUSER_LOGIN> LSUSER_LOGINs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LSNOTE>().ToTable("LSNOTE");
            modelBuilder.Entity<LSUSER_LOGIN>().ToTable("LSUSER_LOGIN");
        }
    }
}
