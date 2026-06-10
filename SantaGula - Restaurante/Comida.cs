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
    public partial class Comida : Form
    {
        DAOComida comida;
        ADDComida addComida;
        AtuComida atuComida;
        ExcComida excComida;
        public Comida()
        {
            InitializeComponent();
            comida = new DAOComida();
            ChamarMetodo(dataGridView1);
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
            dataGrid.ColumnCount = 5;
        }

        public void NomeColunas(DataGridView dataGrid)
        {
            dataGrid.Columns[0].Name = "codigoComida";
            dataGrid.Columns[1].Name = "nome";
            dataGrid.Columns[2].Name = "tipo";
            dataGrid.Columns[3].Name = "dt_validacao";
            dataGrid.Columns[4].Name = "quantidade";


        }
        public void AdicionarDados(DataGridView dataGrid)
        {
            this.comida.PreencherVetor();
            for (int i = 0; i < this.comida.contar; i++)
            {
                dataGrid.Rows.Add(this.comida.codigoComida[i], this.comida.nome[i], this.comida.tipo[i], this.comida.dt_validacao[i], this.comida.quantidade[i]);
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
            int codigoSala = Convert.ToInt32(textBox1.Text);
            this.comida.ConsultarPorCodigo(codigoSala);
            for (int i = 0; i < this.comida.contar; i++)
            {
                dataGridView1.Rows.Add(this.comida.codigoComida[i], this.comida.nome[i], this.comida.tipo[i], this.comida.dt_validacao[i], this.comida.quantidade[i]);
            } // BUTTON BUSCAR
        } // BUTTON BUSCAR

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        } // BUTTON SAIR

        private void button3_Click(object sender, EventArgs e)
        {
            addComida = new ADDComida();
            this.Hide();
            addComida.ShowDialog();
            this.Show();
            dataGridView1.Rows.Clear();
            AdicionarDados(dataGridView1);
        } // BUTTON ADICIONAR

        private void button4_Click(object sender, EventArgs e)
        {
            atuComida = new AtuComida();
            this.Hide();
            atuComida.ShowDialog();
            this.Show();
            dataGridView1.Rows.Clear();
            AdicionarDados(dataGridView1);
        } // BUTTON ATUALIZAR

        private void button5_Click(object sender, EventArgs e)
        {
            excComida = new ExcComida();
            this.Hide();
            excComida.ShowDialog();
            this.Show();
            dataGridView1.Rows.Clear();
            AdicionarDados(dataGridView1);
        } // BUTTON EXCLUIR

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        } // DATAGRIED
    }
}
