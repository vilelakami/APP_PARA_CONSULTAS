using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAULAAPP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //assim que eu apertar no botão enviar ele abre nova tela
        private void btnCadasrar_Click(object sender, EventArgs e)
        {
            Form2 cadastro = new Form2();
            cadastro.Show();
        }
        //assim que eu apertar no botão enviar ele abre outra janela
        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            Form3 visualizar = new Form3();
            visualizar.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
