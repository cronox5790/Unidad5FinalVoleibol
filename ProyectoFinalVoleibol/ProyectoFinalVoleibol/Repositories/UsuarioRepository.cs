using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoFinalVoleibol.Models;


namespace ProyectoFinalVoleibol.Repositories
{
    public class UsuarioRepository : Repository<Usuario>
    {
        public UsuarioRepository(bdvoleibolContext context) : base(context) { }

        public Usuario GetUserById(int id)
        {
            return Context.Usuario.FirstOrDefault(x => x.Id == id);
        }
        public Usuario GetUsuarioByCorreo(string correo)
        {
            return Context.Usuario.FirstOrDefault(x => x.Correo == correo);
        }
        public Usuario GetUser(Usuario id)
        {
            return Context.Find<Usuario>(id);
        }

        public bool Validate(Usuario usuario)
        {
            if (string.IsNullOrEmpty(usuario.NomUser))
                throw new Exception("Ingrese el nombre de usuario.");
            if (string.IsNullOrEmpty(usuario.Correo))
                throw new Exception("Ingrese el correo electrónico del usuario.");
            if (string.IsNullOrEmpty(usuario.Contraseña))
                throw new Exception("Ingrese la contraseña del usuario.");
            return true;
        }

    }
}