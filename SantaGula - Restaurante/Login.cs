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
    public partial class Login : Form
    {
        MenuPrincipal menu;

        public static int codigoLogado;
        DAOFuncionario Funcionario;
        public Login()
        {
            InitializeComponent();
            this.Funcionario = new DAOFuncionario();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        } // TEXT EMAIL

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        } // TEXT SENHA

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Preencha os campos");
                return;
            }

            string email = textBox1.Text;
            string senha = textBox2.Text;

            bool loginEncontrado = Funcionario.Login(email, senha);

            if (loginEncontrado)
            {
                Login.codigoLogado = Funcionario.codigoFuncionario[0];
                MessageBox.Show("Bem-vindo!");
                menu = new MenuPrincipal();
                this.Hide();
                menu.ShowDialog();
                this.Show();
            }
        } // BUTTON ENTRAR
    }
}
