using Microsoft.VisualBasic.Logging;
using MySql.Data.MySqlClient;
using SantaGula___Restaurante;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SantaGula_Restaurante
{
    public class DAOCardapio
    {
        public MySqlConnection conexao; // criando a variavel que representa o banco
        public string dados;
        public string comando;
        public int i;
        public int contar;
        public string msg;
        public int[] codigoCardapio;
        public string[] nome;
        public decimal[] preco;
        public string[] descricao;
        public string[] tipo;
        public int[] FuncionarioCodigo;


        public DAOCardapio()
        {
            conexao = new MySqlConnection("server=localhost;DataBase=SantaGula;Uid=root;Password=;Convert Zero DateTime=True");

            try
            {
                this.conexao.Open(); // Abre a conexão do banco de dados
                MessageBox.Show("conectado com sucesso!");
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Algo deu Errado! {erro}");
            } // FIM DO TRY E CATCH
        } // FIM DO DAOCARDAPIO

        public void Inserir(string nome, decimal preco, string descricao, string tipo)
        {

            try
            {
                this.dados = $"('','{nome}','{preco}','{descricao}','{tipo}','{Login.codigoLogado}')";
                this.comando = $"Insert into Cardapio(codigoCardapio,nome,preco,descricao,tipo,FuncionarioCodigo) values {this.dados}";
                MySqlCommand sql = new MySqlCommand(this.comando, this.conexao);
                sql.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Algo deu errado! {erro}");
            } // FIM DO TRY E CATCH
        } // FIM DO INSERIR

        public void PreencherVetor()
        {
            string query = "Select * from Cardapio";


            // INSTANCIANDO VETORES

            this.codigoCardapio = new int[100];
            this.nome = new string[100];
            this.preco = new decimal[100];
            this.descricao = new string[100];
            this.tipo = new string[100];
            this.FuncionarioCodigo = new int[100];

            // PREENCHENDO VETORES COM NUMEROS PADROES

            for (int i = 0; i < 0; i++)
            {
                this.codigoCardapio[i] = 0;
                this.nome[i] = "";
                this.preco[i] = 0;
                this.descricao[i] = "";
                this.tipo[i] = "";
                this.FuncionarioCodigo[i] = 0;
            }
            MySqlCommand coletar = new MySqlCommand(query, this.conexao);

            // LEU O BANCO DE DADOS
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            this.contar = 0;

            while (leitura.Read())
            {
                this.codigoCardapio[i] = Convert.ToInt32(leitura["codigoCardapio"]);
                this.nome[i] = leitura["nome"] + "";
                this.preco[i] = Convert.ToDecimal(leitura["preco"]);
                this.descricao[i] = leitura["descricao"] + "";
                this.tipo[i] = leitura["tipo"] + "";
                this.FuncionarioCodigo[i] = Convert.ToInt32(leitura["FuncionarioCodigo"]);
                i++;
                this.contar++;
            } // fim do while 

            leitura.Close();
        } // FIM DO METODO

        public void ConsultarPorCodigo(int codigoCardapio)
        {
            string query = $"select * from Cardapio where codigoCardapio = {codigoCardapio}";

            this.codigoCardapio = new int[100];
            this.nome = new string[100];
            this.preco = new decimal[100];
            this.descricao = new string[100];
            this.tipo = new string[100];
            this.FuncionarioCodigo = new int[100];

            MySqlCommand coletar = new MySqlCommand(query, this.conexao);
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            this.contar = 0;

            while (leitura.Read())
            {
                this.codigoCardapio[i] = Convert.ToInt32(leitura["codigoCardapio"]);
                this.nome[i] = leitura["nome"] + "";
                this.preco[i] = Convert.ToDecimal(leitura["preco"]);
                this.descricao[i] = leitura["descricao"] + "";
                this.tipo[i] = leitura["tipo"] + "";
                this.FuncionarioCodigo[i] = Convert.ToInt32(leitura["FuncionarioCodigo"]);
                i++;
                this.contar++;
            }

            leitura.Close();
        }

        public void Atualizar(int codigoCardapio, string campo, string NovoDado)
        {
            try
            {
                string query = $"update Cardapio set {campo} = '{NovoDado}' where codigoCardapio = '{codigoCardapio}'";
                MySqlCommand sql = new MySqlCommand(query, this.conexao);
                sql.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Algo deu errado {erro}");
            }
        } // FIM DO ATUALIZAR

        public void Excluir(int codigoCardapio)
        {
            try
            {
                string query = $"delete from Cardapio where codigoCardapio = '{codigoCardapio}'";
                MySqlCommand sql = new MySqlCommand(query, this.conexao);
                sql.ExecuteNonQuery();
                MessageBox.Show("Excluido com Sucesso!");
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Algo deu errado!{erro}");
            }
        }

    } // FIM DA CLASSE
} // FIM DO NAMESPACE