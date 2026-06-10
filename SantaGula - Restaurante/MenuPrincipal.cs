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
    public partial class MenuPrincipal : Form
    {
        Cardapio cardapio;
        Login Login;
        Funcionario Funcionario;
        Sala Sala;
        public MenuPrincipal()
        {
            InitializeComponent();
            button2.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button2.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button3.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button3.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button4.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button4.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cardapio = new Cardapio();
            this.Hide();
            cardapio.ShowDialog();
            this.Show();
        } // BUTTON CARDAPIO

        private void button3_Click(object sender, EventArgs e)
        {
            Funcionario = new Funcionario();
            this.Hide();
            Funcionario.ShowDialog();
            this.Show();
        } // BUTTON FUNCIONARIO

        private void button4_Click(object sender, EventArgs e)
        {
            Sala = new Sala();
            this.Hide();
            Sala.ShowDialog();
            this.Show();
        } // BUTTON SALAS

        private void button1_Click(object sender, EventArgs e)
        {
            Login = new Login();
            this.Hide();
            Login.ShowDialog();
            this.Show();
        } // BUTTON DESCONECTAR
    }
}
