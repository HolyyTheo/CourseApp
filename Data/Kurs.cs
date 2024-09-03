using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace efcoreApp.Data
{
    public class Kurs
    {
        [Key]
        
        public int KursId { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Başlık")]
        public string? Baslik { get; set; }
        public int OgretmenId { get; set; }
        public Ogretmen Ogretmen { get; set; } = null!;
        public ICollection<KursKayit> KursKayitlari { get; set; } = new List<KursKayit>();

    }
}