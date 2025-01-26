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
    public partial class FrmGrafikler : Form
    {
        SqlConnection SqlConnection = new SqlConnection("Data Source=Ozan;Initial Catalog=PersonelVeriTabanı;Integrated Security=True;");
        public FrmGrafikler()
        {
            InitializeComponent();
        }

        private void FrmGrafikler_Load(object sender, EventArgs e)
        {
            //Grafik 1
            SqlConnection.Open();
            SqlCommand command = new SqlCommand("select PerSehir, Count(*) from Tbl_Personel group by PerSehir", SqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                chart1.Series["Sehirler"].Points.AddXY(reader[0], reader[1]);
            }
            SqlConnection.Close();

            //Grafik 2
            SqlConnection.Open();
            SqlCommand command2 = new SqlCommand("select PerMeslek, avg(PerMaas) from Tbl_Personel group by PerMeslek", SqlConnection);
            SqlDataReader reader2 = command2.ExecuteReader();
            while (reader2.Read())
            {
                chart2.Series["Meslek-Maas"].Points.AddXY(reader2[0], reader2[1]);
            }
            SqlConnection.Close();
        }
    }
}
