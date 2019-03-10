using Proyecto.Logica.BL;
using Proyecto.Logica.Models;
using System;

namespace Proyecto.Web.Controllers
{
    public class RegistroController
    {
        public string setCrearCuenta(Usuario usuario , int option)
        {
            try
            {
                UsuarioBl usuarioBl = new UsuarioBl();
                return usuarioBl.setCrearCuenta(usuario, option);
            } catch (Exception ex) { throw ex; }
        }
    }
}