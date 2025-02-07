using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication21.Models
{
    public class Notlar
    {
        [Key]

        public int Id { get; set; }


        public Ogrenci? Ogrenci { get; set; }
        public int OgrenciId { get; set; }


        public Dersler? Dersler { get; set; }
        public int DerslerId { get; set; }

        [DisplayName("Not ")]
        public int Not { get; set; }
        [DisplayName("Açıklama")]
        public string result { get; set; }
    }
}
