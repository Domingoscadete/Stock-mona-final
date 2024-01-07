using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stock_mona_final
{
    public partial class Home : Form
    {
        private Size formOriginalSize;
        private Rectangle recBut1;
        private Rectangle recTxt1;
        private Rectangle recPnl1;
        private Rectangle recRdo1;
        private Rectangle recRdo2;
        public Home()
        {
            InitializeComponent();
            this.Resize += Home_Resiz;
            formOriginalSize = this.Size;
            recBut1 = new Rectangle(panel1.Location,panel1.Size);
            recTxt1 = new Rectangle(guna2TextBox1.Location, guna2TextBox1.Size);
            recPnl1 = new Rectangle(panel2.Location, panel2.Size);
            recRdo1 = new Rectangle(panel3.Location, panel3.Size);
            recRdo2 = new Rectangle(pictureBox2.Location, pictureBox2.Size);
            guna2TextBox1.Multiline = true;
        }
        private void Home_Resiz(object sender, EventArgs e)
        {
            resize_Control(panel1, recBut1);
            resize_Control(guna2TextBox1, recTxt1);
            resize_Control(panel2, recPnl1);
            resize_Control(panel3, recRdo1);
            resize_Control(pictureBox2, recRdo2);
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

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

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
            this.panel3.Controls.Add(children);
            this.panel3.Tag = children;
            children.BringToFront();
            children.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            loadform(new Home1(), sender);

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            loadform(new Produtos(), sender);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            loadform(new Compras(), sender);
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            loadform(new Vendas(), sender);
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            loadform(new Fornecedores(), sender);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        string[] strings = new string[10];
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string n1 = guna2TextBox1.Text;
            if (n1 == "Home")
            {
                loadform(new Home1(), sender);
            }
            else if (n1 == "Produtos")
            {
                loadform(new Produtos(), sender);
            }
            else if (n1 == "Compras")
            {
                loadform(new Compras(), sender);
            }
            else if (n1 == "Vendas")
            {
                loadform(new Vendas(), sender);

            }
            else if (n1 == "Fornecedores")
            {
                loadform(new Fornecedores(), sender);
            }
            else
            {
                MessageBox.Show("Página não encontrada!");
            }
        }
    }
}
