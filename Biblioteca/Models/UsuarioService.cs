using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Models
{
    public class UsuarioService
    {
        public List<Usuario> Listar()
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                return bc.Usuarios.ToList();
            }

        }

        public void IncluirUsuario(Usuario user)
        {
           using(BibliotecaContext bc = new BibliotecaContext())
           {
              bc.Usuarios.Add(user);

              bc.SaveChanges();
           }
        }

        public void EditarUsuario(Usuario oldUser)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                Usuario u = bc.Usuarios.Find(oldUser.Id);

                u.Nome = oldUser.Nome;
                u.Login = oldUser.Login;
                u.Senha = oldUser.Senha;
                u.Tipo = oldUser.Tipo;

                bc.SaveChanges();
            }

        }

        public void ExcluirUsuario(int id)
        {
             using(BibliotecaContext bc = new BibliotecaContext())
             {
                bc.Usuarios.Remove(bc.Usuarios.Find(id));

                bc.SaveChanges();
             }

        }

        public void BuscarPorId(int id)
        {
           using(BibliotecaContext bc = new BibliotecaContext())
           {
               bc.Usuarios.Find(id);
           }
        }
    }
}