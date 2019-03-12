using Proyecto.Logica.Models;
using Proyecto.Web.Controllers;
using System;
using System.Web;

namespace Proyecto.Web.Views.Login
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Session["sessionEmail"] = txtEmal.Text;

            //ctrl + k +c == comentario
            //ctrl + k + u == descomentar
            //if (!IsPostBack)
            //    ClientScript.RegisterStartupScript(this.GetType(), "messaje", "<script> swal('Buen trabajo!', 'Se realizo el proceso con exito!', 'success')</script>");
            if (!IsPostBack)
            {
                if (Request.Cookies["cookieEmail"] != null)
                {
                    txtEmal.Text = Request.Cookies["cookieEmail"].Value.ToString();
                    chkRecordar.Checked = true;
                }
            }
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
                {
                    if (chkRecordar.Checked)
                    {
                        //creo un objeto cookie
                        HttpCookie cookie = new HttpCookie("cookieEmail", txtEmal.Text);
                        cookie.Expires = DateTime.Now.AddDays(2); //adiciona tiempo de vida
                        Response.Cookies.Add(cookie); //se agrega a la coleccion de cookies
                    } else
                    {
                        HttpCookie cookie = new HttpCookie("cookieEmail", txtEmal.Text);
                        cookie.Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies.Add(cookie);
                    }
                    //Response.Redirect("../Index/Index.aspx"); //redirecciona
                    Response.Redirect("../Index/Index.aspx?strEmail=" + txtEmal.Text); //parametros por url
                } 
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