using System;
using System.Windows.Forms;
using HastaneOtomasyonu.BLL;
using HastaneOtomasyonu.Entities;

namespace HastaneOtomasyonu.UI
{
    public partial class HastaForm : Form
    {
        private HastaBLL hastaBLL = new HastaBLL();

        public HastaForm()
        {
            InitializeComponent();
            LoadHastalar();
        }

        private void LoadHastalar()
        {
            dataGridViewHastalar.DataSource = hastaBLL.GetAllHastalar();
        }

        private void btnHastaEkle_Click(object sender, EventArgs e)
        {
            Hasta hasta = new Hasta
            {
                Ad = txtAd.Text,
                Soyad = txtSoyad.Text,
                TCKimlikNo = txtTCKimlikNo.Text,
                Telefon = txtTelefon.Text,
                Adres = txtAdres.Text
            };

            if (hastaBLL.AddHasta(hasta))
            {
                MessageBox.Show("Hasta eklendi!");
                LoadHastalar();
            }
            else
            {
                MessageBox.Show("Hata: Lütfen bilgileri kontrol edin.");
            }
        }
    }
}
