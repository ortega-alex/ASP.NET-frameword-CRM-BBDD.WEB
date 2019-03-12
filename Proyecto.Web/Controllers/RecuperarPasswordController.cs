using Proyecto.Logica.BL;
using Proyecto.Logica.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Proyecto.Web.Controllers
{
    public class RecuperarPasswordController
    {
        public DataSet getConsultarPasswordo(Usuario usuario)
        {
            try
            {
                RecuperarPassBl recuperarPassBl = new RecuperarPassBl();
                return recuperarPassBl.getConsultarPasswordo(usuario);
            } catch (Exception ex) { throw ex; }
        }

        public void setEmailController(Correo correo)
        {
            try
            {
                GeneralBl generalBl = new GeneralBl();
                generalBl.setEmail(correo);
            }
            catch (Exception ex) { throw ex; }
        }
    }  
}