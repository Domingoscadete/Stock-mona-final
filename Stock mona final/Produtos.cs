using Guna.UI2.WinForms;
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

namespace Stock_mona_final
{
    public partial class Produtos : Form
    {
        public Produtos()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Produtos_Load(object sender, EventArgs e)
        {
            SqlConnection conexao = new SqlConnection(@"Data Source=LAPTOP-PIQ69LO4\SQLEXPRESS;Initial Catalog=db_estoque;Integrated Security=True");
            conexao.Open();
            SqlCommand cmd = new SqlCommand("select * From produtos", conexao);
            SqlDataAdapter dp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            dp.Fill(dt);
            guna2DataGridView1.DataSource = dt;
              
              SqlDataReader dr;
            dr = cmd.ExecuteReader();
            dr.Read();
            
        }
    }
}
