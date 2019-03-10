using Proyecto.Logica.Models;
using Proyecto.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto.Web.Views.RecuperarPassword
{
    public partial class RecuperarPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                string stMensaje = string.Empty;
                if (string.IsNullOrEmpty(txtEmail.Text)) stMensaje += "Ingrese email";
                if (!string.IsNullOrEmpty(stMensaje)) throw new Exception(stMensaje);
                RecuperarPasswordController recuperarPasswordController = new RecuperarPasswordController();
                Usuario usuario = new Usuario
                {
                    Username = txtEmail.Text
                };
                DataSet dsConsulta = recuperarPasswordController.getConsultarPasswordo(usuario);
                if (dsConsulta.Tables[0].Rows.Count > 0)
                {
                    string[] username = dsConsulta.Tables[0].Rows[0]["username"].ToString().Split('@');
                    string password = dsConsulta.Tables[0].Rows[0]["password"].ToString();
                    string stCuercoHtml = "<!DOCTYPE html>";
                    stCuercoHtml += "<html lang='en'>";
                    stCuercoHtml += "<head>";
                    stCuercoHtml += "	<meta charset='UTF-8'>";
                    stCuercoHtml += "	<title>Recuperar de correo</title>";
                    stCuercoHtml += "</head>";
                    stCuercoHtml += "<body style='background-color:black; '>";
                    stCuercoHtml += "	<table style='max-width: 600px; padding: 10px; margin: 0 auto; border-collapse: collapse;'>";
                    stCuercoHtml += "		<tr>";
                    stCuercoHtml += "			<td style='padding: 0; '>";
                    stCuercoHtml += "				<img style='padding: 0; display: block; ' src='cid:Fondo' width='100% ' height='100%'>";
                    stCuercoHtml += "			</td>";
                    stCuercoHtml += "		</tr>";
                    stCuercoHtml += "		<tr>";
                    stCuercoHtml += "			<td style='background-color: #ecf0f1;'>";
                    stCuercoHtml += "				<div style='color: #34495e; margin: 4% 10% 2%; text-align: justify; font-family: sans-serif;'>";
                    stCuercoHtml += "					<h2 style='color: #e67e22: margin: 0 0 7px;'>Hola "+ username[0] + "</h2>";
                    stCuercoHtml += "					<p style='margin: 2px; font-size: 15px; '>";
                    stCuercoHtml += "						Hemos recibido una solicitud para restablecer el password de su cuenta asociada con esta dirreccion de correo electronico. si no ha realizado esta solicitud, puede ignorar este correo electronico y le garantizamos que su cuenta es completamente segura.";
                    stCuercoHtml += "						<br>";
                    stCuercoHtml += "						<br>";
                    stCuercoHtml += "						su password es: "+ password;
                    stCuercoHtml += "					</p>";
                    stCuercoHtml += "					<p style='color: #b3b3b3: font-size: 12px; text-align: center; margin: 30px 0 0;'>";
                    stCuercoHtml += "						Copyright @ CRM 2019";
                    stCuercoHtml += "					</p>";
                    stCuercoHtml += "				</div>";
                    stCuercoHtml += "			</td>";
                    stCuercoHtml += "		</tr>";
                    stCuercoHtml += "	</table>";
                    stCuercoHtml += "</body>";
                    stCuercoHtml += "</html>";


                    Correo correo = new Correo
                    {
                        Servidor = ConfigurationManager.AppSettings["stServidor"].ToString(),
                        Usuairo = ConfigurationManager.AppSettings["stUsuario"].ToString(),
                        Password = ConfigurationManager.AppSettings["stPassword"].ToString(),
                        Puerto = ConfigurationManager.AppSettings["stPuerto"].ToString(),
                        Autenticacion = true,
                        ConexionSegura = true,
                        Prioridad = 0 , //normal
                        Tipo = 1 , //html
                        Asunto = "Recuperarcion de password",
                        From = ConfigurationManager.AppSettings["stUsuario"].ToString(),
                        To = txtEmail.Text,
                        Image = Server.MapPath("~") + @"\Resoutces\Images\tux.gif",
                        IdImage = "Fondo",
                        Mensaje = stCuercoHtml
                    };

                    recuperarPasswordController.setEmailController(correo);
                    ClientScript.RegisterStartupScript(this.GetType(), "messaje", "<script> swal('Success!', 'Se realizo proceso con exito', 'success')</script>");

                }
                else
                {
                    throw new Exception("no se encontro informacion asociada a ese correo");
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "messaje", "<script> swal('Error!', '" + ex.Message + "!', 'error')</script>");
            }
        }
    }
}