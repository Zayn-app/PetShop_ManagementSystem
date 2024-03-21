using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetShopManagement
{
    public partial class Odeme : Form
    {
        public Odeme()
        {
            InitializeComponent();
            personelAdı.Text = Login.perso;
            Getmusteri();
            DisplayUrun();

        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\zeyne\Documents\PetShopDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void Getmusteri()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select MusteriNum from MusteriTbl ", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("MusteriNum", typeof(int));
           dt.Load(Rdr);
            MusteriID.ValueMember = "MusteriNum";
            MusteriID.DataSource = dt;
            Con.Close();

        }
        private void DisplayUrun()
        {
            Con.Open();
            string Query = "Select * from UrunTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            UrunDGV.DataSource = ds.Tables[0];
            Con.Close();

        }
        private void GetMusteriAdı()
        {
            Con.Open();
            string Query = "Select * from MusteriTbl where MusteriNum = " + MusteriID.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(Query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                MusteriAD.Text = dr["MusteriAdı"].ToString();
                
            }
            Con.Close();

        }
        private void UpdateStock()
        {
            try
            {
                int NewQty = stock - Convert.ToInt32(UrunMiktarı.Text);
                Con.Open();
                SqlCommand cmd = new SqlCommand("Update UrunTbl set UrunMiktarı=@PM where UrunId=@PKey", Con);
                cmd.Parameters.AddWithValue("@PM", NewQty);
                cmd.Parameters.AddWithValue("@PKey", Key);
                cmd.ExecuteNonQuery();
                Con.Close();
                DisplayUrun();
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);

            }
        }


        int n = 0;
        int GrdTotal = 0;
        private void button1_Click(object sender, EventArgs e)
        {          if (UrunMiktarı.Text =="" || Convert.ToInt32(UrunMiktarı.Text) > stock)
                         {
                    MessageBox.Show("Yetersiz miktar veya geçersiz giriş.");
                         }
                 else if (UrunMiktarı.Text == "" || Key == 0)
                   {
                         MessageBox.Show("Eksik bilgi.");
                   }

                   else 
                    {
                int total = Convert.ToInt32(UrunFiyat.Text) * Convert.ToInt32(UrunMiktarı.Text);
                        DataGridViewRow newRow = new DataGridViewRow();
                         newRow.CreateCells(OdemeDGV);
                           newRow.Cells[0].Value= n + 1;
                          newRow.Cells[1].Value = UrunAdı.Text;
                        newRow.Cells[2].Value = UrunMiktarı.Text;
                        newRow.Cells[3].Value = UrunFiyat.Text;
                        newRow.Cells[4].Value = total;
                        GrdTotal += total;
                        OdemeDGV.Rows.Add(newRow);
                        n++;
                        TotalLbl.Text = "TL" + GrdTotal;
                        UpdateStock();
                        Reset();
                    }



        }

        private void MusteriNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetMusteriAdı();
        }
        int Key = 0, stock = 0;

        private void Reset()
        {
            UrunAdı.Text = "";
            UrunMiktarı.Text = "";
            stock = 0;
            Key = 0;
        }
        
        private void resetBtn_Click(object sender, EventArgs e)
        {
            Reset();

        }

        private void PersonelDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
       
        private void UrunDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            UrunAdı.Text = UrunDGV.CurrentRow.Cells[1].Value.ToString();
            stock = Convert.ToInt32(UrunDGV.CurrentRow.Cells[3].Value.ToString());
           // UrunMiktarı.Text= UrunDGV.CurrentRow.Cells[2].Value.ToString();
            UrunFiyat.Text = UrunDGV.CurrentRow.Cells[4].Value.ToString();
            MessageBox.Show("değer girin");
            if (UrunAdı.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(UrunDGV.CurrentRow.Cells[0].Value.ToString());
            }
        }

        private void MusteriAD_TextChanged(object sender, EventArgs e)
        {

        }

        private void TotalLbl_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            musteri Obj = new musteri();
            Obj.Show();
            this.Hide();

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Ana_Sayfa Obj = new Ana_Sayfa();
            Obj.Show();
            this.Hide();

        }

        private void label7_Click(object sender, EventArgs e)
        {
            personel Obj = new personel();
            Obj.Show();
            this.Hide();

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Ana_Sayfa Obj = new Ana_Sayfa();
            Obj.Show();
            this.Hide();
        }

        private void OdemeDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UrunAdı.Text = UrunDGV.CurrentRow.Cells[1].Value.ToString();
            UrunMiktarı.Text= UrunDGV.CurrentRow.Cells[2].Value.ToString();


        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            Ana_Sayfa Obj = new Ana_Sayfa();
            Obj.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Urun Obj = new Urun();
            Obj.Show();
            this.Hide();

        }

        


    }
}