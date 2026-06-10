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
    public partial class AtuCardapio : Form
    {
        DAOCardapio cardapio;
        public AtuCardapio()
        {
            InitializeComponent();
            cardapio = new DAOCardapio();

        }
        private void AtuCardapio_Load(object sender, EventArgs e)
        {

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

        } // TEXT NOME

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        } // TEXT TIPO

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        } // TEXT PRECO

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        } // TEXT DESCRICAO

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Informe o código do cardápio!");
                return;
            }

            int codigo = Convert.ToInt32(textBox1.Text);

            this.cardapio.ConsultarPorCodigo(codigo);

            if (this.cardapio.contar == 0)
            {
                MessageBox.Show("Código não encontrado!");
                LimparCampos();
            }

            if (textBox2.Text != "")
                this.cardapio.Atualizar(codigo, "nome", textBox2.Text);
            if (textBox3.Text != "")
                this.cardapio.Atualizar(codigo, "tipo", textBox3.Text);
            if (textBox4.Text != "")
                this.cardapio.Atualizar(codigo, "preco", textBox4.Text);
            if (textBox5.Text != "")
                this.cardapio.Atualizar(codigo, "descricao", textBox5.Text);

            MessageBox.Show("Atualizado com sucesso!");
            LimparCampos();
        } // BUTTON ATUALIZAR
        public void LimparCampos()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }
    }
}
