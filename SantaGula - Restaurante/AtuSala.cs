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
    public partial class AtuSala : Form
    {
        DAOSala sala;
        public AtuSala()
        {
            InitializeComponent();
            sala = new DAOSala();
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

        } // TEXT EQUIPMANETO

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        } // TEXT FUNCIONARIOCODIGO

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Informe o código da Sala!");
                return;
            }

            int codigo = Convert.ToInt32(textBox1.Text);

            this.sala.ConsultarPorCodigo(codigo);

            if (this.sala.contar == 0)
            {
                MessageBox.Show("Código não encontrado!");
                LimparCampos();
            }

            if (textBox1.Text != "")
                this.sala.Atualizar(codigo, "codigoSala", textBox1.Text);
            if (textBox2.Text != "")
                this.sala.Atualizar(codigo, "equipamento", textBox2.Text);
            if (textBox3.Text != "")
                this.sala.Atualizar(codigo, "FuncionarioCodigo", textBox3.Text);
            if (textBox4.Text != "")
                this.sala.Atualizar(codigo, "nome", textBox4.Text);

            MessageBox.Show("Atualizado com sucesso!");
            LimparCampos();
        } // BUTTO ATUALIZAR
        public void LimparCampos()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        } // TEXT NOME
    }
}
