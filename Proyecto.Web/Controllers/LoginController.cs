using Proyecto.Logica.BL;
using Proyecto.Logica.Models;
using System;

namespace Proyecto.Web.Controllers
{
    public class LoginController
    {
        /// <summary>
        /// valida usuario
        /// </summary>
        /// <param name="usuario">objeto usuario</param>
        /// <returns>confirmacion</returns>
        public bool getValidarUsuario(Usuario usuario)
        {
            try
            {
                UsuarioBl usuarioBl = new UsuarioBl();
                return usuarioBl.getValidarUsuario(usuario);
            } catch(Exception ex) { throw ex; }
        }
    }
}