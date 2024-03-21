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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
           Password.PasswordChar = '*'; 
        }
        private void label4_Click(object sender, EventArgs e)
        {
            
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\zeyne\Documents\PetShopDb.mdf;Integrated Security=True;Connect Timeout=30");
        public static string perso;
        

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void GirisBtn_Click(object sender, EventArgs e)
        {
        }


        

        private void Uname_TextChanged(object sender, EventArgs e)
        {

        }

        private void Password_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void GirisBtn_Click_1(object sender, EventArgs e)
        {

            if (Uname.Text == "" || Password.Text == "")
            {
                MessageBox.Show("YANLIŞ YA DA EKSİK VERİ");
            }
            else
            {
                try
                {

                    {
                        Con.Open();

                        SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM PersonelTbl WHERE PersonelAdı = @Uname AND PersonelSifre = @Password", Con);
                        command.Parameters.AddWithValue("@Uname", Uname.Text);
                        command.Parameters.AddWithValue("@Password", Password.Text);

                        SqlDataAdapter sda = new SqlDataAdapter(command);
                        DataTable d = new DataTable();
                        sda.Fill(d);

                        if (Convert.ToInt32(d.Rows[0][0]) == 1)
                        {
                            perso = Uname.Text;
                            Ana_Sayfa Obj = new Ana_Sayfa();
                            Obj.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Kullanıcı adı veya şifre hatalı.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı bağlantısı veya sorgu sırasında hata oluştu: " + ex.Message);
                }
            }
        }

        private void label4_Click_2(object sender, EventArgs e)
        {
            personel Obj = new personel();
            Obj.Show();
            this.Hide();
        }
    }
}
