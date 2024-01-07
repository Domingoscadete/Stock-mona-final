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

namespace Stock_mona_final
{
    public partial class Form1 : Form
    {
        SqlConnection conexao = new SqlConnection(@"Data Source=LAPTOP-PIQ69LO4\SQLEXPRESS;Initial Catalog=db_estoque;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            conexao.Open();
            string query = "SELECT*FROM Addmin WHERE usuario='" + guna2TextBox1.Text + "' AND senha='" + guna2TextBox2.Text + "'";
            SqlDataAdapter dp = new SqlDataAdapter(query, conexao);
            DataTable dt = new DataTable();
            dp.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                splash Splash = new splash();
                this.Hide();
                Splash.Show();
                conexao.Close();

            }
            else
            {
                MessageBox.Show("Usuario ou senha incorretos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conexao.Close();
            }
        }
    }
}
