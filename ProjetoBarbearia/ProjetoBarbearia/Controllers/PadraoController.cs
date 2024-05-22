using Microsoft.AspNetCore.Mvc;

namespace ProjetoBarbearia.Controllers
{
    public class PadraoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
