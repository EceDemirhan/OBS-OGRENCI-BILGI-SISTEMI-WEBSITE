using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication21.Models
{
    public class Ogretmen
    {

        [Key]
        public int Id { get; set; }
        [DisplayName("Ad")]
        [Required]
        public string Adi { get; set; }
        [DisplayName("Soyad")]
        [Required]
        public string Soyadi { get; set; }
        [DisplayName("E mail")]
        public string email { get; set; }

        [DisplayName("Ders Adı")]
        public Dersler Ders { get; set; }
        [Required]
        public int DersId { get; set; }
        
        
    }
}
