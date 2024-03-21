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
    public partial class Grafik : Form
    {
        public Grafik()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\zeyne\Documents\PetShopDb.mdf;Integrated Security=True;Connect Timeout=30");

        void FillChart()
        {
            DataTable dt = new DataTable();
            Con.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select UrunAdı, UrunMiktarı From UrunTbl", Con);
            da.Fill(dt);
            Con.Close();

            chart1.DataSource = dt;

            // Burada doğru alan adlarını kullanmalısınız
            chart1.Series[0].XValueMember = "UrunAdı";
            chart1.Series[0].YValueMembers = "UrunMiktarı";

            // Opsiyonel: Grafik başlığı eklemek için
            chart1.Titles.Add("Urun miktarları");
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            FillChart();
        }


        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
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