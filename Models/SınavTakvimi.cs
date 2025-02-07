using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication21.Models
{
    public class SınavTakvimi
    {
        [Key]

        public int Id { get; set; }

        [DisplayName("Ders Adı")]
        public int DerssId { get; set; }
        [ForeignKey("DerssId")]
        public Dersler? Derss { get; set; }



        [DisplayName("Sınavın Yapılacağı Sınıf")]
        public int sinifno { get; set; }


    [DisplayName("Tarih")]
        public DateTime tarih { get; set; }

        internal static async Task<string?> ToListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
