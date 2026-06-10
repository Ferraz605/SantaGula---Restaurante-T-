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
    public partial class Endereco : Form
    {
        DAOEndereco endereco;
        AtuEndereco AtuEndereco;
        ExcEndereco ExcEndereco;
        public Endereco()
        {
            InitializeComponent();
            endereco = new DAOEndereco();
            ChamarMetodo(dataGridView1);
            button3.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button3.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button4.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button4.FlatAppearance.MouseDownBackColor = Color.Transparent;
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
            dataGrid.ColumnCount = 7;
        }

        public void NomeColunas(DataGridView dataGrid)
        {
            dataGrid.Columns[0].Name = "CodigoEndereco";
            dataGrid.Columns[1].Name = "Numero";
            dataGrid.Columns[2].Name = "Cidade";
            dataGrid.Columns[3].Name = "Estado";
            dataGrid.Columns[4].Name = "Pais";
            dataGrid.Columns[5].Name = "Cep";
            dataGrid.Columns[6].Name = "Logradouro";

        }
        public void AdicionarDados(DataGridView dataGrid)
        {
            this.endereco.PreencherVetor();
            for (int i = 0; i < this.endereco.contar; i++)
            {
                dataGrid.Rows.Add(this.endereco.codigoEndereco[i], this.endereco.numero[i], this.endereco.cidade[i], this.endereco.estado[i], this.endereco.pais[i], this.endereco.cep[i], this.endereco.logradouro[i]);
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
            int codigoEndereco = Convert.ToInt32(textBox1.Text);
            this.endereco.ConsultarPorCodigo(codigoEndereco);
            for (int i = 0; i < this.endereco.contar; i++)
            {
                dataGridView1.Rows.Add(this.endereco.codigoEndereco[i], this.endereco.numero[i], this.endereco.cidade[i], this.endereco.estado[i], this.endereco.pais[i], this.endereco.cep[i], this.endereco.logradouro[i]);
            }
        } // BUTTON BUSCAR

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        } // BUTTON SAIR

        private void button3_Click(object sender, EventArgs e)
        {
            AtuEndereco = new AtuEndereco();
            this.Hide();
            AtuEndereco.ShowDialog();
            this.Show();
            dataGridView1.Rows.Clear();
            AdicionarDados(dataGridView1);

        } // BUTTON ATUALIZAR

        private void button4_Click(object sender, EventArgs e)
        {
            ExcEndereco = new ExcEndereco();
            this.Hide(); 
            ExcEndereco.ShowDialog();
            this.Show();
            dataGridView1.Rows.Clear();
            AdicionarDados(dataGridView1);
        } // BUTTON EXCLUIR

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        } // DATAGRIEDVIEW
    }
}
