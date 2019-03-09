using Proyecto.Web.Controllers;
using System;
using System.Data;

namespace Proyecto.Web.Views.Tareas
{
    public partial class Tareas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
            }

        }
    }
}