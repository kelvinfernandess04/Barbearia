using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection;

namespace ProjetoBarbearia.DAO
{
    public class PadraoDAO
    {

        protected List<T> Listar<T>(string nomeProcedure) where T : class, new()
        {
            List<T> lista = new List<T>();

            using (SqlConnection connection = ConexaoBD.GetConexao())
            {
                SqlCommand command = new SqlCommand(nomeProcedure, connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    T item = new T();
                    PropertyInfo[] properties = typeof(T).GetProperties();

                    foreach (PropertyInfo property in properties)
                    {
                        if (reader[property.Name] != DBNull.Value)
                        {
                            property.SetValue(item, reader[property.Name]);
                        }
                    }

                    lista.Add(item);
                }
            }

            return lista;
        }
    }

}
