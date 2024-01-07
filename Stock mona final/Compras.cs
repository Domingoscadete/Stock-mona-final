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
    public partial class Compras : Form
    {
        private Size formOriginalSize;
        private Rectangle recBut1;
        private Rectangle recTxt1;
        private Rectangle recPnl1;
        private Rectangle recRdo1;
        public Compras()
        {
            InitializeComponent();
           
        }
        private void Compras_Resiz(object sender, EventArgs e)
        {
            resize_Control(panel1, recBut1);
            resize_Control(guna2DataGridView1, recTxt1);
            resize_Control(guna2Button1, recTxt1);

        }
        private void resize_Control(Control c, Rectangle r)
        {
            float xRatio = (float)(this.Width) / (float)(formOriginalSize.Width);
            float yRatio = (float)(this.Height) / (float)(formOriginalSize.Height);
            int newX = (int)(r.X * xRatio);
            int newY = (int)(r.Y * yRatio);

            int newWidth = (int)(r.Width * xRatio);
            int newHeight = (int)(r.Height * yRatio);

            c.Location = new Point(newX, newY);
            c.Size = new Size(newWidth, newHeight);

        }
        private void Compras_Load(object sender, EventArgs e)
        {

            SqlConnection conexao = new SqlConnection(@"Data Source=LAPTOP-PIQ69LO4\SQLEXPRESS;Initial Catalog=db_estoque;Integrated Security=True");
            conexao.Open();
            SqlCommand cmd = new SqlCommand("select * From compras", conexao);
            SqlDataAdapter dp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            dp.Fill(dt);
            guna2DataGridView1.DataSource = dt;

            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            dr.Read();

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
            loadform(new Compras1(), sender);
        }
    }
}
