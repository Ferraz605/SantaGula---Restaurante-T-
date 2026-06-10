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
    public partial class AtuComida : Form
    {
        DAOComida comida;
        public AtuComida()
        {
            InitializeComponent();
            comida = new DAOComida();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        } // BUTTON SAIR

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        } // TEXT BUTTON

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        } // TEXT NOME

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        } // TEXT TIPO

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        } // TEXT DATAVALIDACAO

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        } // TEXT QUANTIDADE

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Informe o código do cardápio!");
                return;
            }

            int codigo = Convert.ToInt32(textBox1.Text);

            this.comida.ConsultarPorCodigo(codigo);

            if (this.comida.contar == 0)
            {
                MessageBox.Show("Código não encontrado!");
                LimparCampos();
            }

            if (textBox1.Text != "")
                this.comida.Atualizar(codigo, "codigo", textBox1.Text);
            if (textBox2.Text != "")
                this.comida.Atualizar(codigo, "nome", textBox2.Text);
            if (textBox3.Text != "")
                this.comida.Atualizar(codigo, "tipo", textBox3.Text);
            if (textBox4.Text != "")
                this.comida.Atualizar(codigo, "dt_validacao", textBox4.Text);
            if (textBox5.Text != "")
                this.comida.Atualizar(codigo, "quantidade", textBox5.Text);

            MessageBox.Show("Atualizado com sucesso!");
            LimparCampos();
        } // BUTTON ATUALIZAR

        public void LimparCampos()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox4.Text = "";

        }
    }
}
