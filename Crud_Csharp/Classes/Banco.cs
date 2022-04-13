using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace Crud_Csharp.Classes
{
    /// <summary>
     /// Conectar no banco
     /// </summary>
    public static class Banco
    {
        // Metodo Conexão
        public static MySqlCommand Abrir()
        {
            // Objeto para comando SQL
            MySqlCommand cmdSQL = new MySqlCommand();

            // String de conexão
            string stringDeConexao = @"server=localhost;database=db_cliente;user id=root;password=;port=3306";

            // Conectando
            MySqlConnection conexao = new MySqlConnection(stringDeConexao);

            // Exceção
            try // Faça
            {
                // Se o status de conexão for diferente do que aberto
                if (conexao.State != ConnectionState.Open)
                {
                    // Entrega conexão
                    conexao.Open();
                    cmdSQL.Connection = conexao;
                }
            }
            catch (Exception) // Caso aconteça erro
            {
                throw;
            }

            // Retornando objeto de comandos SQL
            return cmdSQL;
        }

    }
}
