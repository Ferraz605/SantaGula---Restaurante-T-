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
    public partial class AtuEndereco : Form
    {
        DAOEndereco endereco;
        public AtuEndereco()
        {
            InitializeComponent();
            endereco = new DAOEndereco();
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

        } // TEXT LOGRADOURO

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        } // TEXT NUMERO

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        } // TEXT CIDADE

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        } // TEXT ESTADO

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        } // TEXT PAIS

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        } // TEXT CEP

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Informe o código do Endereço!");
                return;
            }

            int codigo = Convert.ToInt32(textBox1.Text);

            this.endereco.ConsultarPorCodigo(codigo);

            if (this.endereco.contar == 0)
            {
                MessageBox.Show("Código não encontrado!");
                LimparCampos();
            }

            if (textBox2.Text != "")
                this.endereco.Atualizar(codigo, "logradouro", textBox2.Text);
            if (textBox3.Text != "")
                this.endereco.Atualizar(codigo, "numero", textBox3.Text);
            if (textBox4.Text != "")
                this.endereco.Atualizar(codigo, "cidade", textBox4.Text);
            if (textBox5.Text != "")
                this.endereco.Atualizar(codigo, "estado", textBox5.Text);
            if (textBox6.Text != "")
                this.endereco.Atualizar(codigo, "pais", textBox6.Text);
            if (textBox7.Text != "")
                this.endereco.Atualizar(codigo, "cep", textBox7.Text);
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
            textBox6.Text = "";
            textBox7.Text = "";

        }
    }
}
