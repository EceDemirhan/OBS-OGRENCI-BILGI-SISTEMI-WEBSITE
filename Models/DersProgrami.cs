using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication21.Models
{
    public class DersProgrami
    {
        [Key]

        public int Id { get; set; }
        [DisplayName("Ders Adı")]

        public Dersler Dersler { get; set; }
        [ForeignKey("Dersler")]
        public int DersId { get; set; }

        [DisplayName("Tarih")]
        public DateTime tarih { get; set; }
    }
}
