using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication21.Models
{
    public class SinavTakvimi
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Ders Adı")]
        public Dersler? Derss { get; set; }

        [ForeignKey("Derss")]
        public int DerssId { get; set; }

        [DisplayName("Sınavın Yapılacağı Sınıf")]
        public int sinifno { get; set; }

        [DisplayName("Tarih")]
        public DateTime tarih { get; set; }
    }
}
