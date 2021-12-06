using Microsoft.AspNetCore.Mvc;
using SisGEAB.Domain.Contracts;
using SisGEAB.Domain.Data;
using SisGEAB.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisGEAB.Web.Controllers
{
    public class ContaController : Controller
    {
        private readonly Contexto _context;
        private readonly IAccountManager _conta;

        public ContaController(Contexto context, IAccountManager conta)
        {
            _context = context;
            _conta = conta;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _conta.Login(model.NomeUsuario, model.Senha, model.Lembrarme);
                if (result.Succeeded)
                {
                    if (Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return Redirect(Request.Query["ReturnUrl"].First());
                    }

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "User or password incorrect.");
            }

            return View(model);
        }
    }
}
