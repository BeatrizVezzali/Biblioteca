using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Biblioteca.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Lista(string Nome, string Login, int Tipo)
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeUsuarioEAdmin(this);

            return View(new UsuarioService().Listar());
        }

        public IActionResult NeedAdmin()
        {
            return View();
        }

        public IActionResult Registro(string Nome, string Login, string Senha)
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeUsuarioEAdmin(this);

           return View();
        }

        public IActionResult Editar()
        {
           Autenticacao.CheckLogin(this);
           Autenticacao.verificaSeUsuarioEAdmin(this);

            return View();
        }


        [HttpPost]

        public IActionResult Registro(Usuario novoUser)
        {
            novoUser.Senha = Criptografo.TextoCriptografado(novoUser.Senha);

           return RedirectToAction("Lista");
        }

        public IActionResult Editar(Usuario oldUser)
        {
          Autenticacao.CheckLogin(this);
          Autenticacao.verificaSeUsuarioEAdmin(this);

          BibliotecaContext bc = new BibliotecaContext();

          Usuario u = bc.Usuarios.Find(oldUser);

          new UsuarioService().EditarUsuario(oldUser);

          return View();
        }

        public IActionResult Excluir()
        {
            return View();
        }

    }
}