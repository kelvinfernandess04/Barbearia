using Microsoft.Data.SqlClient;
using ProjetoBarbearia.Models;
using System.Data;

namespace ProjetoBarbearia.DAO
{
    public class ReservaDAO : PadraoDAO
    {

        public void AdicionarReserva(ReservaViewModel reserva)
        {
            using (SqlConnection connection = ConexaoBD.GetConexao())
            {
                SqlCommand command = new SqlCommand("AdicionarReserva", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdUsuario", reserva.Usuario.Id);
                command.Parameters.AddWithValue("@IdBarbeiro", reserva.Barbeiro.BarbeiroId);

                command.ExecuteNonQuery();
            }
        }

        public void AtualizarReserva(ReservaViewModel reserva)
        {
            using (SqlConnection connection = ConexaoBD.GetConexao())
            {
                SqlCommand command = new SqlCommand("AtualizarReserva", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdUsuario", reserva.Usuario.Id);
                command.Parameters.AddWithValue("@IdBarbeiro", reserva.Barbeiro.BarbeiroId);
                command.Parameters.AddWithValue("@DataHora", reserva.DataHora);

                command.ExecuteNonQuery();
            }
        }

        public void ExcluirReserva(int usuarioId)
        {
            using (SqlConnection connection = ConexaoBD.GetConexao())
            {
                SqlCommand command = new SqlCommand("ExcluirReserva", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UsuarioId", usuarioId);

                command.ExecuteNonQuery();
            }
        }

        public List<ReservaViewModel> ListarReservas()
        {
            return Listar<ReservaViewModel>("ListarReservas");
        }

        public List<ReservaViewModel> ListarReservasComInformacoes()
        {
            List<ReservaViewModel> reservas = new List<ReservaViewModel>();

            using (SqlConnection connection = ConexaoBD.GetConexao())
            {
                SqlCommand command = new SqlCommand("ListarReservasComInformacoes", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var reserva = new ReservaViewModel
                    {
                        ReservaId = Convert.ToInt32(reader["IdReserva"]),
                        Usuario = new UsuarioViewModel
                        {
                            NomeUsuario = reader["NomeUsuario"].ToString(),
                            Email = reader["Email"].ToString()
                        },
                        Barbeiro = new BarbeiroViewModel
                        {
                            NomeBarbeiro = reader["NomeBarbeiro"].ToString()
                        },
                        DataHora = Convert.ToDateTime(reader["DataHora"])
                    };

                    reservas.Add(reserva);
                }
            }

            return reservas;
        }
    }
}
