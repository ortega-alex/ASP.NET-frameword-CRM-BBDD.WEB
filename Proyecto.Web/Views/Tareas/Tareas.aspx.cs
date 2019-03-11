
using Proyecto.Logica.Models;
using Proyecto.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;

namespace Proyecto.Web.Views.Tareas
{
    public partial class Tareas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["sessionEmail"] == null)
                    Response.Redirect("../Login/Login.aspx");

                TareasController tareasController = new TareasController();
                DataSet dsConsultaEstadoTarea = tareasController.getEstadosTareas();
                DataSet dsConsultaPrioridad = tareasController.getPrioridadesTareas();

                //asigno origen de datos
                ddlEstado.DataSource = dsConsultaEstadoTarea;
                ddlEstado.DataTextField = "description"; //lo que se muestra
                ddlEstado.DataValueField = "id"; //lo que equivale
                ddlEstado.DataBind(); //acepte los cambios

                //asigno origen de datos
                ddlPrioridad.DataSource = dsConsultaPrioridad;
                ddlPrioridad.DataTextField = "description"; //lo que se muestra
                ddlPrioridad.DataValueField = "id"; //lo que equivale
                ddlPrioridad.DataBind(); //acepte los cambios

                GetTareas();
            }

        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string stMessaje = string.Empty;
                if (string.IsNullOrEmpty(txtTitulTarea.Text)) stMessaje += "Ingrese El titular ,";
                if (string.IsNullOrEmpty(txtAsunto.Text)) stMessaje += " Ingrese El Asunto ,";
                if (string.IsNullOrEmpty(txtFechaDeVencimiento.Text)) stMessaje += " Ingrese la fecha de vencimiento ,";
                if (string.IsNullOrEmpty(txtContacto.Text)) stMessaje += " Ingrese El contacto ,";
                if (string.IsNullOrEmpty(ddlPrioridad.SelectedValue)) stMessaje += " Seleccione la prioriad ,";
                if (string.IsNullOrEmpty(ddlEstado.SelectedValue)) stMessaje += " Seleccione el estado ,";
                if (!string.IsNullOrEmpty(stMessaje)) throw new Exception(stMessaje.TrimEnd(','));

                Tarea tarea = new Tarea
                {
                    id = string.IsNullOrEmpty(txtId.Text) ? 0 : Convert.ToInt32(txtId.Text) ,
                    titular = txtTitulTarea.Text,
                    asunto = txtAsunto.Text,
                    fechaVencimiento = txtFechaDeVencimiento.Text,
                    contacto = txtContacto.Text,
                    cuenta = txtCuenta.Text,
                    estado = new Estado
                    {
                        id = Convert.ToInt32(ddlEstado.SelectedValue)
                    },
                    prioridad = new Prioridad
                    {
                        id = Convert.ToInt32(ddlPrioridad.SelectedValue)
                    },
                    enviaMensaje = chkEnviarMensaje.Checked ? "S" : "N",
                    repetir = chkRepetir.Checked ? "S" : "N",
                    tareaDescripcion = txtDescripcion.Text
                };

                TareasController tareasController = new TareasController();
                if (string.IsNullOrEmpty(txtId.Text)) //adicionar
                    ClientScript.RegisterStartupScript(this.GetType(), "messaje", "<script> swal('Mensaje!', '" + tareasController.addTarea(tarea) + "!', 'success')</script>");
                else //modificar
                    ClientScript.RegisterStartupScript(this.GetType(), "messaje", "<script> swal('Mensaje!', '" + tareasController.updateTare(tarea) + "!', 'success')</script>");

                txtId.Text = txtTitulTarea.Text = txtAsunto.Text = txtContacto.Text = txtFechaDeVencimiento.Text = txtCuenta.Text = txtDescripcion.Text = string.Empty;
                chkEnviarMensaje.Checked = chkRepetir.Checked = false;
                GetTareas();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "menssaje", "<script> swal('Error!', '" + ex.Message + "!', 'error')</script>");
            }
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            txtId.Text = txtTitulTarea.Text = txtAsunto.Text = txtContacto.Text = txtFechaDeVencimiento.Text = txtCuenta.Text = txtDescripcion.Text = string.Empty;
            chkEnviarMensaje.Checked = chkRepetir.Checked = false; 
        }

        protected void GvDatos_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            try
            {
                int inIndice = Convert.ToInt32(e.CommandArgument);
                if ( e.CommandName.Equals("Editar"))
                {
                    txtId.Text = ((Label)gvDatos.Rows[inIndice].FindControl("lblId")).Text;
                    txtTitulTarea.Text = gvDatos.Rows[inIndice].Cells[1].Text;
                    txtAsunto.Text = gvDatos.Rows[inIndice].Cells[2].Text;
                    txtFechaDeVencimiento.Text = gvDatos.Rows[inIndice].Cells[3].Text;
                    txtContacto.Text = gvDatos.Rows[inIndice].Cells[4].Text;
                    txtCuenta.Text = gvDatos.Rows[inIndice].Cells[5].Text;
                    ddlEstado.SelectedValue = ((Label)gvDatos.Rows[inIndice].FindControl("lblEstado")).Text;
                    ddlPrioridad.SelectedValue = ((Label)gvDatos.Rows[inIndice].FindControl("lblPrioridad")).Text; 
                    chkEnviarMensaje.Checked = gvDatos.Rows[inIndice].Cells[8].Text.Equals("S") ? true : false;
                    chkRepetir.Checked =  gvDatos.Rows[inIndice].Cells[9].Text.Equals("S") ? true : false;
                    txtDescripcion.Text = gvDatos.Rows[inIndice].Cells[10].Text;
                } else if (e.CommandName.Equals("Eliminar"))
                {
                    Tarea tarea = new Tarea
                    {
                        id = Convert.ToInt32(((Label)gvDatos.Rows[inIndice].FindControl("lblId")).Text)
                    };
                    TareasController tareasController = new TareasController();
                    ClientScript.RegisterStartupScript(this.GetType(), "messaje", "<script> swal('Mensaje!', '" + tareasController.deleteTare(tarea) + "!', 'success')</script>");
                    GetTareas();
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "menssaje", "<script> swal('Error!', '" + ex.Message + "!', 'error')</script>");
            }
        }

        void GetTareas()
        {
            try
            {
                TareasController tareasController = new TareasController();
                List<Tarea> list = tareasController.getTare();
                if (list.Count > 0)
                    gvDatos.DataSource = list;
                else
                    gvDatos.DataSource = null;
                gvDatos.DataBind();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "menssaje", "<script> swal('Error!', '" + ex.Message + "!', 'error')</script>");
            }
        }
    }
}