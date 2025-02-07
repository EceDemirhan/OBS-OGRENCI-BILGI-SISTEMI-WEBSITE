using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication21.Models
{
    public class Dersler
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Ders Adı")]
        [Required]
        public string DersAdi { get; set; }

        
        

        [DisplayName("AKTS")]
        public int akts { get; set; }
        [DisplayName("Ders Kredisi")]
        public int kredi { get; set; }
    }
}


