using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace SantaGula_Restaurante
{
    internal class DAOEndereco
    {
        MySqlConnection conexao;
        public string dados;
        public string comandos;
        public int contar;
        public int i;
        public int[] codigoEndereco;
        public int[] numero;
        public string[] cidade;
        public string[] estado;
        public string[] pais;
        public string[] cep;
        public string[] logradouro;
        public int codigoGerado;

        public DAOEndereco()
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

        public void Inserir(int numero, string cidade, string estado, string pais, string cep, string logradouro)
        {
            try
            {
                this.dados = $"('','{numero}','{cidade}','{estado}','{pais}','{cep}','{logradouro}')";
                this.comandos = $"Insert into Endereco(codigoEndereco,numero,cidade,estado,pais,cep,logradouro) values {this.dados}";
                MySqlCommand sql = new MySqlCommand(this.comandos, this.conexao);
                sql.ExecuteNonQuery();

                this.codigoGerado = Convert.ToInt32(sql.LastInsertedId);

            }
            catch (Exception erro)
            {
                MessageBox.Show($"Algo deu errado! {erro}");
            }
        } // FIM DO INSERIR

        public void PreencherVetor()
        {
            string query = "Select * from Endereco";


            // INSTANCIANDO VETORES

            this.codigoEndereco = new int[100];
            this.numero = new int[100];
            this.cidade = new string[100];
            this.estado = new string[100];
            this.pais = new string[100];
            this.cep = new string[100];
            this.logradouro = new string[100];

            // PREENCHENDO VETORES COM NUMEROS PADROES

            for (int i = 0; i < 0; i++)
            {
                this.codigoEndereco[i] = 0;
                this.numero[i] = 0;
                this.cidade[i] = "";
                this.estado[i] = "";
                this.pais[i] = "";
                this.cep[i] = "";
                this.logradouro[i] = "";
            }
            MySqlCommand coletar = new MySqlCommand(query, this.conexao);

            // LEU O BANCO DE DADOS
            MySqlDataReader leitura = coletar.ExecuteReader();


            i = 0;
            this.contar = 0;

            while (leitura.Read())
            {
                this.codigoEndereco[i] = Convert.ToInt32(leitura["codigoEndereco"]);
                this.numero[i] = Convert.ToInt32(leitura["numero"]);
                this.cidade[i] = leitura["cidade"] + "";
                this.estado[i] = leitura["estado"] + "";
                this.pais[i] = leitura["pais"] + "";
                this.cep[i] = leitura["cep"] + "";
                this.logradouro[i] = leitura["logradouro"] + "";

                i++;
                this.contar++;
            } // fim do while 

            leitura.Close();
        } // FIM DO METODO

        public void ConsultarPorCodigo(int codigoEndereco)
        {
            string query = $"select * from Endereco where codigoEndereco = {codigoEndereco}";

            this.codigoEndereco = new int[100];
            this.numero = new int[100];
            this.cidade = new string[100];
            this.estado = new string[100];
            this.pais = new string[100];
            this.cep = new string[100];
            this.logradouro = new string[100];


            MySqlCommand coletar = new MySqlCommand(query, this.conexao);
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            this.contar = 0;

            while (leitura.Read())
            {
                this.codigoEndereco[i] = Convert.ToInt32(leitura["codigoEndereco"]);
                this.numero[i] = Convert.ToInt32(leitura["numero"]);
                this.cidade[i] = leitura["cidade"] + "";
                this.estado[i] = leitura["estado"] + "";
                this.pais[i] = leitura["pais"] + "";
                this.cep[i] = leitura["cep"] + "";
                this.logradouro[i] = leitura["logradouro"] + "";

                i++;
                this.contar++;
            }

            leitura.Close();
        }
        public void Atualizar(int codigoEndereco, string campo, string NovoDado)
        {
            try
            {
                string query = $"update Endereco set {campo} = '{NovoDado}' where codigoEndereco = '{codigoEndereco}'";
                MySqlCommand sql = new MySqlCommand(query, this.conexao);
                sql.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Algo deu errado {erro}");
            }
        } // FIM DO ATUALIZAR

        public void Excluir(int codigoEndereco)
        {
            try
            {

                string query = $"delete from Endereco where codigoEndereco = {codigoEndereco}";
                MySqlCommand sql = new MySqlCommand(query, this.conexao);
                sql.ExecuteNonQuery();
                MessageBox.Show("Excluído com sucesso!");
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Algo deu errado! {erro}");
            }
        }// FIM DO EXCLUIR

    } // FIM DA DAO
} // FIM DO NAMESPACE