using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class UsuariosController : Controller
    {
        public IActionResult Lista()
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeUsuarioEAdmin(this);
            return View(new UsuarioService().Listar());
        }

        public IActionResult NeedAdmin()
        {
            return View();
        }

        public IActionResult Registro()
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