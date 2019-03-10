using Proyecto.Logica.Models;
using Proyecto.Web.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto.Web.Views.Registro
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                RegistroController registroController = new RegistroController();
                //validacion la seleccion de un imagen
                if (fuImg.HasFile)
                {
                    if (!Path.GetExtension(fuImg.FileName).Equals(".jpg"))
                        throw new Exception("Solo se admiten formatos .jpg");

                    string stRuta = Server.MapPath(@"~\Public\Temp\") + fuImg.FileName;// ruta temporal
                    fuImg.PostedFile.SaveAs(stRuta);// guardando el archivo dentro de proyecto
                    string stRutaDestino = Server.MapPath(@"~\Public\Img\") + txtUsername.Text + Path.GetExtension(fuImg.FileName); //ruta destino
                    if (File.Exists(stRutaDestino))
                    { //si exite lo elimina
                        File.SetAttributes(stRutaDestino, FileAttributes.Normal);
                        File.Delete(stRutaDestino);
                    }

                    File.Copy(stRuta, stRutaDestino); //copia imagen
                    File.SetAttributes(stRuta, FileAttributes.Normal);
                    File.Delete(stRuta);

                    Usuario usuario = new Usuario
                    {
                        Username = txtUsername.Text,
                        Password = txtPass.Text,
                        Img = stRutaDestino
                    };

                    ClientScript.RegisterStartupScript(this.GetType(), "messaje", "<script> swal('Mensaje!', '" + registroController.setCrearCuenta(usuario, 1) + "!', 'success')</script>");
                } 
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "messaje", "<script> swal('Error!', '" + ex.Message + "!', 'error')</script>");
            }
        }
    }
}