using System;
using System.Data;
using System.Data.SqlClient;
using HastaneOtomasyonu.Entities;

namespace HastaneOtomasyonu.DAL
{
    public class HastaDAL
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HastaneDB;Integrated Security=True;";

        public DataTable GetAllHastalar()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Hastalar", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public int AddHasta(Hasta hasta)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Hastalar (Ad, Soyad, TCKimlikNo, Telefon, Adres) " +
                    "VALUES (@Ad, @Soyad, @TCKimlikNo, @Telefon, @Adres)", conn);
                cmd.Parameters.AddWithValue("@Ad", hasta.Ad);
                cmd.Parameters.AddWithValue("@Soyad", hasta.Soyad);
                cmd.Parameters.AddWithValue("@TCKimlikNo", hasta.TCKimlikNo);
                cmd.Parameters.AddWithValue("@Telefon", hasta.Telefon);
                cmd.Parameters.AddWithValue("@Adres", hasta.Adres);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
