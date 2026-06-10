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
    public partial class ExcEndereco : Form
    {
        DAOEndereco endereco;
        public ExcEndereco()
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

        } // TEXT EXCLUIR

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Preencha o Campo");
            }
            else
            {
                int codigoEndereco = Convert.ToInt32(textBox1.Text);

                this.endereco.ConsultarPorCodigo(codigoEndereco);

                if (this.endereco.contar == 0)
                {
                    MessageBox.Show("Código não encontrado!");
                    LimparCampos();
                }

                this.endereco.Excluir(codigoEndereco);
                LimparCampos();
            } 
        }// BUTTON EXCLUIR

            public void LimparCampos()
        {
            textBox1.Text = "";
        }
    }
}
