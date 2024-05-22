using Microsoft.AspNetCore.Mvc;
using ProjetoBarbearia.DAO;
using ProjetoBarbearia.Models;

namespace ProjetoBarbearia.Controllers
{
    [Route("usuario")]
    public class UsuarioController : PadraoController
    {
        private UsuarioDAO usuarioDAO;

        public UsuarioController()
        {
            usuarioDAO = new UsuarioDAO();
        }

        [HttpGet("disponiveis")]
        public ActionResult Usuario()
        {
            BarbeiroDAO barbeiroDAO = new BarbeiroDAO();
            var barbeirosDisponiveis = barbeiroDAO.ListarBarbeiros();
            return View(barbeirosDisponiveis);
        }

        [HttpPost("reservar")]
        public ActionResult Usuario(DateTime dataHora, int barbeiroId)
        {
            ReservaDAO reservaDAO = new ReservaDAO();
            BarbeiroDAO barbeiroDAO = new BarbeiroDAO();
            ReservaViewModel reserva = new ReservaViewModel
            {
                DataHora = dataHora
            };

            foreach (BarbeiroViewModel barbeiro in barbeiroDAO.ListarBarbeiros())
            {
                if (barbeiro.BarbeiroId == barbeiroId)
                {
                    reserva.Barbeiro = barbeiro;
                    break; // Adicionei um break para parar a iteração uma vez que o barbeiro é encontrado
                }
            }

            reservaDAO.AdicionarReserva(reserva);

            TempData["Mensagem"] = "Reserva realizada com sucesso!";
            return RedirectToAction("RegistrarReserva");
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
