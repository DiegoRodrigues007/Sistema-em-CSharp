using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto1
{
    static class ConexaoBanco
    {
        // 4 variaveis declaradas passando informações para o banco de dados
        private const string servidor = "localhost";
        private const string bancoDeDados = "cliente";
        private const string usuario = "root";
        private const string senha = "1qazxsw2";

        // declarando variavel conexaoBanco para fazer a conexão com o banco de dados.
        static public string servidorBancoDeDados = $"server={servidor}; user id = {usuario}; database={bancoDeDados}; password={senha}";
    }
}
