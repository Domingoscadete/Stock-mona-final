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
    public partial class Fornecdores1 : Form
    {
        public Fornecdores1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SqlConnection conexao = new SqlConnection(@"Data Source=LAPTOP-PIQ69LO4\SQLEXPRESS;Initial Catalog=db_estoque;Integrated Security=True");
            conexao.Open();
            SqlCommand cmd = new SqlCommand("Update fornecedores set Nome=@Nome,endereco=@endereco,telefone=@telefone where id=@id", conexao);

            cmd.Parameters.AddWithValue("@Nome", guna2TextBox1.Text);
            cmd.Parameters.AddWithValue("@endereco", guna2TextBox2.Text);
            cmd.Parameters.AddWithValue("@telefone", int.Parse(guna2TextBox3.Text));
            cmd.Parameters.AddWithValue("@id", int.Parse(guna2TextBox4.Text));
            cmd.ExecuteNonQuery();
            conexao.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SqlConnection conexao = new SqlConnection(@"Data Source=LAPTOP-PIQ69LO4\SQLEXPRESS;Initial Catalog=db_estoque;Integrated Security=True");
            conexao.Open();
            SqlCommand cmd = new SqlCommand("Delete fornecedores where id=@id", conexao);
            cmd.Parameters.AddWithValue("@id", guna2TextBox4.Text);

            cmd.ExecuteNonQuery();
            conexao.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SqlConnection conexao = new SqlConnection(@"Data Source=LAPTOP-PIQ69LO4\SQLEXPRESS;Initial Catalog=db_estoque;Integrated Security=True");

            conexao.Open();
            string query = "SELECT Nome,endereco,telefone FROM fornecedores WHERE nome='" + guna2TextBox1.Text + "'";
            SqlDataAdapter dp = new SqlDataAdapter(query, conexao);
            DataTable dt = new DataTable();
            dp.Fill(dt);
            SqlDataReader dr;

            SqlCommand cmd = new SqlCommand(query, conexao);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                MessageBox.Show("Fornecedor já existente!Tente adicionar outro");
                conexao.Close();
                // venda realizada


            }
            else
            {
                conexao.Close();
                conexao.Open();
                SqlCommand cmd2 = new SqlCommand("Insert into fornecedores values(@Nome,@endereco,@telefone)", conexao);


                cmd2.Parameters.AddWithValue("@Nome", guna2TextBox1.Text);
                cmd2.Parameters.AddWithValue("@endereco", guna2TextBox2.Text);
                cmd2.Parameters.AddWithValue("@telefone", int.Parse(guna2TextBox3.Text));
                cmd2.ExecuteNonQuery();
                conexao.Close();
            }
        }
    }
}
