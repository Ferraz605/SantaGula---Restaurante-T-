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
    public partial class ADDComida : Form
    {
        DAOComida comida;    
        public ADDComida()
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

        } // TEXT NOME

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        } // TEXT TIPO

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        } // TEXT DATA

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        } // TEXT QUANTIDADE

        private void button2_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == ""))
            {
                MessageBox.Show("Preencha todos os campos!");
                return;
            }


            string nome = textBox1.Text;
            string tipo = textBox2.Text;
            DateTime dt_validacao = Convert.ToDateTime(textBox3.Text);
            int quantidade = Convert.ToInt32(textBox4.Text);


            this.comida.Inserir(nome,tipo, dt_validacao, quantidade);
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
