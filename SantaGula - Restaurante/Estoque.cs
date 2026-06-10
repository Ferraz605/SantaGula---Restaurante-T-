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

    public partial class Estoque : Form
    {
        DAOEstoque estoque;
        ADDEstoque ADDEstoque;
        AtuEstoque AtuEstoque;
        ExcEstoque ExcEstoque;
        Comida Comida;
        public Estoque()
        {
            InitializeComponent();
            this.estoque = new DAOEstoque();
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
            dataGrid.ColumnCount = 4;
        }

        public void NomeColunas(DataGridView dataGrid)
        {
            dataGrid.Columns[0].Name = "codigoEstoque";
            dataGrid.Columns[1].Name = "quantidade_total";
            dataGrid.Columns[2].Name = "SalaCodigo";
            dataGrid.Columns[3].Name = "ComidaCodigo";

        }

        public void AdicionarDados(DataGridView dataGrid)
        {
            this.estoque.PreencherVetor();
            for (int i = 0; i < this.estoque.contar; i++)
            {
                dataGrid.Rows.Add(this.estoque.codigoEstoque[i], this.estoque.quantidade_total[i], this.estoque.SalaCodigo[i], this.estoque.ComidaCodigo[i]);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                dataGridView1.Rows.Clear();
                AdicionarDados(dataGridView1);
            }
        } // TEXT BUSCAR

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            int codigoEstoque = Convert.ToInt32(textBox1.Text);
            this.estoque.ConsultarPorCodigo(codigoEstoque);
            for (int i = 0; i < this.estoque.contar; i++)
            {
                dataGridView1.Rows.Add(this.estoque.codigoEstoque[i], this.estoque.quantidade_total[i], this.estoque.SalaCodigo[i], this.estoque.ComidaCodigo);
            }
        } // BUTTON BUSCAR

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        } // BUTTON SAIR

        private void button3_Click(object sender, EventArgs e)
        {
            ADDEstoque = new ADDEstoque();
            this.Hide();
            ADDEstoque.ShowDialog();
            this.Show();
            dataGridView1.Rows.Clear();
            AdicionarDados(dataGridView1);
        } // BUTTON ADICIONAR

        private void button4_Click(object sender, EventArgs e)
        {
            AtuEstoque = new AtuEstoque();
            this.Hide();
            AtuEstoque.ShowDialog();
            this.Show();
            dataGridView1.Rows.Clear();
            AdicionarDados(dataGridView1);
        } // BUTTON ATUALIZAR

        private void button5_Click(object sender, EventArgs e)
        {
            ExcEstoque = new ExcEstoque();
            this.Hide();
            ExcEstoque.ShowDialog();
            this.Show();
            dataGridView1.Rows.Clear();
            AdicionarDados(dataGridView1);
        } // BUTTON EXCLUIR

        private void button6_Click(object sender, EventArgs e)
        {
            Comida = new Comida();
            this.Hide();
            Comida.ShowDialog();
            this.Show();
            dataGridView1.Rows.Clear();
            AdicionarDados(dataGridView1);
        } // BUTTON GERENCIARCOMIDA

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        } // DATAGRIEDVIEW
    }
}
