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
    public partial class Cardapio : Form
    {
        DAOCardapio cardapio;
        ADDCardapio ADDCardapio;
        AtuCardapio atuCardapio;
        ExcCardapio ExcCardapio;
        public Cardapio()
        {
            InitializeComponent();
            cardapio = new DAOCardapio();
            ChamarMetodo(dataGridView1);
            button2.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button2.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button3.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button3.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button4.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button4.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button5.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button5.FlatAppearance.MouseDownBackColor = Color.Transparent;
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
            dataGrid.ColumnCount = 6;
        }

        public void NomeColunas(DataGridView dataGrid)
        {
            dataGrid.Columns[0].Name = "CódigoCardapio";
            dataGrid.Columns[1].Name = "Nome";
            dataGrid.Columns[2].Name = "Preço";
            dataGrid.Columns[3].Name = "Descrição";
            dataGrid.Columns[4].Name = "Tipo";
            dataGrid.Columns[5].Name = "CodigoFuncionario";

        }

        public void AdicionarDados(DataGridView dataGrid)
        {
            this.cardapio.PreencherVetor();
            for (int i = 0; i < this.cardapio.contar; i++)
            {
                dataGrid.Rows.Add(this.cardapio.codigoCardapio[i], this.cardapio.nome[i], this.cardapio.preco[i], this.cardapio.descricao[i], this.cardapio.tipo[i], this.cardapio.FuncionarioCodigo[i]);
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
            int codigoCardapio = Convert.ToInt32(textBox1.Text);
            this.cardapio.ConsultarPorCodigo(codigoCardapio);
            for (int i = 0; i < this.cardapio.contar; i++)
            {
                dataGridView1.Rows.Add(this.cardapio.codigoCardapio[i], this.cardapio.nome[i], this.cardapio.preco[i], this.cardapio.descricao[i], this.cardapio.tipo[i], this.cardapio.FuncionarioCodigo[i]);
            }
        } // BUTTON BUSCAR

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        } // BUTTON SAIR

        private void button3_Click(object sender, EventArgs e)
        {
            ADDCardapio = new ADDCardapio();
            this.Hide();
            ADDCardapio.ShowDialog();
            this.Show();
            dataGridView1.Rows.Clear();
            AdicionarDados(dataGridView1);
        } // BUTTON ADICIONAR

        private void button4_Click(object sender, EventArgs e)
        {
            atuCardapio = new AtuCardapio();
            this.Hide();
            atuCardapio.ShowDialog();
            this.Show();
            dataGridView1.Rows.Clear();
            AdicionarDados(dataGridView1);
        } // BUTTON ATUALIZAR

        private void button5_Click(object sender, EventArgs e)
        {
            ExcCardapio = new ExcCardapio();
            this.Hide();
            ExcCardapio.ShowDialog();
            this.Show();
            dataGridView1.Rows.Clear();
            AdicionarDados(dataGridView1);
        } // BUTTON EXCLUIR

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        } // DATAGRIEDVIEW
    }
}
