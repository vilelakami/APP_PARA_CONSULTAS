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

namespace BORDADOSPAULAAPP
{
    public partial class Form2 : Form
    {
      
        public Form2()
        {
            InitializeComponent();
        }

        //método para criar banco de dados
        private void CriarBanco()
        {
            //coloco o caminho da pasta
            string pasta = @"C:\Users\vilel\Desktop\bordadosPaula";
            //caminho do banco (que está dentro da pasta)
            string caminho = Path.Combine(pasta, "cadastro.db");

            //criar pasta (com o caminho que eu especifiquei)
            Directory.CreateDirectory(pasta);

            //se esse caminho NÃO EXISTIR, ou seja, se o banco ainda não tiver sido criado
            if (!File.Exists(caminho))
            {
                //utilizo o comando do sqlite para criar o meu arquivo .db
                SQLiteConnection.CreateFile(caminho);

                //criando uma isntancia de uma conexao e enviando como parametro o caminho do .db
                using (var conn = new SQLiteConnection("Data source= " + caminho))
                {
                    //abrindo conexao
                    conn.Open();

                    //criando a tabela dentro da variavel sql
                    string sql = @"CREATE TABLE IF NOT EXISTS cadastro(
                                 id INTEGER PRIMARY KEY AUTOINCREMENT,
                                 nome TEXT,
                                 celular TEXT,
                                 qtdetoalhas TEXT,
                                 corestoalhas TEXT,
                                 coreslinhas TEXT,
                                 data DATE,
                                 servico TEXT,
                                 orcamento TEXT);";


                    //instanciando niva conexao e passando como parametro minha tabela e meu caminho
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        //abrindo arquivo e jogando a tabela dentro dele
                        cmd.ExecuteNonQuery();
                    }
}
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        //botão cancelar fecha a página
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //botão de enviar
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            //chamo a função criar banco
            CriarBanco();

            //coloco o caminho da pasta e o do .db
            string pasta = @"C:\Users\vilel\Desktop\bordadosPaula";
            string caminho = Path.Combine(pasta, "cadastro.db");

            //armazeno o que foi digitado dentro das variaveis
            string nome = textBox1.Text;
            string celular = textBox2.Text; 
            string qtdetoalhas = textBox3.Text;
            string corestoalhas = textBox4.Text;
            string coreslinhas = textBox5.Text;
            DateTime data = monthCalendar1.SelectionStart;
            string servico = textBox6.Text;
            string orcamento = textBox7.Text;

            //tente isto
            try
            {
                //instanciando nova conexao
                using (SQLiteConnection conn = new SQLiteConnection("Data source= " + caminho))
                {
                    //abrindo conexao
                    conn.Open();

                    //inserindo as minhas varivaeis (que armazenei logo em cima) dentro da tabela
                    string sql = @"INSERT INTO cadastro (nome, celular, qtdetoalhas, corestoalhas, coreslinhas, data, servico, orcamento)
                             VALUES
                             (@nome, @celular, @qtdetoalhas, @corestoalhas, @coreslinhas, @data, @servico, @orcamento)";


                    //instanciando um comando para pegar meus dados da variavel sql e colocar dentro do db
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        //adicionando cada informação no campo da tabela
                        cmd.Parameters.AddWithValue("@nome", nome);
                        cmd.Parameters.AddWithValue("@celular", celular);
                        cmd.Parameters.AddWithValue("@qtdetoalhas", qtdetoalhas);
                        cmd.Parameters.AddWithValue("@corestoalhas", corestoalhas);
                        cmd.Parameters.AddWithValue("@coreslinhas", coreslinhas);
                        cmd.Parameters.AddWithValue("@data", data.ToString("dd/MM/yyyy"));
                        cmd.Parameters.AddWithValue("@servico", servico);
                        cmd.Parameters.AddWithValue("@orcamento", orcamento);

                        //executando
                        cmd.ExecuteNonQuery();

                    }

                    //se der certo os dados foram adicionados
                    MessageBox.Show("Dados adicionados!");
                }
            }
            //se nada em cima der certo
            catch (Exception ex) {
                //exibe mensagem + erro
                MessageBox.Show("Erro ao enviar dados "+ex.Message);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        //delimitando o campo celular para apenas numeros
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Apenas números");
            }
        }
        //delimitando o campo quantidade de toalhas para apenas numeros

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Apenas números");
            }
        }

        //delimitando o campo orcamento para apenas numeros
        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Apenas números");
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
