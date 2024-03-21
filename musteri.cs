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
using System.Data.SqlClient;

namespace PetShopManagement
{
    public partial class musteri : Form
    {
        public musteri()
        {
            InitializeComponent();
            Displaymusteri();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\zeyne\Documents\PetShopDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void Displaymusteri()
        {
            Con.Open();
            string Query = "Select * from MusteriTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            MusteriDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Clear()
        {
            MusteriAdı.Text = "";
            MusteriAdrs.Text = "";
            MusteriTel.Text = "";
        }
       

        private void KaydetBtn_Click(object sender, EventArgs e)
        {
            
        }
        int Key = 0;

        public static string ValueMember { get; internal set; }

        private void MusteriDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MusteriAdı.Text = MusteriDGV.CurrentRow.Cells[1].Value.ToString();
            MusteriAdrs.Text = MusteriDGV.CurrentRow.Cells[2].Value.ToString();
            MusteriTel.Text = MusteriDGV.CurrentRow.Cells[3].Value.ToString();


            if (MusteriAdı.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(MusteriDGV.CurrentRow.Cells[0].Value.ToString());
            }
        }


        private void DegistirBtn_Click(object sender, EventArgs e)
        {
            if (MusteriAdı.Text == "" || MusteriAdrs.Text == "" || MusteriTel.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update MusteriTbl set MusteriAdı=@CN,MusteriAdrs=@CA,MusteriTel=@CP where MusteriNum=@CKey",Con);
                   
                    cmd.Parameters.AddWithValue("@CN", MusteriAdı.Text);
                    cmd.Parameters.AddWithValue("@CA", MusteriAdrs.Text);
                    cmd.Parameters.AddWithValue("@CP", MusteriTel.Text);
                    cmd.Parameters.AddWithValue("@CKey", Key);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("musteri güncellendi!");
                    Con.Close();
                    Displaymusteri();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }

            }

        }

        

        private void SilBtn_Click_1(object sender, EventArgs e)
        {

            if (Key == 0)
            {
                MessageBox.Show("musteri sec");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from MusteriTbl where MusteriNum=@MusKey", Con);
                    cmd.Parameters.AddWithValue("@MusKey", Key);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Musteri silindi!");

                    Con.Close();
                    Displaymusteri();
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

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            Ana_Sayfa Obj = new Ana_Sayfa();
            Obj.Show();
            this.Hide();
        }

        private void KaydetBtn_Click_1(object sender, EventArgs e)
        {
            if (MusteriAdı.Text == "" || MusteriAdrs.Text == "" || MusteriTel.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into MusteriTbl (MusteriAdı,MusteriAdrs,MusteriTel) values(@CN,@CA,@CP)", Con);
                    cmd.Parameters.AddWithValue("@CN", MusteriAdı.Text);
                    cmd.Parameters.AddWithValue("@CA", MusteriAdrs.Text);
                    cmd.Parameters.AddWithValue("@CP", MusteriTel.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Musteri eklendi!");

                    Con.Close();
                    Displaymusteri();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }

            }
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}
