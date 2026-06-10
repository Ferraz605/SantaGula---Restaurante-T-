using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SantaGula_Restaurante
{
    internal class DAOComida
    {
        MySqlConnection conexao;
        public string dados;
        public string comandos;
        public int i;
        public int contar;
        public int[] codigoComida;
        public string[] nome;
        public string[] tipo;
        public DateTime[] dt_validacao;
        public int[] quantidade;


        public DAOComida()
        {
            conexao = new MySqlConnection("server=localhost;DataBase=SantaGula;Uid=root;Password=;Convert Zero DateTime=True");
            try
            {
                this.conexao.Open();
                MessageBox.Show("Conectado com sucesso!");
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Algo deu errado! {erro}");
            } // FIM DO TRY E CAHTCH
        } // FIM DA CLASSE

        public void Inserir(string nome, string tipo, DateTime dt_validacao, int quantidade)
        {
            try
            {
                this.dados = $"('','{nome}','{tipo}','{dt_validacao}','{quantidade}')";
                this.comandos = $"Insert into Comida(codigoComida,nome,tipo,dt_validacao,quantidade) values {this.dados}";
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Algo deu errado! {erro}");
            } // FIM DO TRY CATCH
        } // FIM DO INSERIR

        public void PreencherVetor()
        {
            string query = "Select * from Comida";


            // INSTANCIANDO VETORES

            this.codigoComida = new int[100];
            this.nome = new string[100];
            this.tipo = new string[100];
            this.dt_validacao = new DateTime[100];
            this.quantidade = new int[100];

            // PREENCHENDO VETORES COM NUMEROS PADROES

            for (int i = 0; i < 0; i++)
            {
                this.codigoComida[i] = 0;
                this.nome[i] = "";
                this.tipo[i] = "";
                this.dt_validacao[i] = DateTime.MinValue;
                this.quantidade[i] = 0;
            }
            MySqlCommand coletar = new MySqlCommand(query, this.conexao);

            // LEU O BANCO DE DADOS
            MySqlDataReader leitura = coletar.ExecuteReader();


            i = 0;
            this.contar = 0;

            while (leitura.Read())
            {
                this.codigoComida[i] = Convert.ToInt32(leitura["codigoComida"]);
                this.nome[i] = leitura["nome"] + "";
                this.tipo[i] = leitura["tipo"] + "";
                this.dt_validacao[i] = Convert.ToDateTime(leitura["dt_validacao"]);
                this.quantidade[i] = Convert.ToInt32(leitura["quantidade"]);

                i++;
                this.contar++;
            } // fim do while 

            leitura.Close();
        } // FIM DO METODO

        public void ConsultarPorCodigo(int codigoComida)
        {
            string query = $"select * from Comida where codigoComida = {codigoComida}";

            this.codigoComida = new int[100];
            this.nome = new string[100];
            this.tipo = new string[100];
            this.dt_validacao = new DateTime[100];
            this.quantidade = new int[100];

            MySqlCommand coletar = new MySqlCommand(query, this.conexao);
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            this.contar = 0;

            while (leitura.Read())
            {
                this.codigoComida[i] = Convert.ToInt32(leitura["codigoComida"]);
                this.nome[i] = leitura["nome"] + "";
                this.tipo[i] = leitura["tipo"] + "";
                this.dt_validacao[i] = Convert.ToDateTime(leitura["dt_validacao"]);
                this.quantidade[i] = Convert.ToInt32(leitura["quantidade"]);

                i++;
                this.contar++;
            }

            leitura.Close();
        }

        public void Atualizar(int codigoComida, string campo, string NovoDado)
        {
            try
            {
                string query = $"update Comida set {campo} = '{NovoDado}' where codigoComida = '{codigoComida}'";
                MySqlCommand sql = new MySqlCommand(query, this.conexao);
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Algo deu errado {erro}");
            }
        } // FIM DO ATUALIZAR

        public void Excluir(int codigoComida)
        {
            try
            {
                string query = $"delete from Comida where codigoComida = '{codigoComida}'";
                MySqlCommand sql = new MySqlCommand(query, this.conexao);
                MessageBox.Show("Atualizado com Sucesso!");
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Algo deu errado!{erro}");
            }
        }// FIM DO EXCLUIR


    } // FIM DO METODO
} // FIM DO NAMESPACE