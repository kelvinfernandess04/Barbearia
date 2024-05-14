using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Barbearia.Models;

namespace Barbearia.DAO
{
    public class ReservaDAO
    {
        private SqlParameter[] CriaParametros(ReservaViewModel reserva)
        {
            SqlParameter[] parametros =
            {
                new SqlParameter("@Id", reserva.Id),
                new SqlParameter("@Data", reserva.Data),
                // Adicione outros parâmetros conforme necessário para a reserva
            };
            return parametros;
        }

        public void Incluir(ReservaViewModel reserva)
        {
            string sql =
                @"
                INSERT INTO Reservas
                (Id, Data) 
                VALUES 
                (@Id, @Data)";

            HelperDAO.ExecutaSQL(sql, CriaParametros(reserva));
        }

        public void Alterar(ReservaViewModel reserva)
        {
            string sql =
                @"
                UPDATE Reservas
                SET Data = @Data
                WHERE Id = @Id";

            HelperDAO.ExecutaSQL(sql, CriaParametros(reserva));
        }

        public void Excluir(int id)
        {
            string sql = $"DELETE FROM Reservas WHERE Id = {id}";
            HelperDAO.ExecutaSQL(sql, null);
        }

        private ReservaViewModel MontaReserva(DataRow registro)
        {
            return new ReservaViewModel()
            {
                Id = Convert.ToInt32(registro["Id"]),
                Data = Convert.ToDateTime(registro["Data"]),
                // Adicione outros campos conforme necessário para a reserva
            };
        }

        public ReservaViewModel Consulta(int id)
        {
            string sql = $"SELECT * FROM Reservas WHERE Id = {id}";
            DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
            if (tabela.Rows.Count > 0)
                return MontaReserva(tabela.Rows[0]);
            else
                return null;
        }

        public List<ReservaViewModel> Listar()
        {
            string sql = "SELECT * FROM Reservas ORDER BY Data";
            DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
            var lista = new List<ReservaViewModel>();
            foreach (DataRow registro in tabela.Rows)
                lista.Add(MontaReserva(registro));

            return lista;
        }

        public int ProximoId()
        {
            string sql = "SELECT ISNULL(MAX(Id) + 1, 1) AS 'MAIOR' FROM Reservas";
            DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
            return Convert.ToInt32(tabela.Rows[0]["MAIOR"]);
        }
    }
}
