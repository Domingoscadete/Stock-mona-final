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
    public partial class Compras1 : Form
    {
        public Compras1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SqlConnection conexao = new SqlConnection(@"Data Source=LAPTOP-PIQ69LO4\SQLEXPRESS;Initial Catalog=db_estoque;Integrated Security=True");
            conexao.Open();
            SqlCommand cmd = new SqlCommand("Update compras set quantidade=@quantidade,data_compra=@data_compra where id=@id", conexao);

            cmd.Parameters.AddWithValue("@quantidade", int.Parse(guna2TextBox2.Text));
            cmd.Parameters.AddWithValue("@data_compra", DateTime.Parse(guna2TextBox3.Text));
            cmd.Parameters.AddWithValue("@id", int.Parse(guna2TextBox2.Text));

            cmd.ExecuteNonQuery();
            conexao.Close();
        }
        string pr;
        int n1, n2;

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SqlConnection conexao = new SqlConnection(@"Data Source=LAPTOP-PIQ69LO4\SQLEXPRESS;Initial Catalog=db_estoque;Integrated Security=True");
            conexao.Open();
            SqlCommand cmd = new SqlCommand("Delete compras where id=@id", conexao);
            cmd.Parameters.AddWithValue("@id", guna2TextBox4.Text);

            cmd.ExecuteNonQuery();
            conexao.Close();
        }

        private void Compras1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'db_estoqueDataSet1.produtos' table. You can move, or remove it, as needed.
            this.produtosTableAdapter.Fill(this.db_estoqueDataSet1.produtos);

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            //insere os dados na compra na tabela compras
            SqlConnection conexao = new SqlConnection(@"Data Source=LAPTOP-PIQ69LO4\SQLEXPRESS;Initial Catalog=db_estoque;Integrated Security=True");
            conexao.Open();
            SqlCommand cmd = new SqlCommand("Insert into compras values (@data_compra,@quantidade) ", conexao);
            cmd.Parameters.AddWithValue("@data_compra", DateTime.Parse(guna2TextBox3.Text));
            cmd.Parameters.AddWithValue("@quantidade", int.Parse(guna2TextBox2.Text));

            cmd.ExecuteNonQuery();
            conexao.Close();
            //

            //se o produto da compra ja estiver inserido na tabela produtos  apenas irá  alterar a quantidade do produto 


            conexao.Open();
            string query = "SELECT nome,quantidade,id FROM produtos WHERE nome='" + guna2TextBox1.Text + "'";
            SqlDataAdapter dp = new SqlDataAdapter(query, conexao);
            DataTable dt = new DataTable();
            dp.Fill(dt);
            SqlDataReader dr;

            SqlCommand cmd1 = new SqlCommand(query, conexao);
            dr = cmd1.ExecuteReader();



            //

            if (dr.Read())
            {

                //atualiza os dados da tabela produtos
                pr = dr.GetString(0);
                n1 = dr.GetInt32(1);
                n2 = n1 + int.Parse(guna2TextBox2.Text);

                conexao.Close();
                conexao.Open();
                SqlCommand cmd2 = new SqlCommand("Update produtos set quantidade=@quantidade,data_validade=@data_validade where nome=@nome", conexao);

                cmd2.Parameters.AddWithValue("@quantidade", n2);
                cmd2.Parameters.AddWithValue("@data_validade", DateTime.Parse(guna2TextBox3.Text));
                cmd2.Parameters.AddWithValue("@nome", pr);
                cmd2.ExecuteNonQuery();
                conexao.Close();
            }
            else
            {
                conexao.Close();
                conexao.Open();
                SqlCommand cmd3 = new SqlCommand("Insert into produtos values (@nome,@quantidade,@data_validade) ", conexao);
                cmd3.Parameters.AddWithValue("@nome", guna2TextBox1.Text);
                cmd3.Parameters.AddWithValue("@quantidade", int.Parse(guna2TextBox2.Text));
                cmd3.Parameters.AddWithValue("@data_validade", DateTime.Parse(guna2TextBox3.Text));
                cmd3.ExecuteNonQuery();

                conexao.Close();

            }


        }
    }
}
