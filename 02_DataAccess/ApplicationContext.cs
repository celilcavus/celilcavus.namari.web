using _01_EntityLayer;
using Microsoft.EntityFrameworkCore;

namespace _02_DataAccess
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Admin>? Admins { get; set; }
        public DbSet<About>? Abouts { get; set; }
        public DbSet<Clients>? Clients { get; set; }
        public DbSet<Customers>? Customers { get; set; }
        public DbSet<Galery>? Galeries { get; set; }
        public DbSet<Home>? Homes { get; set; }
        public DbSet<Pricing>? Pricings { get; set; }
        public DbSet<Services>? Services { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = D:\\Software\\WinMvc\\celilcavus.namari.web\\NamariDb.db");
        }
    }
}
