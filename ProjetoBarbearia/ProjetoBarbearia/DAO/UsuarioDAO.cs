using Microsoft.Data.SqlClient;
using ProjetoBarbearia.Models;
using System.Data;

namespace ProjetoBarbearia.DAO
{
    public class UsuarioDAO : PadraoDAO
    {
        public void AdicionarUsuario(UsuarioViewModel usuario)
        {
            using (SqlConnection connection = ConexaoBD.GetConexao())
            {
                SqlCommand command = new SqlCommand("AdicionarUsuario", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@NomeUsuario", usuario.NomeUsuario);
                command.Parameters.AddWithValue("@Email", usuario.Email);
                command.Parameters.AddWithValue("@Senha", usuario.Senha);
                command.Parameters.AddWithValue("@IsAdmin", usuario.IsAdmin);

                command.ExecuteNonQuery();
            } 
        }

        public void AtualizarUsuario(UsuarioViewModel usuario)
        {
            using (SqlConnection connection = ConexaoBD.GetConexao())
            {
                SqlCommand command = new SqlCommand("AtualizarUsuario", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", usuario.Id);
                command.Parameters.AddWithValue("@NomeUsuario", usuario.NomeUsuario);
                command.Parameters.AddWithValue("@Email", usuario.Email);
                command.Parameters.AddWithValue("@Senha", usuario.Senha);
                command.Parameters.AddWithValue("@IsAdmin", usuario.IsAdmin);

                command.ExecuteNonQuery();
            }
        }

        public void ExcluirUsuario(int id)
        {
            using (SqlConnection connection = ConexaoBD.GetConexao())
            {
                SqlCommand command = new SqlCommand("ExcluirUsuario", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }
        }

        public UsuarioViewModel BuscarUsuarioPorCredenciais(string nome, string senha)
        {
            UsuarioViewModel usuario = null;

            using (SqlConnection connection = ConexaoBD.GetConexao())
            {
                SqlCommand command = new SqlCommand("BuscarUsuarioPorCredenciais", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@NomeUsuario", nome);
                command.Parameters.AddWithValue("@Senha", senha);

                //connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    usuario = new UsuarioViewModel
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        NomeUsuario = reader["NomeUsuario"].ToString(),
                        Email = reader["Email"].ToString(),
                        Senha = reader["Senha"].ToString(),
                        IsAdmin = Convert.ToBoolean(reader["IsAdmin"])
                    };
                }

                return usuario;
            }
        }

            public List<UsuarioViewModel> ListarUsuarios()
        {
            return Listar<UsuarioViewModel>("ListarUsuarios");
        }
    }
}
