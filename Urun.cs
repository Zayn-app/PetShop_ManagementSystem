using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetShopManagement
{
    public partial class Urun : Form
    {
        public Urun()
        {
            InitializeComponent();
            DisplayUrun();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\zeyne\Documents\PetShopDb.mdf;Integrated Security=True;Connect Timeout=30");
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
        private void Clear()
        {
            UrunAdı.Text = "";
            UrunKat.SelectedIndex =0;
            UrunMiktarı.Text = "";
            UrunFiyat.Text = "";
            


        }
        int Key = 0;
        private void KaydetBtn_Click(object sender, EventArgs e)
        {
            if (UrunAdı.Text == "" || UrunKat.SelectedIndex == -1|| UrunMiktarı.Text == "" || UrunFiyat.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into UrunTbl (UrunAdı,UrunKat,UrunMiktarı,UrunFiyat) values(@PA,@PK,@PM,@PF)", Con);
                    cmd.Parameters.AddWithValue("@PA", UrunAdı.Text);
                    cmd.Parameters.AddWithValue("@PK", UrunKat.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@PM", UrunMiktarı.Text);
                    cmd.Parameters.AddWithValue("@PF", UrunFiyat.Text);
                   
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("ürün eklendi!");

                    Con.Close();
                    DisplayUrun();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }

            }
        }


        private void UrunDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UrunAdı.Text = UrunDGV.CurrentRow.Cells[1].Value.ToString();
            UrunKat.Text = UrunDGV.CurrentRow.Cells[2].Value.ToString();
            UrunMiktarı.Text = UrunDGV.CurrentRow.Cells[3].Value.ToString();
            UrunFiyat.Text = UrunDGV.CurrentRow.Cells[4].Value.ToString();

            if (UrunAdı.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(UrunDGV.CurrentRow.Cells[0].Value.ToString());
            }
        }

        private void DegistirBtn_Click(object sender, EventArgs e)
        {
            if (UrunAdı.Text == "" || UrunKat.SelectedIndex == -1 || UrunMiktarı.Text == "" || UrunFiyat.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update UrunTbl set UrunAdı=@PA,UrunKat=@PK,UrunMiktarı=@PM,UrunFiyat=@PF where UrunId=@PKey", Con);
                    cmd.Parameters.AddWithValue("@PA", UrunAdı.Text);
                    cmd.Parameters.AddWithValue("@PK",UrunKat.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@PM", UrunMiktarı.Text);
                    cmd.Parameters.AddWithValue("@PF", UrunFiyat.Text);
                   
                    cmd.Parameters.AddWithValue("@PKey",Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("personel güncellendi!");
                    Con.Close();
                    DisplayUrun();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }

            }
        }

        private void SilBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("urun sec");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from UrunTbl where UrunId=@PKey", Con);
                    cmd.Parameters.AddWithValue("@PKey", Key);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("ürün silindi!");

                    Con.Close();
                    DisplayUrun();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }

            }
        }

        private void label3_Click(object sender, EventArgs e)
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

        private void label7_Click(object sender, EventArgs e)
        {
            personel Obj = new personel();
            Obj.Show();
            this.Hide();

        }

        private void label2_Click(object sender, EventArgs e)
        {
            musteri Obj = new musteri();
            Obj.Show();
            this.Hide();

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Odeme Obj = new Odeme();
            Obj.Show();
            this.Hide();

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            Ana_Sayfa Obj = new Ana_Sayfa();
            Obj.Show();
            this.Hide();
        }
    }
    
}
