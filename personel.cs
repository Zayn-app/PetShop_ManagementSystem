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

namespace PetShopManagement
{
    public partial class personel : Form
    {
        public personel()
        {
            InitializeComponent();
            Displaypersonel();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\zeyne\Documents\PetShopDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void Displaypersonel()
        {  Con.Open();
            string Query = "Select * from PersonelTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query,Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds=new DataSet();
            sda.Fill(ds);
            PersonelDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Clear()
        {
            PersonelAdı.Text = "";
            PersonelAdrs.Text = "";
            PersonelTel.Text = "";
            PersonelSifre.Text = "";


        }
        int Key = 0;
        private void KaydetBtn_Click(object sender, EventArgs e)
        {
            if(PersonelAdı.Text == "" || PersonelAdrs.Text == "" || PersonelTel.Text== "" || PersonelSifre.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                SqlCommand cmd = new SqlCommand("insert into PersonelTbl (PersonelAdı,PersonelAdrs,PersonelDgtarih,PersonelTelno,PersonelSifre) values(@EN,@EA,@ED,@EP,@EPa)",Con);
                    cmd.Parameters.AddWithValue("@EN", PersonelAdı.Text);
                    cmd.Parameters.AddWithValue("@EA", PersonelAdrs.Text);
                    cmd.Parameters.AddWithValue("@ED", PersonelDG.MaxDate);
                    cmd.Parameters.AddWithValue("@EP", PersonelTel.Text);
                    cmd.Parameters.AddWithValue("@EPa",PersonelSifre.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("personel eklendi!");

                    Con.Close();
                    Displaypersonel();
                    Clear();
                }catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }
                
            }
        }
       
        private void PersonelDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PersonelAdı.Text = PersonelDGV.CurrentRow.Cells[1].Value.ToString();
            PersonelAdrs.Text = PersonelDGV.CurrentRow.Cells[2].Value.ToString();
            PersonelDG.Value = Convert.ToDateTime(PersonelDGV.CurrentRow.Cells[3].Value);
            PersonelTel.Text = PersonelDGV.CurrentRow.Cells[4].Value.ToString();
            PersonelSifre.Text= PersonelDGV.CurrentRow.Cells[5].Value.ToString();

            if(PersonelAdı.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(PersonelDGV.CurrentRow.Cells[0].Value.ToString());
            }
        }

       private void DegistirBtn_Click(object sender, EventArgs e)
        {
            if (PersonelAdı.Text == "" || PersonelAdrs.Text == "" || PersonelTel.Text == "" || PersonelSifre.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update PersonelTbl set PersonelAdı=@EN,PersonelAdrs=@EA,PersonelDGtarih=@ED,PersonelTelno=@EP,PersonelSifre=@EPa where PersonelNum=@EKey",Con);
                    cmd.Parameters.AddWithValue("@EN", PersonelAdı.Text);
                    cmd.Parameters.AddWithValue("@EA", PersonelAdrs.Text);
                    cmd.Parameters.AddWithValue("@ED", PersonelDG.Value);
                    cmd.Parameters.AddWithValue("@EP", PersonelTel.Text);
                    cmd.Parameters.AddWithValue("@EPa",PersonelSifre.Text);
                    cmd.Parameters.AddWithValue("@EKey",Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("personel güncellendi!");
                    Con.Close();
                    Displaypersonel();
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
                MessageBox.Show("personel sec");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from PersonelTbl where PersonelNum=@EmpKey", Con);
                    cmd.Parameters.AddWithValue("@EmpKey",Key);
                   
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("personel silindi!");

                    Con.Close();
                    Displaypersonel();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            musteri Obj = new musteri();
            Obj.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Urun Obj = new Urun();
            Obj.Show();
            this.Hide();

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Ana_Sayfa Obj = new Ana_Sayfa();
            Obj.Show();
            this.Hide();

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            Urun Obj = new Urun();
            Obj.Show();
            this.Hide();
        }

        private void label2_Click_1(object sender, EventArgs e)
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

        private void pictureBox14_Click(object sender, EventArgs e)
        {

            Ana_Sayfa Obj = new Ana_Sayfa();
            Obj.Show();
            this.Hide();

        }

        private void PersonelDG_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
