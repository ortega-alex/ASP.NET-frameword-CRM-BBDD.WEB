using Proyecto.Logica.Models;
using Proyecto.Web.Controllers;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Proyecto.Web.Views.PosiblesClientes
{
    public partial class PosiblesClientes : System.Web.UI.Page
    {

        #region Metodos y funciones

        /// <summary>
        /// Obtiene cunsuta posibles clientes
        /// </summary>
        void getClientes()
        {
            try
            {
                PosiblesClientesController posiblesClientesController = new PosiblesClientesController();
                DataSet dsConsulta = posiblesClientesController.getPosiblesClientes();

                if (dsConsulta.Tables[0].Rows.Count > 0)
                    gvwDatos.DataSource = dsConsulta;
                else
                    gvwDatos.DataSource = null;

                gvwDatos.DataBind();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "messaje", "<script> swal('Error!', '" + ex.Message + "!', 'error')</script>");
            }
        }

        #endregion

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getClientes();
            }   
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int options = string.IsNullOrEmpty(txtId.Text) ? 1 : 2; ;
                string stMensaje = string.Empty;
                if (string.IsNullOrEmpty(txtNombre.Text)) stMensaje += "Ingrese nombres ,";
                if (string.IsNullOrEmpty(txtApellido.Text)) stMensaje += " Ingrese apellidos ,";
                if (!string.IsNullOrEmpty(stMensaje)) throw new Exception(stMensaje.TrimEnd(','));

                PosibleCliente posibleCliente = new PosibleCliente
                {
                    Id = string.IsNullOrEmpty(txtId.Text) ? 0 : Convert.ToInt32(txtId.Text),
                    Nombres = txtNombre.Text,
                    Apellidos = txtApellido.Text,
                    Correo = txtCorreo.Text,
                    Telefono = txtTelefono.Text,
                    Direccion = txtDireccion.Text
                };

                PosiblesClientesController posiblesClientesController = new PosiblesClientesController();

                ClientScript.RegisterStartupScript(this.GetType(), "messaje", "<script> swal('Success!', '" + posiblesClientesController.getAdministrarPosiblesClientes(posibleCliente , options ) + "!', 'success')</script>");
                txtId.Text = txtNombre.Text = txtApellido.Text = txtCorreo.Text = txtDireccion.Text = txtTelefono.Text = txtDireccion.Text = string.Empty;
                getClientes();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "messaje", "<script> swal('Error!', '" + ex.Message + "!', 'error')</script>");
            }
        }

        protected void gvwDatos_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            try
            {
                int inIdice = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName.Equals("Editar"))
                {
                    txtId.Text = gvwDatos.DataKeys[inIdice].Value.ToString();
                    txtNombre.Text = ((Label)gvwDatos.Rows[inIdice].FindControl("lblNombres")).Text;
                    txtApellido.Text = gvwDatos.Rows[inIdice].Cells[2].Text;
                    txtCorreo.Text = gvwDatos.Rows[inIdice].Cells[3].Text;
                    txtTelefono.Text = gvwDatos.Rows[inIdice].Cells[4].Text;
                    txtDireccion.Text = gvwDatos.Rows[inIdice].Cells[5].Text;
                } else if (e.CommandName.Equals("Eliminar")) 
                {
                    PosibleCliente posibleCliente = new PosibleCliente
                    {
                        Id = (int)gvwDatos.DataKeys[inIdice].Value,
                        Nombres = string.Empty,
                        Apellidos = string.Empty,
                        Correo = string.Empty,
                        Telefono = string.Empty,
                        Direccion = string.Empty
                    };                   
                    PosiblesClientesController posiblesClientesController = new PosiblesClientesController();
                    ClientScript.RegisterStartupScript(this.GetType(), "messaje", "<script> swal('Success!', '" + posiblesClientesController.getAdministrarPosiblesClientes(posibleCliente, 3) + "!', 'success')</script>");
                    getClientes();
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "messaje", "<script> swal('Error!', '" + ex.Message + "!', 'error')</script>");
            }
        }
        #endregion
    }
}