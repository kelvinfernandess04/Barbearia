using System.Data.SqlClient;

namespace Barbearia.DAO
{
    public static class ConexaoBD
    {
        /// <summary>
        /// Método estático que retorna uma conexão aberta com o BD
        /// </summary>
        /// <returns>Conexão aberta</returns>
        public static SqlConnection GetConexao()
        {
            string strCon = "Data Source=LOCALHOST; Database=lp1; Integrated Security=true";
            SqlConnection conexao = new SqlConnection(strCon);
            conexao.Open();
            return conexao;
        }
    }
}
