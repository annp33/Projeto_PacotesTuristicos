using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DestinoCerto.Models;

namespace DestinoCerto.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PacotesTuristicos()
        {
            PacotesTuristicosRepository dados = new PacotesTuristicosRepository();
            List<PacotesTuristicos> listagemDePacotes = dados.Listar();
            return View(listagemDePacotes);
        }

        public IActionResult CadastrarPacotes()
        {
            if(HttpContext.Session.GetInt32("IdUsuario")==null){
                return RedirectToAction("Login", "Home");
            }else{
                return View();
            }
        }

        [HttpPost]
        public IActionResult CadastrarPacotes(PacotesTuristicos dado)
        {
            PacotesTuristicosRepository dados = new PacotesTuristicosRepository();
            dados.Inserir(dado);
            ViewBag.Mensagem = "Pacote cadastrado com sucesso!!!";
            return View();
        }

        public IActionResult ListarPacotes()
        {
            if(HttpContext.Session.GetInt32("IdUsuario")==null){
                return RedirectToAction("Login", "Home");
            }else{
                PacotesTuristicosRepository dados = new PacotesTuristicosRepository();
                List<PacotesTuristicos> listagemDePacotes = dados.Listar();
                return View(listagemDePacotes);
            }
        }

        public IActionResult RemoverPacotes(int Id)
        {
            if(HttpContext.Session.GetInt32("IdUsuario")==null){
                return RedirectToAction("Login", "Home");
            }else{
                PacotesTuristicosRepository dados = new PacotesTuristicosRepository();
                PacotesTuristicos pacoteLocalizado = dados.BuscarPorId(Id);
                dados.Excluir(pacoteLocalizado);
                return RedirectToAction("ListarPacotes", "Home"); // ("view", "controller")
            } 
        }

        public IActionResult EditarPacotes(int Id)
        {
            if(HttpContext.Session.GetInt32("IdUsuario")==null){
                return RedirectToAction("Login", "Home");
            }else{
                PacotesTuristicosRepository dados = new  PacotesTuristicosRepository();
                PacotesTuristicos pacoteLocalizado = dados.BuscarPorId(Id);
                return View(pacoteLocalizado);
            }
        }

        [HttpPost]
        public IActionResult EditarPacotes(PacotesTuristicos dado)
        {
            PacotesTuristicosRepository dados = new PacotesTuristicosRepository();
            dados.Alterar(dado);
            return RedirectToAction("ListarPacotes", "Home");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Usuario user)
        {
            UsuariosRepository u = new UsuariosRepository();
            Usuario usuarioEncontrado = u.ValidarLogin(user);

            if(usuarioEncontrado == null)
            {
                ViewBag.Mensagem = "Login ou senha incorretos!!!";
                return View(); 
            } else{
                HttpContext.Session.SetInt32("IdUsuario", usuarioEncontrado.IdUsuario);
                HttpContext.Session.SetString("Nome", usuarioEncontrado.Nome); 
                return RedirectToAction("ListarPacotes", "Home");
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
