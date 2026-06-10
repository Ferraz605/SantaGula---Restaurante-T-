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
    public partial class ExcComida : Form
    {
        DAOComida comida;
        public ExcComida()
        {
            InitializeComponent();
            this.comida = new DAOComida();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        } // BUTTON SAIR

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        } // TEXT CODIGO

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Preencha o Campo");
            }
            else
            {
                int codigoComida = Convert.ToInt32(textBox1.Text);

                this.comida.ConsultarPorCodigo(codigoComida);

                if (this.comida.contar == 0)
                {
                    MessageBox.Show("Código não encontrado!");
                    LimparCampos();
                }

                this.comida.Excluir(codigoComida);
                LimparCampos();
            }
        } // BUTTON EXCLUIR

        public void LimparCampos()
        {
            textBox1.Text = "";
        }
    }
}
