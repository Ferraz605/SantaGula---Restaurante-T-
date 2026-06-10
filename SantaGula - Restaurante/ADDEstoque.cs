using SantaGula_Restaurante;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SantaGula___Restaurante
{
    public partial class ADDEstoque : Form
    {
        DAOEstoque estoque;
        public ADDEstoque()
        {
            estoque = new DAOEstoque();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        } // BUTTON SAIR

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        } // TEXT CODIGO

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        } // TEXT QUANTIDADE

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        } // TEXT SALA

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        } // TEXT COMIDA

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Preencha todos os campos!");
                return;
            }


            
            int quantidade_total = Convert.ToInt32(textBox2.Text);
            int SalaCodigo = Convert.ToInt32(textBox3.Text);
            int ComidaCodigo = Convert.ToInt32(textBox4.Text);


            this.estoque.Inserir(quantidade_total,SalaCodigo,ComidaCodigo);
            MessageBox.Show("Inserido com sucesso!");
            LimparCampos();
        } // BUTTON ADICIONAR

        public void LimparCampos()
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

        }
    }
}
