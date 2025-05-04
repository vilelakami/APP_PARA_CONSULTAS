using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAULAAPP
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        //assim que apertar cancelar ele fecha a janela
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //assim que apertar o botão enviar
        private void button1_Click(object sender, EventArgs e)
        {
            //passo o caminho da pasta e o caminho do banco
            string pasta = @"C:\Users\vilel\Desktop\bordadosPaula";
            string caminho = Path.Combine(pasta, "cadastro.db");

            //armazeno o que eu quero pesquisar em uma variavel
            string pesquisa = textBox1.Text;

            //instancio uma conexao passando o caminho do meu banco
            using (SQLiteConnection conn = new SQLiteConnection("Data source=" + caminho))
            {
                //abro esse caminho
                conn.Open();

                //armazeno meu comando em sql para encontrar informações
                string sql = @"SELECT * FROM cadastro WHERE celular = @celular ";

                //instancio um comando passando meu comando sql + a minha conexao
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {

                    //procuro no campo celular
                    cmd.Parameters.AddWithValue("@celular", pesquisa);

                    //não sei preciso entender melhor
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        //se foi encontrado
                        if (reader.Read())
                        {
                            //trago todas as informações nas minhas labels
                            label11.Text = reader["nome"].ToString();
                            label12.Text = reader["qtdeToalhas"].ToString();
                            label13.Text = reader["corestoalhas"].ToString();
                            label14.Text = reader["coreslinhas"].ToString();
                            string dataTexto = reader["data"].ToString();
                            if (DateTime.TryParse(dataTexto, out DateTime data))
                            {
                                label15.Text = data.ToString("dd/MM/yyyy"); // Exibe no formato desejado
                            }
                            else
                            {
                                MessageBox.Show("Erro ao converter a data!");
                            }
                            label15.Text = data.ToString("dd/MM/yyyy");
                            textBox2.Text = reader["servico"].ToString();
                            label17.Text = reader["orcamento"].ToString();
                        }

                        else
                        {
                            //se não foi encontrado eu exibo essa mensagem
                            MessageBox.Show("Cliente não encontrado!");
                        }
                    }
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }
    }
}
