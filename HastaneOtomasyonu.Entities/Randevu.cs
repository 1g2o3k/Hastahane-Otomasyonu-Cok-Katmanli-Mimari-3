using System;

namespace HastaneOtomasyonu.Entities
{
    public class Randevu
    {
        public int RandevuId { get; set; }
        public int HastaId { get; set; }
        public int DoktorId { get; set; }
        public DateTime Tarih { get; set; }
        public string Saat { get; set; }
    }
}
