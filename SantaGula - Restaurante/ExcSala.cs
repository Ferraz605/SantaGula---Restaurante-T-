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
    public partial class ExcSala : Form
    {
        DAOSala sala;
        public ExcSala()
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Preencha o Campo");
            }
            else
            {
                int codigoSala = Convert.ToInt32(textBox1.Text);

                this.sala.ConsultarPorCodigo(codigoSala);

                if (this.sala.contar == 0)
                {
                    MessageBox.Show("Código não encontrado!");
                    LimparCampos();
                }

                this.sala.Excluir(codigoSala);
                LimparCampos();
            } // BUTTON EXCLUIR
        }
        public void LimparCampos()
        {
            textBox1.Text = "";
        }
    }
}
