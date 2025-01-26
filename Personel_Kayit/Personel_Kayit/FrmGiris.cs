using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Personel_Kayit
{
    public partial class FrmGiris : Form
    {
        SqlConnection SqlConnection = new SqlConnection("Data Source=Ozan;Initial Catalog=PersonelVeriTabanı;Integrated Security=True;");

        public FrmGiris()
        {
            InitializeComponent();
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            SqlConnection.Open();
            SqlCommand command = new SqlCommand("select * from Tbl_Yonetici where KullaniciAd=@p1 and Sifre=@p2", SqlConnection);
            command.Parameters.AddWithValue("@p1", txtKullaniciAd.Text);
            command.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                FrmAnaForm frmAnaForm = new FrmAnaForm();
                frmAnaForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre");
            }
            SqlConnection.Close();
        }
    }
}
