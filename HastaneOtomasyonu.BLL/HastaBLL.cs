using System.Data;
using HastaneOtomasyonu.DAL;
using HastaneOtomasyonu.Entities;

namespace HastaneOtomasyonu.BLL
{
    public class HastaBLL
    {
        private HastaDAL hastaDAL = new HastaDAL();

        public DataTable GetAllHastalar()
        {
            return hastaDAL.GetAllHastalar();
        }

        public bool AddHasta(Hasta hasta)
        {
            if (string.IsNullOrEmpty(hasta.Ad) || string.IsNullOrEmpty(hasta.TCKimlikNo))
                return false;

            return hastaDAL.AddHasta(hasta) > 0;
        }
    }
}
