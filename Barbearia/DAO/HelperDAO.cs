using System.Data.SqlClient;
using System.Data;
using System.Linq;

namespace Barbearia.DAO
{
    public class HelperDAO
    {
        /// <summary>
        /// Executa um comando SQL de forma genérica (INSERT, UPDATE, DELETE).
        /// </summary>
        /// <param name="sql">Comando SQL a ser executado.</param>
        /// <param name="parametros">Parâmetros do comando SQL.</param>
        public static void ExecutaSQL(string sql, SqlParameter[] parametros)
        {
            using (var conexao = ConexaoBD.GetConexao())
            {
                using (var command = new SqlCommand(sql, conexao))
                {
                    if (parametros != null)
                        command.Parameters.AddRange(parametros);
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Executa um comando SQL de SELECT e retorna o resultado em um DataTable.
        /// </summary>
        /// <param name="sql">Comando SQL de SELECT a ser executado.</param>
        /// <param name="parametros">Parâmetros do comando SQL.</param>
        /// <returns>DataTable contendo os resultados da consulta.</returns>
        public static DataTable ExecutaSelect(string sql, SqlParameter[] parametros)
        {
            using (SqlConnection conexao = ConexaoBD.GetConexao())
            {
                using (SqlDataAdapter sqlCommand = new SqlDataAdapter(sql, conexao))
                {
                    if (parametros?.Count() > 0)
                        sqlCommand.SelectCommand.Parameters.AddRange(parametros);
                    DataTable tabela = new DataTable();
                    sqlCommand.Fill(tabela);
                    return tabela;
                }
            }
        }
    }
}
