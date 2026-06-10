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
    public partial class Sala : Form
    {
        DAOSala sala;
        ADDSala ADDsala;
        AtuSala AtuSala;
        ExcSala Excsala;
        Estoque estoque;
        public Sala()
        {
            InitializeComponent();
            sala = new DAOSala();
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
            dataGrid.ColumnCount = 4;
        }

        public void NomeColunas(DataGridView dataGrid)
        {
            dataGrid.Columns[0].Name = "codigoSala";
            dataGrid.Columns[1].Name = "nome";
            dataGrid.Columns[2].Name = "Equipamento";
            dataGrid.Columns[3].Name = "FuncionarioCodigo";

        }
        public void AdicionarDados(DataGridView dataGrid)
        {
            this.sala.PreencherVetor();
            for (int i = 0; i < this.sala.contar; i++)
            {
                dataGrid.Rows.Add(this.sala.codigoSala[i], this.sala.nome[i], this.sala.equipamento[i], this.sala.Funcionariocodigo[i]);
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
            this.sala.ConsultarPorCodigo(codigoSala);
            for (int i = 0; i < this.sala.contar; i++)
            {
                dataGridView1.Rows.Add(this.sala.codigoSala[i], this.sala.nome[i], this.sala.equipamento[i], this.sala.Funcionariocodigo[i]);
            } // BUTTON BUSCAR
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        } // BUTTON SAIR

        private void button3_Click(object sender, EventArgs e)
        {
            ADDsala = new ADDSala();
            this.Hide();
            ADDsala.ShowDialog();
            this.Show();
            dataGridView1.Rows.Clear();
            AdicionarDados(dataGridView1);
        } // BUTTON ADICIONAR

        private void button4_Click(object sender, EventArgs e)
        {
            AtuSala = new AtuSala();
            this.Hide();
            AtuSala.ShowDialog();
            this.Show();
            dataGridView1.Rows.Clear();
            AdicionarDados(dataGridView1);
        } // BUTTON ATUALIZAR

        private void button5_Click(object sender, EventArgs e)
        {
            Excsala = new ExcSala();
            this.Hide();
            Excsala.ShowDialog();
            this.Show();
            dataGridView1.Rows.Clear();
            AdicionarDados(dataGridView1);
        } // BUTTON EXCLUIR

        private void button6_Click(object sender, EventArgs e)
        {
            estoque = new Estoque();
            this.Hide();
            estoque.ShowDialog();
            this.Show();
            dataGridView1.Rows.Clear();   // limpa
            AdicionarDados(dataGridView1); // recarrega
        } // BUTTON ESTOQUE

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        } // DATAGRIEDVIEW

        private void Sala_Load(object sender, EventArgs e)
        {

        }
    }
}
