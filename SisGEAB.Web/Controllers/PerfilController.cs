using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SisGEAB.Domain.Contracts;
using SisGEAB.Domain.Models;
using SisGEAB.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisGEAB.Web.Controllers
{
    public class PerfilController : Controller
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly IAccountManager _accountManager;
        private readonly IUnitOfWork _unitOfWork;

        public PerfilController(IAccountManager accountManager, IUnitOfWork unitOfWork, UserManager<Usuario> userManager)
        {
            _accountManager = accountManager;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            // RETORNO O USUARIO PELO USERNAME QUE É O CPF
            var atual = await _accountManager.GetUserByUserNameAsync(User.Identity.Name);            

            if (atual == null) return NotFound();

            //var enfermeiro = await _unitOfWork.Enfermeiros.SelecionarPorCPF(atual.CPF);
            //var acs = string.Empty;
            //var adsministrativo = string.Empty;

            //// inicializo as view models
            //var usuarioModel = new UsuarioPerfilViewModel();
            //var enfermeiroModel = new EnfermeiroPerfilViewModel();

            //var model = new PerfilViewModel();

            //usuarioModel.CPF = atual.CPF;
            //usuarioModel.NomeCompleto = atual.NomeCompleto;
            //usuarioModel.Logins = await _userManager.GetLoginsAsync(atual);
            //usuarioModel.Email = atual.Email;
            //usuarioModel.TituloProfissional = atual.TituloProfissional;

            //if (enfermeiro != null)
            //{
            //    model.Cargo = "Enfermeiro";
            //}

            //model.Usuario = usuarioModel;
            //model.Enfermeiro = enfermeiroModel;

            var model = await PerfilViewModel(atual);

            return View(model);
        }

        public async Task<IActionResult> AtualizaUsuario(UsuarioPerfilViewModel model)
        {
            var user = await _accountManager.GetUserByUserNameAsync(User.Identity.Name);
            var perfil = await PerfilViewModel(user);

            if (ModelState.IsValid)
            {
                user.Email = model.Email;
                user.NomeCompleto = model.NomeCompleto;
                user.TituloProfissional = model.TituloProfissional;

                await _accountManager.UpdateUserAsync(user);

                return RedirectToAction("Index", "Perfil", perfil);
            }

            return View(perfil);
        }

        private async Task<PerfilViewModel> PerfilViewModel(Usuario user)
        {
            var enfermeiro = await _unitOfWork.Enfermeiros.SelecionarPorCPF(user.CPF);
            //todo
            var acs = string.Empty;
            //todo
            var adsministrativo = string.Empty;

            // inicializo as view models
            var usuarioModel = new UsuarioPerfilViewModel();
            var enfermeiroModel = new EnfermeiroPerfilViewModel();
            var acsModel = new AgenteDeSaudePerfilViewModel();
            var pacienteModel = new PacientePerfilViewModel();
            var administrativoModel = new AdministrativoPerfilViewModel();

            var perfil = new PerfilViewModel();

            usuarioModel.CPF = user.CPF;
            usuarioModel.NomeCompleto = user.NomeCompleto;
            usuarioModel.Logins = await _userManager.GetLoginsAsync(user);
            usuarioModel.Email = user.Email;
            usuarioModel.TituloProfissional = user.TituloProfissional;

            if (enfermeiro != null)
            {
                perfil.Cargo = "Enfermeiro";
            }

            perfil.ACS = acsModel;
            perfil.Administrativo = administrativoModel;
            perfil.Enfermeiro = enfermeiroModel;
            perfil.Paciente = pacienteModel;
            perfil.Usuario = usuarioModel;

            return perfil;
        }
    }
}
