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

namespace SantaGula___Restaurante
{
    public partial class ADDCardapio : Form
    {
        DAOCardapio cardapio;
        public ADDCardapio()
        {
            InitializeComponent();
            cardapio = new DAOCardapio();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        } // BUTTON SAIR

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        } // TEXT NOME

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        } // TEXT TIPO

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        } // TEXT PRECO

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        } // TEXT DESCRICAO

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Preencha todos os campos!");
                return;
            }

            string nome = textBox1.Text;
            string tipo = textBox2.Text;
            decimal preco = Convert.ToDecimal(textBox3.Text);
            string descricao = textBox4.Text;

            this.cardapio.Inserir(nome, preco, tipo, descricao);
            MessageBox.Show("Inserido com sucesso!");
            LimparCampos();
        } // BUTTON ADICIONAR
        public void LimparCampos()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
    }
}
