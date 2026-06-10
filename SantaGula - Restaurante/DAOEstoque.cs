using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace SantaGula_Restaurante
{
    internal class DAOEstoque
    {
        MySqlConnection conexao;
        public string dados;
        public string comandos;
        public int i;
        public int contar;
        public int[] codigoEstoque;
        public int[] quantidade_total;
        public int[] SalaCodigo;
        public int[] ComidaCodigo;


        public DAOEstoque()
        {
            conexao = new MySqlConnection("server=localhost;DataBase=SantaGula;Uid=root;Password=;Convert Zero DateTime=True");

            try
            {
                this.conexao.Open();
                MessageBox.Show("Conectado com sucesso!");
            }
            catch (Exception erro)
            {
                MessageBox.Show($"algo de errado! {erro}");
            } // FIM DO TRY E CATCH
        } // FIM DA CLASSE

        public void Inserir(int quantidade_total, int salaCodigo, int comidaCodigo)
        {
            try
            {
                string query = $"INSERT INTO Estoque(quantidade_total, SalaCodigo, ComidaCodigo) " +
                               $"VALUES ('{quantidade_total}', '{salaCodigo}', '{comidaCodigo}')";

                MySqlCommand sql = new MySqlCommand(query, this.conexao);
                sql.ExecuteNonQuery(); 
                MessageBox.Show("Inserido com sucesso!");
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Erro ao inserir: {erro.Message}");
            }
        }

        public void PreencherVetor()
        {
            string query = "Select * from Estoque";


            // INSTANCIANDO VETORES

            this.codigoEstoque = new int[100];
            this.quantidade_total = new int[100];
            this.SalaCodigo = new int[100];
            this.ComidaCodigo = new int[100];

            // PREENCHENDO VETORES COM NUMEROS PADROES

            for (int i = 0; i < 0; i++)
            {
                this.codigoEstoque[i] = 0;
                this.quantidade_total[i] = 0;
                this.SalaCodigo[i] = 0;
                this.ComidaCodigo[i] = 0;
            }
            MySqlCommand coletar = new MySqlCommand(query, this.conexao);

            // LEU O BANCO DE DADOS
            MySqlDataReader leitura = coletar.ExecuteReader();


            i = 0;
            this.contar = 0;

            while (leitura.Read())
            {
                this.codigoEstoque[i] = Convert.ToInt32(leitura["codigoEstoque"]);
                this.quantidade_total[i] = Convert.ToInt32(leitura["quantidade_total"]);
                this.SalaCodigo[i] = Convert.ToInt32(leitura["SalaCodigo"]);
                this.ComidaCodigo[i] = Convert.ToInt32(leitura["ComidaCodigo"]);

                i++;
                this.contar++;
            } // fim do while 

            leitura.Close();
        } // FIM DO METODO

        public void ConsultarPorCodigo(int codigoEstoque)
        {
            string query = $"select * from Estoque where codigoEstoque = {codigoEstoque}";

            this.codigoEstoque = new int[100];
            this.quantidade_total = new int[100];
            this.SalaCodigo = new int[100];
            this.ComidaCodigo = new int[100];

            MySqlCommand coletar = new MySqlCommand(query, this.conexao);
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            this.contar = 0;

            while (leitura.Read())
            {
                this.codigoEstoque[i] = Convert.ToInt32(leitura["codigoEstoque"]);
                this.quantidade_total[i] = Convert.ToInt32(leitura["quantidade_total"]);
                this.SalaCodigo[i] = Convert.ToInt32(leitura["SalaCodigo"]);
                this.ComidaCodigo[i] = Convert.ToInt32(leitura["ComidaCodigo"]);

                i++;
                this.contar++;
            }

            leitura.Close();
        }

        public void Atualizar(int codigoEstoque, string campo, string NovoDado)
        {
            try
            {
                string query = $"update Estoque set {campo} = '{NovoDado}' where codigoEstoque = '{codigoEstoque}'";
                MySqlCommand sql = new MySqlCommand(query, this.conexao);
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Algo deu errado {erro}");
            }
        } // FIM DO ATUALIZAR

        public void Excluir(int codigoEstoque)
        {
            try
            {
                string query = $"delete from Estoque where codigoEstoque = '{codigoEstoque}'";
                MySqlCommand sql = new MySqlCommand(query, this.conexao);
                MessageBox.Show("Atualizado com Sucesso!");
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Algo deu errado!{erro}");
            }
        }// FIM DO EXCLUIR

    } // FIM DA METODO
}// FIM DO NAMESPACe