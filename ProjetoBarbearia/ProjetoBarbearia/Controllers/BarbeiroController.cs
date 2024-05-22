using Microsoft.AspNetCore.Mvc;
using ProjetoBarbearia.DAO;

namespace ProjetoBarbearia.Controllers
{
    public class BarbeiroController : PadraoController
    {

        private BarbeiroDAO barbeiroDAO;

        public BarbeiroController()
        {
            barbeiroDAO = new BarbeiroDAO();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
