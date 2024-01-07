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
    public partial class Fornecedores : Form
    {
        public Fornecedores()
        {
            InitializeComponent();
        }
        private Form activeform;
        public void loadform(Form children, object btnsender)
        {
            if (activeform != null)
            {
                activeform.Close();
            }
            activeform = children;
            children.TopLevel = false;
            children.FormBorderStyle = FormBorderStyle.None;
            children.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(children);
            this.panel1.Tag = children;
            children.BringToFront();
            children.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            loadform(new Fornecdores1(), sender);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Fornecedores_Load(object sender, EventArgs e)
        {
            SqlConnection conexao = new SqlConnection(@"Data Source=LAPTOP-PIQ69LO4\SQLEXPRESS;Initial Catalog=db_estoque;Integrated Security=True");
            conexao.Open();
            SqlCommand cmd = new SqlCommand("select * From fornecedores", conexao);
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
