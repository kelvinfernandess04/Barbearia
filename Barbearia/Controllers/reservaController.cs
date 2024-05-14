using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Barbearia.DAO;
using Barbearia.Models;

namespace Barbearia.Controllers
{
    public class ReservaController : Controller
    {
        // Método para validar os dados da reserva
        private void ValidaDados(ReservaViewModel reserva, string operacao)
        {
            ModelState.Clear();

            ReservaDAO dao = new ReservaDAO();
            if (operacao == "I" && dao.Consulta(reserva.Id) != null)
                ModelState.AddModelError("Id", "Código já está em uso.");
            // Adicione outras validações conforme necessário

            if (reserva.Data < DateTime.Today)
                ModelState.AddModelError("Data", "A data da reserva não pode ser no passado.");

            // Adicione outras validações conforme necessário
        }

        // Método para exibir a tela de criação de reserva
        public IActionResult Create()
        {
            ViewBag.Operacao = "I";
            ReservaViewModel reserva = new ReservaViewModel();
            // Preencha outros dados da reserva conforme necessário
            return View("Form", reserva);
        }

        // Método para salvar uma nova reserva ou atualizar uma existente
        public IActionResult Salvar(ReservaViewModel reserva, string operacao)
        {
            try
            {
                ValidaDados(reserva, operacao);

                if (ModelState.IsValid == false)
                {
                    ViewBag.Operacao = operacao;
                    return View("Form", reserva);
                }
                else
                {
                    ReservaDAO dao = new ReservaDAO();
                    if (operacao == "I")
                        dao.Incluir(reserva);
                    else
                        dao.Alterar(reserva);

                    return RedirectToAction("Index");
                }
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

        // Método para listar todas as reservas
        public IActionResult Index()
        {
            ReservaDAO dao = new ReservaDAO();
            List<ReservaViewModel> lista = dao.Listar();
            return View(lista);
        }

        // Método para editar uma reserva existente
        public IActionResult Edit(int id)
        {
            try
            {
                ViewBag.Operacao = "A";
                ReservaDAO dao = new ReservaDAO();
                ReservaViewModel reserva = dao.Consulta(id);
                if (reserva == null)
                    return RedirectToAction("Index");
                else
                    return View("Form", reserva);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }
    }
}
