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
    public partial class AtuFuncionario : Form
    {
        DAOFuncionario funcionario;
        public AtuFuncionario()
        {
            InitializeComponent();
            funcionario = new DAOFuncionario();
        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        } // TEXT TELEFONE

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        } // TEXT SAIR

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        } // TEXT CODIGO

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        } // TEXT NOME

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        } // TEXT CPF

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        } // TEXT CARGO

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        } // TEXT TURNO

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        } // TEXT SALARIO

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        } // TEXT EMAIL

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        } // TEXT SENHA

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Informe o código do cardápio!");
                return;
            }

            int codigo = Convert.ToInt32(textBox1.Text);

            this.funcionario.ConsultarPorCodigo(codigo);

            if (this.funcionario.contar == 0)
            {
                MessageBox.Show("Código não encontrado!");
                LimparCampos();
            }

            string cpf = maskedTextBox1.Text;

            if (textBox2.Text != "")
                this.funcionario.Atualizar(codigo, "nome", textBox1.Text);
            if (maskedTextBox1.Text != "")
                this.funcionario.Atualizar(codigo, "cpf", maskedTextBox1.Text);
            if (textBox4.Text != "")
                this.funcionario.Atualizar(codigo, "cargo", textBox3.Text);
            if (textBox5.Text != "")
                this.funcionario.Atualizar(codigo, "turno", textBox4.Text);
            if (maskedTextBox2.Text != "")
                this.funcionario.Atualizar(codigo, "telefone", maskedTextBox2.Text);
            if (textBox7.Text != "")
                this.funcionario.Atualizar(codigo, "salario", textBox5.Text);
            if (textBox6.Text != "")
                this.funcionario.Atualizar(codigo, "email", textBox6.Text);
            if (textBox7.Text != "")
                this.funcionario.Atualizar(codigo, "senha", textBox7.Text);
            MessageBox.Show("Atualizado com sucesso!");
            LimparCampos();
        } // BUTTON ATUALIZAR

        public void LimparCampos()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            maskedTextBox1.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            maskedTextBox2.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }
    }
}
