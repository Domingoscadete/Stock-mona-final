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
    public partial class Vendas1 : Form
    {
        public Vendas1()
        {
            InitializeComponent();
        }
        string pr;
        int q1, n1, n2;

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SqlConnection conexao = new SqlConnection(@"Data Source=LAPTOP-PIQ69LO4\SQLEXPRESS;Initial Catalog=db_estoque;Integrated Security=True");
            conexao.Open();
            SqlCommand cmd = new SqlCommand("Delete vendas where id=@id", conexao);
            cmd.Parameters.AddWithValue("@id", guna2TextBox4.Text);

            cmd.ExecuteNonQuery();
            conexao.Close();
        }

        private void Vendas1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'db_estoqueDataSet.produtos' table. You can move, or remove it, as needed.
            this.produtosTableAdapter.Fill(this.db_estoqueDataSet.produtos);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SqlConnection conexao = new SqlConnection(@"Data Source=LAPTOP-PIQ69LO4\SQLEXPRESS;Initial Catalog=db_estoque;Integrated Security=True");
            conexao.Open();
            SqlCommand cmd = new SqlCommand("Update vendas set quantidade=@quantidade,data_venda=@data_venda where id=@id", conexao);

            cmd.Parameters.AddWithValue("@quantidade", int.Parse(guna2TextBox2.Text));
            cmd.Parameters.AddWithValue("@data_venda", DateTime.Parse(guna2TextBox3.Text));
            cmd.Parameters.AddWithValue("@id", guna2TextBox4.Text);

            cmd.ExecuteNonQuery();
            conexao.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SqlConnection conexao = new SqlConnection(@"Data Source=LAPTOP-PIQ69LO4\SQLEXPRESS;Initial Catalog=db_estoque;Integrated Security=True");

            conexao.Open();
            string query = "SELECT nome,quantidade,id FROM produtos WHERE nome='" + guna2TextBox1.Text + "'";
            SqlDataAdapter dp = new SqlDataAdapter(query, conexao);
            DataTable dt = new DataTable();
            dp.Fill(dt);
            SqlDataReader dr;

            SqlCommand cmd = new SqlCommand(query, conexao);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                pr = dr.GetString(0);
                q1 = dr.GetInt32(1);
                n2 = dr.GetInt32(2);
                n1 = q1 - int.Parse(guna2TextBox2.Text);
                conexao.Close();
                //


                if (q1 != 0 && int.Parse(guna2TextBox2.Text) <= q1)
                {

                    //realiza a venda diminuindo a quantidade do produto na tabela produto 
                    conexao.Open();
                    SqlCommand cmd1 = new SqlCommand("Update produtos set quantidade=@quantidade,data_validade=@data_validade where nome=@nome", conexao);

                    cmd1.Parameters.AddWithValue("@quantidade", n1);
                    cmd1.Parameters.AddWithValue("@data_validade", DateTime.Parse(guna2TextBox3.Text));
                    cmd1.Parameters.AddWithValue("@nome", pr);
                    cmd1.ExecuteNonQuery();
                    conexao.Close();

                    //Adiciona os dados da venda na tabela vendas
                    conexao.Open();
                    SqlCommand cmd2 = new SqlCommand("Insert into vendas values(@data_venda,@quantidade,@id_produto)", conexao);


                    cmd2.Parameters.AddWithValue("@data_venda", DateTime.Parse(guna2TextBox3.Text));
                    cmd2.Parameters.AddWithValue("@quantidade", n1);
                    cmd2.Parameters.AddWithValue("@id_produto", n2);
                    cmd2.ExecuteNonQuery();
                    conexao.Close();
                    // venda realizada
                }




                else if(q1==0 || int.Parse(guna2TextBox2.Text) > q1)
                {
                    MessageBox.Show("Impossivel realizar a venda! Quantidade insuficiente do produto no stock.");
                }

                //




            }
            else
            {
                MessageBox.Show("Impossivel realizar a venda de um produto inexistente na data_base");
            }

        }
    }
}
