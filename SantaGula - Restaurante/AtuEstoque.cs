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
    public partial class AtuEstoque : Form
    {
        DAOEstoque estoque;
        public AtuEstoque()
        {
            InitializeComponent();
            estoque = new DAOEstoque();
        }

        private void AtuEstoque_Load(object sender, EventArgs e)
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

        } // TEXT QUANTIDADE TOTAL

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        } // TEXT SALACODIGO

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        } // TEXT COMIDACODIGO

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Informe o código do Endereço!");
                return;
            }

            int codigo = Convert.ToInt32(textBox1.Text);

            this.estoque.ConsultarPorCodigo(codigo);

            if (this.estoque.contar == 0)
            {
                MessageBox.Show("Código não encontrado!");
                LimparCampos();
            }

            if (textBox2.Text != "")
                this.estoque.Atualizar(codigo, "quantidade_total", textBox2.Text);
            if (textBox3.Text != "")
                this.estoque.Atualizar(codigo, "SalaCodigo", textBox3.Text);
            if (textBox4.Text != "")
                this.estoque.Atualizar(codigo, "ComidaCodigo", textBox4.Text);
            MessageBox.Show("Atualizado com sucesso!");
            LimparCampos();
        } // BUTTON ATUALIZAR

        public void LimparCampos()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

        }
    }
}
