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
    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm()
        {
            InitializeComponent();
        }

        SqlConnection SqlConnection = new SqlConnection("Data Source=Ozan;Initial Catalog=PersonelVeriTabanı;Integrated Security=True;");

        void Temizle()
        {
            txtAd.Text = "";
            txtSoyad.Text = "";
            cmbSehir.Text = "";
            mskMaas.Text = "";
            txtMeslek.Text = "";
            txtId.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            txtAd.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'personelVeriTabanıDataSet.Tbl_Personel' table. You can move, or remove it, as needed.
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabanıDataSet.Tbl_Personel);

        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabanıDataSet.Tbl_Personel);
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlConnection.Open();

            SqlCommand command = new SqlCommand("insert into Tbl_Personel(PerAd,PerSoyad,PerSehir,PerMaas,PerMeslek,PerDurum) values (@p1,@p2,@p3,@p4,@p5,@p6)", SqlConnection);
            command.Parameters.AddWithValue("@p1", txtAd.Text);
            command.Parameters.AddWithValue("@p2", txtSoyad.Text);
            command.Parameters.AddWithValue("@p3", cmbSehir.Text);
            command.Parameters.AddWithValue("@p4", mskMaas.Text);
            command.Parameters.AddWithValue("@p5", txtMeslek.Text);
            command.Parameters.AddWithValue("@p6", label8.Text);
            command.ExecuteNonQuery(); // komutu çalıştırır. Ekleme, silme, güncelleme işlemlerinde kullanılır.
            SqlConnection.Close();
            MessageBox.Show("Personel Eklendi");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label8.Text = "True";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label8.Text = "False";
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selected = dataGridView1.SelectedCells[0].RowIndex;

            txtId.Text = dataGridView1.Rows[selected].Cells[0].Value.ToString(); 
            txtAd.Text = dataGridView1.Rows[selected].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[selected].Cells[2].Value.ToString();
            cmbSehir.Text = dataGridView1.Rows[selected].Cells[3].Value.ToString();
            mskMaas.Text = dataGridView1.Rows[selected].Cells[4].Value.ToString();
            label8.Text = dataGridView1.Rows[selected].Cells[5].Value.ToString();
            txtMeslek.Text = dataGridView1.Rows[selected].Cells[6].Value.ToString();
            
            if (label8.Text=="True")
            {
                radioButton1.Checked = true;
            }
            else if (label8.Text == "False")
            {
                radioButton2.Checked = true;
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlConnection.Open();
            SqlCommand command = new SqlCommand("Delete from Tbl_Personel where PerId=@k1", SqlConnection);
            command.Parameters.AddWithValue("@k1", txtId.Text);
            command.ExecuteNonQuery();
            SqlConnection.Close();
            MessageBox.Show("Personel Silindi");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlConnection.Open();
            SqlCommand command = new SqlCommand("update Tbl_Personel set PerAd=@p1,PerSoyad=@p2,PerSehir=@p3,PerMaas=@p4,PerMeslek=@p5,PerDurum=@p6 where PerId=@p7", SqlConnection);
            command.Parameters.AddWithValue("@p1", txtAd.Text);
            command.Parameters.AddWithValue("@p2", txtSoyad.Text);
            command.Parameters.AddWithValue("@p3", cmbSehir.Text);
            command.Parameters.AddWithValue("@p4", mskMaas.Text);
            command.Parameters.AddWithValue("@p5", txtMeslek.Text);
            command.Parameters.AddWithValue("@p6", label8.Text);
            command.Parameters.AddWithValue("@p7", txtId.Text);
            command.ExecuteNonQuery();
            SqlConnection.Close();
            MessageBox.Show("Personel Güncellendi");
        }

        private void btnIstatisik_Click(object sender, EventArgs e)
        {
            Frmİstatistik fr = new Frmİstatistik();
            fr.Show();

        }

        private void btnGrafikler_Click(object sender, EventArgs e)
        {
            FrmGrafikler fr = new FrmGrafikler();
            fr.Show();
        }
    }
}
