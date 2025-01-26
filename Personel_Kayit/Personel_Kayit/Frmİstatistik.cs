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
    public partial class Frmİstatistik : Form
    {
        SqlConnection SqlConnection = new SqlConnection("Data Source=Ozan;Initial Catalog=PersonelVeriTabanı;Integrated Security=True;");
        public Frmİstatistik()
        {
            InitializeComponent();
        }

        private void Frmİstatistik_Load(object sender, EventArgs e)
        {
            //Toplam Personel Sayısı
            SqlConnection.Open();
            SqlCommand command1 = new SqlCommand("select count(*) from Tbl_Personel", SqlConnection);
            SqlDataReader dr = command1.ExecuteReader();//Select işlemleri için kullanılır
            
            while (dr.Read())
            {
                lblToplamPersonel.Text = dr[0].ToString();
            }
            SqlConnection.Close();


            //Bekar Olan Personel Sayısı Toplamı
            SqlConnection.Open();
            SqlCommand command3 = new SqlCommand("select count(*) from Tbl_Personel Where PerDurum=0", SqlConnection);
            SqlDataReader dr3 = command3.ExecuteReader();

            while (dr3.Read())
            {
                lblBekarPersonelSayisi.Text = dr3[0].ToString();
            }
            SqlConnection.Close();


            //Evli Olan Personel Sayısı Toplamı
            SqlConnection.Open();
            SqlCommand command2 = new SqlCommand("select count(*) from Tbl_Personel Where PerDurum=1", SqlConnection);
            SqlDataReader dr2 = command2.ExecuteReader();

            while (dr2.Read())
            {
                lblEvliPersonelSayisi.Text = dr2[0].ToString();
            }
            SqlConnection.Close();



            //Şehir Sayısı
            SqlConnection.Open();
            SqlCommand command4 = new SqlCommand("select count(distinct (PerSehir)) from Tbl_Personel", SqlConnection);
            SqlDataReader dr4 = command4.ExecuteReader();

            while (dr4.Read())
            {
                lblSehirSayisi.Text = dr4[0].ToString();
            }
            SqlConnection.Close();


            //Toplam Maaş
            SqlConnection.Open();
            SqlCommand command5 = new SqlCommand("Select Sum(PerMaas) from Tbl_Personel", SqlConnection);
            SqlDataReader dr5 = command4.ExecuteReader();

            while (dr5.Read())
            {
                lblToplamMaas.Text = dr5[0].ToString();
            }
            SqlConnection.Close();


            //Ortlama Maaş
            SqlConnection.Open();
            SqlCommand command6 = new SqlCommand("Select Avg(PerMaas) from Tbl_Personel", SqlConnection);
            SqlDataReader dr6 = command6.ExecuteReader();

            while (dr6.Read())
            {
                lblOrtalamaMaas.Text = dr6[0].ToString();
            }
            SqlConnection.Close();

        }


    }
}
