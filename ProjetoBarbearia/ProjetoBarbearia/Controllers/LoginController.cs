using Microsoft.AspNetCore.Mvc;
using ProjetoBarbearia.DAO;
using ProjetoBarbearia.Models;

namespace ProjetoBarbearia.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string nomeUsuario, string senha)
        {
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            // Lógica de autenticação
            UsuarioViewModel usuario = usuarioDAO.BuscarUsuarioPorCredenciais(nomeUsuario, senha);

            if (usuario != null)
            {
                if (usuario.IsAdmin)
                {
                    return RedirectToAction("Index", "ListarReservas");
                }
                else
                {
                    return RedirectToAction("Index", "RegistrarReserva");
                }
            }
            else
            {
                TempData["ErroLogin"] = "Nome de usuário ou senha inválidos.";
                return RedirectToAction("Login");
            }
        }

        public ActionResult Registrar(UsuarioViewModel novoUsuario)
        {
            UsuarioDAO usuarioDAO = new UsuarioDAO();

            if (ModelState.IsValid)
            {


                List<UsuarioViewModel> lista = usuarioDAO.ListarUsuarios();
                
                if (lista.Contains(novoUsuario))
                {
                    ModelState.AddModelError("", "Usuário já existe no sistema.");
                    return View(novoUsuario);
                }

                // Adiciona o novo usuário
                usuarioDAO.AdicionarUsuario(novoUsuario);

                // Redireciona para a página de login após o registro bem-sucedido
                return RedirectToAction("Login", "Autenticacao");
            }

            // Se houver erros de validação, retorna a view com os erros
            return View(novoUsuario);
        }
    }
}
