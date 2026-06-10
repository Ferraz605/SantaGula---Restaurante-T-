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
    public partial class ADDSala : Form
    {
        DAOSala sala;
        public ADDSala()
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

        } // TEXT EQUIPAMENTO 

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        } // TEXT CODIGOFUNCIONARIO

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Preencha todos os campos!");
                return;
            }

           
            string equipamento = textBox1.Text;
            int FuncionarioCodigo = Convert.ToInt32(textBox2.Text);
            string nome = textBox3.Text;


            this.sala.Inserir(equipamento, FuncionarioCodigo,nome);
            MessageBox.Show("Inserido com sucesso!");
            LimparCampos();
        } // BUTTON ADICIONAR
        public void LimparCampos()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

        }

        private void ADDSala_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        } // TEXT NOME
    }
}
