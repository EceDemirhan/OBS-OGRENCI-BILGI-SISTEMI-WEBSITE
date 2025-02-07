using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication21.Models
{
    public class Ogrenci
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Ad")]
        [Required]
        public string Adi { get; set; }
        [DisplayName("Soyad")]
        [Required]
        public string Soyadi { get; set; }
        [DisplayName("Sınıf")]
        public int sinif { get; set; }
        [DisplayName("E mail")]
        public string email { get; set; }
        [DisplayName("Cinsiyet")]
        public string cinsiyet { get; set; }

        [DisplayName("Fotoğraf")]
       
        public string Fotograf { get; set; }
        [NotMapped]
        [DisplayName("Upload Image File")]

        public IFormFile ImageFile { get; set; }
    }
}