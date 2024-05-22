using Microsoft.AspNetCore.Mvc;
using ProjetoBarbearia.DAO;

namespace ProjetoBarbearia.Controllers
{
    public class ReservaController : PadraoController
    {

        private ReservaDAO reservaDAO;

        public ReservaController()
        {
            reservaDAO = new ReservaDAO();
        }

        // Implemente as actions da controller aqui
        public IActionResult Index()
        {
            return View();
        }
    }
}
