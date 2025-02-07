using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication21.Models;


namespace WebApplication21.Models
{
    public class FDbContext : IdentityDbContext<ApplicationUser>
    {
        public FDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<WebApplication21.Models.Ogretmen>? Ogretmen { get; set; }
        public DbSet<WebApplication21.Models.Dersler>? Dersler { get; set; }
        public DbSet<WebApplication21.Models.Ogrenci>? Ogrenci { get; set; }
        public DbSet<WebApplication21.Models.Notlar>? Notlar { get; set; }
        public DbSet<WebApplication21.Models.DersProgrami>? DersProgrami { get; set; }
        public DbSet<WebApplication21.Models.SınavTakvimi>? SınavTakvimi { get; set; }
        


    }
}