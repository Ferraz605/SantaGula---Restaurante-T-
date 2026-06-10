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
    public partial class ADDEndereco : Form
    {
        public static int codigoEnderecoGerado;
        DAOEndereco endereco;
        ADDFuncionario ADDFuncionario;
        public ADDEndereco()
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

        } // TEXT LOGRADOURO

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        } // TEXT NUMERO

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        } // TEXT CIDADE

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        } // TEXT ESTADO

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        } // TEXT PAIS

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        } // TEXT CEP

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Preencha todos os campos!");
                return;
            }

            string logradouro = textBox1.Text;
            int numero = Convert.ToInt32(textBox2.Text);
            string cidade = textBox3.Text;
            string estado = textBox4.Text;
            string pais = textBox5.Text;
            string cep = textBox6.Text;

            this.endereco.Inserir(numero, cidade, estado, pais, cep, logradouro);
            ADDEndereco.codigoEnderecoGerado = this.endereco.codigoGerado;

            ADDFuncionario = new ADDFuncionario();
            this.Hide();
            ADDFuncionario.ShowDialog();
            this.Show();
        } // BUTTON PROXIMO
    }
}
