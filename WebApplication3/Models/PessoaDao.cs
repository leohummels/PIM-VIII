using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;
using WebApplication3.Models.PIM_VIII.Models;

namespace WebApplication3
{
    public class PessoaDao 
    {
        string sql = "SELECT * FROM pessoas_schema.pessoa ORDER BY id";
        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;database=pessoas_schema;user=root;password=root");
        public List<Pessoa> pessoaList = new List<Pessoa>();
        
        public void connectDb()
        {
            try
            {
                connection.Open();
            }
            finally
            {
                connection.Close();
            }
        }

        public List<Pessoa> ConsultaPessoa()
        {
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            connection.Open();
            var comando = cmd.ExecuteReader();

            while (comando.Read())
            {
                Pessoa pessoa = new Pessoa
                {
                    Nome = comando["Nome"].ToString(),
                    Cpf = int.Parse(comando["cpf"].ToString()),
                    Endereco = new Endereco(),
                    Telefone = new Telefone(),
                };
                pessoaList.Add(pessoa);
            }

            connection.Close();
            return pessoaList;
        }

        public Pessoa PessoaDetails(int id)
        {
            sql = $"SELECT * FROM pessoas_schema.pessoa WHERE id = {id}";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            connection.Open();
            var comando = cmd.ExecuteReader();
            Pessoa pessoa = new Pessoa();
            while (comando.Read())
            {
                pessoa.Nome = comando["Nome"].ToString();
                pessoa.Cpf = int.Parse(comando["cpf"].ToString());
                pessoa.Endereco = new Endereco();
                pessoa.Telefone = new Telefone();
            }
            return pessoa; 
        }

    }
}