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
    public partial class ADDFuncionario : Form
    {
        DAOFuncionario funcionario;
        Funcionario Funcionario;
        public ADDFuncionario()
        {
            InitializeComponent();
            funcionario = new DAOFuncionario();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        } // TEXT NOME

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        } // TEXT CPF

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        } // TEXT CARGO

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        } // TEXT TURNO

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        } // TEXT TELEFONE

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        } // TEXT SALARIO

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        } // TEXT EMAIL

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        } // TEXT SENHA

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || maskedTextBox1.Text == "" || textBox3.Text == "" || textBox4.Text == "" || maskedTextBox2.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Preencha todos os campos!");
                return;
            }

            string nome = textBox1.Text;
            string cpf = maskedTextBox1.Text;
            string cargo = textBox2.Text;
            string turno = textBox3.Text;
            string senha = textBox6.Text;
            string email = textBox4.Text;  
            string telefone = maskedTextBox2.Text;
            decimal salario = Convert.ToDecimal(textBox5.Text);

            this.funcionario.Inserir(nome, cpf, email, senha, cargo, telefone, turno, salario, ADDEndereco.codigoEnderecoGerado);
           


            Funcionario = new Funcionario();
            this.Hide();
            Funcionario.ShowDialog();
            this.Show();
        } // BUTTON ADICIONAR
    }
}
