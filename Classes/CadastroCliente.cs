using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto1
{
    internal class CadastroCliente
    {
        private int id;
        private string nome;
        private string telefone;
        private string cpf;
        private string endereco;
        

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public string Telefone
        {
            get { return telefone; }
            set { telefone = value; }

        }
        public string Cpf
        {
            get { return cpf; }
            set { cpf = value; }
        }
        public string Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }

        public bool CadastrarClienteNoBancoDeDados()
        {
            try
            {
                MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBanco.servidorBancoDeDados);
                MysqlConexaoBanco.Open();

                string insert = $"insert into tbclientes (nome, telefone, cpf, endereco) values ('{Nome}', '{Telefone}', '{Cpf}', '{Endereco}')";

                MySqlCommand comandoSql = MysqlConexaoBanco.CreateCommand();
                comandoSql.CommandText = insert;

                comandoSql.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro no banco de dados - método CadastrarClienteNoBancoDeDados" + ex.Message);
                return false;
            }
        }
    }
}
