using WebApplication21.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication21.Views;


namespace WebApplication21.DbContext
{
    public class DBContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Dersler>? Dersler { get; set; }
        public DbSet<Ogretmen>? Ogretmenler { get; set; }
        
       public DbSet<Ogrenci>? Ogrencilers { get; set; }

        public DbSet<DersProgrami>? DersProgrami { get; set; }




        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }

        public DbSet<WebApplication21.Models.Ogrenci>? Ogrenci { get; set; }

        public DbSet<WebApplication21.Models.Notlar>? Notlar { get; set; }

        public DbSet<WebApplication21.Models.SinavTakvimi>? SinavTakvimi { get; set; }

        

    }
}