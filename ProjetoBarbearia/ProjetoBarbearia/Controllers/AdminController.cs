using Microsoft.AspNetCore.Mvc;
using ProjetoBarbearia.DAO;
using ProjetoBarbearia.Models;

namespace ProjetoBarbearia.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public ActionResult ListarReservas()
        {
            ReservaDAO reservaDAO = new ReservaDAO();
            List<ReservaViewModel> reservas = reservaDAO.ListarReservasComInformacoes();
            return View(reservas);
        }
    }
}
