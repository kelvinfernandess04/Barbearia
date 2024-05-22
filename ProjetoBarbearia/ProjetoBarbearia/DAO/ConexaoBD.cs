using Microsoft.Data.SqlClient;

namespace ProjetoBarbearia.DAO
{
    internal class ConexaoBD
    {
        /// <summary>
        /// Método Estático que retorna um conexao aberta com o BD
        /// </summary>
        /// <returns>Conexão aberta</returns>
        public static SqlConnection GetConexao()
        {
            string strCon = "Data Source=LOCALHOST; Database=lp1; user id=sa; password=Kelvin 2004; TrustServerCertificate=True";
            SqlConnection conexao = new SqlConnection(strCon);
            conexao.Open();
            return conexao;
        }
    }
}
