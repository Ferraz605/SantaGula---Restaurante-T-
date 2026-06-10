using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace SantaGula_Restaurante
{
    public class DAOFuncionario
    {
        public MySqlConnection conexao;
        public string dados;
        public string comandos;
        public int i;
        public int contar;
        public int[] codigoFuncionario;
        public string[] nome;
        public string[] cpf;
        public string[] email;
        public string[] senha;
        public string[] cargo;
        public string[] telefone;
        public string[] turno;
        public decimal[] salario;
        public int[] EnderecoCodigo;


        public DAOFuncionario()
        {
            conexao = new MySqlConnection("server=localhost;DataBase=SantaGula;Uid=root;Password=;Convert Zero DateTime=True");
            try
            {
                this.conexao.Open();
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Algo deu errado! {erro}");
            } // FIM DO TRY E CAHTCH
        } // FIM DO METODO

        public void Inserir(string nome, string cpf, string email, string senha, string cargo, string telefone, string turno, decimal salario, int EnderecoCodigo)
        {
            try
            {
                this.dados = $"('','{nome}','{cpf}','{email}','{senha}','{cargo}','{telefone}','{turno}','{salario}','{EnderecoCodigo}')";
                this.comandos = $"Insert into Funcionario(codigoFuncionario,nome,cpf,email,senha,cargo,telefone,turno,salario,EnderecoCodigo) values {this.dados}";
                MySqlCommand sql = new MySqlCommand(this.comandos, this.conexao);
                sql.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Algo deu errado! {erro}");
            }
        } // FIM DO INSERIR

        public void PreencherVetor()
        {
            string query = "Select * from Funcionario";


            // INSTANCIANDO VETORES

            this.codigoFuncionario = new int[100];
            this.nome = new string[100];
            this.cpf = new string[100];
            this.email = new string[100];
            this.senha = new string[100];
            this.cargo = new string[100];
            this.telefone = new string[100];
            this.turno = new string[100];
            this.salario = new decimal[100];
            this.EnderecoCodigo = new int[100];

            // PREENCHENDO VETORES COM NUMEROS PADROES

            for (int i = 0; i < 0; i++)
            {
                this.codigoFuncionario[i] = 0;
                this.nome[i] = "";
                this.cpf[i] = "";
                this.email[i] = "";
                this.senha[i] = "";
                this.cargo[i] = "";
                this.telefone[i] = "";
                this.turno[i] = "";
                this.salario[i] = 0;
                this.EnderecoCodigo[i] = 0;
            }
            MySqlCommand coletar = new MySqlCommand(query, this.conexao);

            // LEU O BANCO DE DADOS
            MySqlDataReader leitura = coletar.ExecuteReader();


            i = 0;
            this.contar = 0;

            while (leitura.Read())
            {
                this.codigoFuncionario[i] = Convert.ToInt32(leitura["codigoFuncionario"]);
                this.nome[i] = leitura["nome"] + "";
                this.cpf[i] = leitura["cpf"] + "";
                this.email[i] = leitura["email"] + "";
                this.senha[i] = leitura["senha"] + "";
                this.cargo[i] = leitura["cargo"] + "";
                this.telefone[i] = leitura["telefone"] + "";
                this.turno[i] = leitura["turno"] + "";
                this.salario[i] = Convert.ToDecimal(leitura["salario"]);
                this.EnderecoCodigo[i] = Convert.ToInt32(leitura["EnderecoCodigo"]);

                i++;
                this.contar++;
            } // fim do while 

            leitura.Close();
        } // FIM DO METODO

        public void ConsultarPorCodigo(int CodigoFuncionario)
        {
            string query = $"select * from Funcionario where codigoFuncionario = {CodigoFuncionario}";

            this.codigoFuncionario = new int[100];
            this.nome = new string[100];
            this.cpf = new string[100];
            this.email = new string[100];
            this.cargo = new string[100];
            this.turno = new string[100];
            this.telefone = new string[100];
            this.salario = new decimal[100];
            this.EnderecoCodigo = new int[100];

            MySqlCommand coletar = new MySqlCommand(query, this.conexao);
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            this.contar = 0;

            while (leitura.Read())
            {
                this.codigoFuncionario[i] = Convert.ToInt32(leitura["codigoFuncionario"]);
                this.nome[i] = leitura["nome"] + "";
                this.cpf[i] = leitura["cpf"] + "";
                this.email[i] = leitura["email"] + "";
                this.cargo[i] = leitura["cargo"] + "";
                this.turno[i] = leitura["turno"] + "";
                this.telefone[i] = leitura["telefone"] + "";
                this.salario[i] = Convert.ToDecimal(leitura["salario"]);
                this.EnderecoCodigo[i] = Convert.ToInt32(leitura["EnderecoCodigo"]);
                i++;
                this.contar++;
            }

            leitura.Close();
        }

        public void Atualizar(int codigoFuncionario, string campo, string NovoDado)
        {
            try
            {
                string query = $"update Funcionario set {campo} = '{NovoDado}' where codigoFuncionario = '{codigoFuncionario}'";
                MySqlCommand sql = new MySqlCommand(query, this.conexao);
                sql.ExecuteNonQuery();

            }
            catch (Exception erro)
            {
                MessageBox.Show($"Algo deu errado {erro}");
            }
        } // FIM DO ATUALIZAR

        public void Excluir(int codigoFuncionario)
        {
            try
            {
                string query = $"delete from Funcionario where codigoFuncionario = '{codigoFuncionario}'";
                MySqlCommand sql = new MySqlCommand(query, this.conexao);
                MessageBox.Show("Excluido com Sucesso!");
                sql.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Algo deu errado!{erro}");
            }
        }// FIM DO EXCLUIR

        public bool Login(string email, string senha)
        {
            string query = $"Select * from Funcionario where email = '{email}' and senha = '{senha}'";

            this.codigoFuncionario = new int[100];
            MySqlCommand cmd = new MySqlCommand(query, conexao);
            MySqlDataReader leitura = cmd.ExecuteReader();

            bool encontrou = leitura.Read();

            if (encontrou)
            {
                this.codigoFuncionario[0] = Convert.ToInt32(leitura["codigoFuncionario"]);
            }

            leitura.Close();

            if (!encontrou)
            {
                MessageBox.Show("Email ou senha incorretos! Tente novamente.");
            }

            return encontrou;
        }

    } // FIM Da CLASSE
} // FIM DO NAMESPACE