using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebApplication21.Models;

namespace WebApplication21.Views
{
    public class DersProgrami
    {
        [Key]

        public int Id { get; set; }
        [DisplayName("Ders Adı")]

        public Dersler Dersler { get; set; }
        public int DersId { get; set; }

        [DisplayName("Öğretmen Adı")]
        public Ogretmen Ogretmen { get; set; }
        public int OgrId { get; set; }

        [DisplayName("Tarih")]
        public DateTime tarih { get; set; }
    }
}
