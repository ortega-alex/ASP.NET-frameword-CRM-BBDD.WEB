using Proyecto.Logica.Models;
using Proyecto.Web.Controllers;
using System;

namespace Proyecto.Web.Views.Login
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ctrl + k +c == comentario
            //ctrl + k + u == descomentar
            //if (!IsPostBack)
            //    ClientScript.RegisterStartupScript(this.GetType(), "messaje", "<script> swal('Buen trabajo!', 'Se realizo el proceso con exito!', 'success')</script>");
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                string stMessaje = string.Empty;
                if (string.IsNullOrEmpty(txtEmal.Text)) stMessaje += "Ingrese email, ";
                if (string.IsNullOrEmpty(txtPass.Text)) stMessaje += "Ingrese password,";
                if (!string.IsNullOrEmpty(stMessaje)) throw new Exception(stMessaje.TrimEnd(','));

                //defino objeto con propiedades
                Usuario usuario = new Usuario
                {
                    Username = txtEmal.Text,
                    Password = txtPass.Text
                };

                //instancia el controlador
                LoginController loginController = new LoginController();
                bool blBandera = loginController.getValidarUsuario(usuario);

                if (blBandera)
                    Response.Redirect("../Index/Index.aspx"); //redirecciona
                else
                    throw new Exception("Usuario o Password incorecto");
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "messaje", "<script> swal('Error!', '" + ex.Message + "!', 'error')</script>");
            }
        }
    }
}