using Microsoft.Data.SqlClient;
using ProjetoBarbearia.Models;
using System.Data;

namespace ProjetoBarbearia.DAO
{
    public class BarbeiroDAO : PadraoDAO
    {

        public void AdicionarBarbeiro(BarbeiroViewModel barbeiro)
        {
            using (SqlConnection connection = ConexaoBD.GetConexao())
            {
                SqlCommand command = new SqlCommand("AdicionarBarbeiro", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@NomeBarbeiro", barbeiro.NomeBarbeiro);

                command.ExecuteNonQuery();
            }
        }

        public void AtualizarBarbeiro(BarbeiroViewModel barbeiro)
        {
            using (SqlConnection connection = ConexaoBD.GetConexao())
            {
                SqlCommand command = new SqlCommand("AtualizarBarbeiro", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@BarbeiroId", barbeiro.BarbeiroId);
                command.Parameters.AddWithValue("@NomeUsuario", barbeiro.NomeBarbeiro);

                command.ExecuteNonQuery();
            }
        }

        public void ExcluirBarbeiro(int barbeiroId)
        {
            using (SqlConnection connection = ConexaoBD.GetConexao())
            {
                SqlCommand command = new SqlCommand("ExcluirBarbeiro", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@BarbeiroId", barbeiroId);

                command.ExecuteNonQuery();
            }
        }

        public List<BarbeiroViewModel> ListarBarbeiros()
        {
            return Listar<BarbeiroViewModel>("ListarBarbeiros");
        }
    }
}
