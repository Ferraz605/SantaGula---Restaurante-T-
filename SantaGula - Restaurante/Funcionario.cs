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
    public partial class Funcionario : Form
    {
        DAOFuncionario funconario;
        ADDEndereco ADDEndereco;
        MenuPrincipal MenuPrincipal;
        AtuFuncionario AtuFuncionario;
        ExcFuncionario ExcFuncionario;
        Endereco Endereco;
        public Funcionario()
        {
            InitializeComponent();
            funconario = new DAOFuncionario();
            ChamarMetodo(dataGridView1);
            button3.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button3.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button4.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button4.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button5.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button5.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button6.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button6.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }

        public void ChamarMetodo(DataGridView datagrid)
        {
            ConfigurarDataGrid(datagrid);
            NomeColunas(datagrid);
            AdicionarDados(datagrid);
        }

        public void ConfigurarDataGrid(DataGridView dataGrid)
        {
            dataGrid.AllowUserToAddRows = false;
            dataGrid.AllowUserToDeleteRows = false;
            dataGrid.AllowUserToResizeColumns = false;
            dataGrid.AllowUserToResizeRows = false;
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGrid.ColumnCount = 9;
        }

        public void NomeColunas(DataGridView dataGrid)
        {
            dataGrid.Columns[0].Name = "CodigoFuncionario";
            dataGrid.Columns[1].Name = "Nome";
            dataGrid.Columns[2].Name = "CPF";
            dataGrid.Columns[3].Name = "Email";
            dataGrid.Columns[4].Name = "Cargo";
            dataGrid.Columns[5].Name = "Telefone";
            dataGrid.Columns[6].Name = "Turno";
            dataGrid.Columns[7].Name = "Salario";
            dataGrid.Columns[8].Name = "EndereçoCodigo";
        }

        public void AdicionarDados(DataGridView dataGrid)
        {
            this.funconario.PreencherVetor();
            for (int i = 0; i < this.funconario.contar; i++)
            {
                dataGrid.Rows.Add(this.funconario.codigoFuncionario[i], this.funconario.nome[i], this.funconario.cpf[i], this.funconario.email[i], this.funconario.cargo[i], this.funconario.telefone[i]
                    , this.funconario.turno[i], this.funconario.salario[i], this.funconario.EnderecoCodigo[i]);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ADDEndereco = new ADDEndereco();
            this.Hide();
            ADDEndereco.ShowDialog();
            this.Show();
            dataGridView1.Rows.Clear();
            AdicionarDados(dataGridView1);
        } // BUTTON ADICIONAR

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                dataGridView1.Rows.Clear();
                AdicionarDados(dataGridView1);
            }
        } // TEXT BUSCAR

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            int codigoFuncionario = Convert.ToInt32(textBox1.Text);
            this.funconario.ConsultarPorCodigo(codigoFuncionario);
            for (int i = 0; i < this.funconario.contar; i++)
            {
                dataGridView1.Rows.Add(this.funconario.codigoFuncionario[i], this.funconario.nome[i], this.funconario.cpf[i], this.funconario.email[i], this.funconario.cargo[i], this.funconario.telefone[i]
                    , this.funconario.turno[i], this.funconario.salario[i], this.funconario.EnderecoCodigo[i]);
            }
        } // BUTTON BUSCAR

        private void button1_Click(object sender, EventArgs e)
        {
            MenuPrincipal = new MenuPrincipal();
            this.Hide();
            MenuPrincipal.ShowDialog();
            this.Show();
        } // BUTTON SAIR

        private void button4_Click(object sender, EventArgs e)
        {
            AtuFuncionario = new AtuFuncionario();
            this.Hide();
            AtuFuncionario.ShowDialog();
            this.Show();
            dataGridView1.Rows.Clear();
            AdicionarDados(dataGridView1);
        } // BUTTON ATUALIZAR

        private void button5_Click(object sender, EventArgs e)
        {
            ExcFuncionario = new ExcFuncionario();
            this.Hide();
            ExcFuncionario.ShowDialog();
            this.Show();
            dataGridView1.Rows.Clear();
            AdicionarDados(dataGridView1);
        } // BUTTON EXCLUIR

        private void button6_Click(object sender, EventArgs e)
        {
            Endereco = new Endereco();
            this.Hide();
            Endereco.ShowDialog();
            this.Show();
            dataGridView1.Rows.Clear();
            AdicionarDados(dataGridView1);
        } // BUTTON ENDERECOS

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        } // DATAGRIEDVIEW
    }
}
