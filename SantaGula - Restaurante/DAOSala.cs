using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace SantaGula_Restaurante
{
    internal class DAOSala
    {
        MySqlConnection conexao;
        public string dados;
        public string comandos;
        public int contar;
        public int i;
        public int[] codigoSala;
        public string[] nome;
        public string[] equipamento;
        public int[] Funcionariocodigo;


        public DAOSala()
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

        public void Inserir(string equipamento, int FuncionarioCodigo, string nome)
        {
            try
            {
                this.dados = $"('','{equipamento}','{FuncionarioCodigo}','{nome}')";
                this.comandos = $"insert into Sala(codigoSala,equipamento,FuncionarioCodigo,nome) values {this.dados}";
                MySqlCommand sql = new MySqlCommand(this.comandos, this.conexao);
                sql.ExecuteNonQuery();
                MessageBox.Show("Inserido com sucesso!");
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Algo deu errado! {erro}");
            }
        } // FIM DO INSERIR

        public void PreencherVetor()
        {
            string query = "Select * from Sala";


            // INSTANCIANDO VETORES

            this.codigoSala = new int[100];
            this.equipamento = new string[100];
            this.Funcionariocodigo = new int[100];
            this.nome = new string[100];

            // PREENCHENDO VETORES COM NUMEROS PADROES

            for (int i = 0; i < 0; i++)
            {
                this.codigoSala[i] = 0;
                this.equipamento[i] = "";
                this.Funcionariocodigo[i] = 0;
                this.nome[i] = "";

            }
            MySqlCommand coletar = new MySqlCommand(query, this.conexao);

            // LEU O BANCO DE DADOS
            MySqlDataReader leitura = coletar.ExecuteReader();


            i = 0;
            this.contar = 0;

            while (leitura.Read())
            {
                this.codigoSala[i] = Convert.ToInt32(leitura["codigoSala"]);
                this.equipamento[i] = leitura["equipamento"] + "";
                this.Funcionariocodigo[i] = Convert.ToInt32(leitura["Funcionariocodigo"]);
                this.nome[i] = leitura["nome"] + "";


                i++;
                this.contar++;
            } // fim do while 

            leitura.Close();
        } // FIM DO METODO

        public void ConsultarPorCodigo(int codigoSala)
        {
            string query = $"select * from Sala where codigoSala = {codigoSala}";

            this.codigoSala = new int[100];
            this.equipamento = new string[100];
            this.Funcionariocodigo = new int[100];
            this.nome = new string[100];


            MySqlCommand coletar = new MySqlCommand(query, this.conexao);
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            this.contar = 0;

            while (leitura.Read())
            {
                this.codigoSala[i] = Convert.ToInt32(leitura["codigoSala"]);
                this.equipamento[i] = leitura["equipamento"] + ""; ;
                this.Funcionariocodigo[i] = Convert.ToInt32(leitura["Funcionariocodigo"]);
                this.nome[i] = leitura["nome"] + ""; ;

                i++;
                this.contar++;
            }

            leitura.Close();
        }
        public void Atualizar(int codigoSala, string campo, string NovoDado)
        {
            try
            {
                string query = $"update Sala set {campo} = '{NovoDado}' where codigoSala = '{codigoSala}'";
                MySqlCommand sql = new MySqlCommand(query, this.conexao);
                sql.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Algo deu errado {erro}");
            }
        } // FIM DO ATUALIZAR

        public void Excluir(int codigoSala)
        {
            try
            {
                string query = $"delete from Sala where codigoSala = '{codigoSala}'";
                MySqlCommand sql = new MySqlCommand(query, this.conexao);
                MessageBox.Show("Excluido com Sucesso!");
                sql.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Algo deu errado!{erro}");
            }
        }// FIM DO EXCLUIR

    } // FIM DO METODO
} // FIM DO NAMESPACE