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
    public partial class Ana_Sayfa : Form
    {
        public Ana_Sayfa()
        {
            InitializeComponent();
            CountDogs();
            CountCats();
            
        }


        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\zeyne\Documents\PetShopDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void CountDogs()
        {
            string Kat = "Köpek";

            try
            {
                
                
                    Con.Open();

                    // Use parameterized query to avoid SQL injection
                    string query = "SELECT SUM(UrunMiktarı) FROM UrunTbl WHERE UrunKat = @Kat";
                    using (SqlCommand cmd = new SqlCommand(query, Con))
                    {
                        // Add parameters to the SqlCommand
                        cmd.Parameters.AddWithValue("@Kat", Kat);

                        // Use ExecuteScalar for retrieving a single value
                        int count = (int)cmd.ExecuteScalar();

                        // Display the result
                        KopekLbl.Text = count.ToString();
                    Con.Close();
                    }
                
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., display an error message)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        private void CountCats()
        {
            string Kat = "Kedi";

            try
            {


                Con.Open();

                // Use parameterized query to avoid SQL injection
                string query = "SELECT SUM(UrunMiktarı) FROM UrunTbl WHERE UrunKat = @Kat";
                using (SqlCommand cmd = new SqlCommand(query, Con))
                {
                    // Add parameters to the SqlCommand
                    cmd.Parameters.AddWithValue("@Kat", Kat);

                    // Use ExecuteScalar for retrieving a single value
                    int count = (int)cmd.ExecuteScalar();

                    // Display the result
                    label16.Text = count.ToString();
                    Con.Close();
                }

            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., display an error message)
                Console.WriteLine("Error: " + ex.Message);
            }

        }
        private void label6_Click(object sender, EventArgs e)
        {

            

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Odeme odeme = new Odeme();
            odeme.Show();
            this.Hide();

        }
       
        
        private void label3_Click(object sender, EventArgs e)
        {

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

        private void label10_Click(object sender, EventArgs e)
        {
            Grafik Obj = new Grafik();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        

        private void KopekLbl_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            Urun Obj = new Urun();
            Obj.Show();
            this.Hide();
        }

        private void label7_Click_1(object sender, EventArgs e)
        {
            personel Obj = new personel();
            Obj.Show();
            this.Hide();
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            musteri Obj = new musteri();
            Obj.Show();
            this.Hide();
        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            Odeme odeme = new Odeme();
            odeme.Show();
            this.Hide();

        }

        private void label10_Click_1(object sender, EventArgs e)
        {

            Grafik Obj = new Grafik();
            Obj.Show();
            this.Hide();
        }

        private void label6_Click_1(object sender, EventArgs e)
        {

            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            personel Obj = new personel();
            Obj.Show();
            this.Hide();

        }
    }
}
