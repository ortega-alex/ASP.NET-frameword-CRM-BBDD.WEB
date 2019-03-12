using Proyecto.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto.Web.Views.Evento
{
    public partial class Evento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                //GetEventos();
                GetEventosXml();
        }

        public void GetEventos()
        {
            try
            {
                EventoController eventoController = new EventoController();
                List<Logica.Models.Evento> eventos = eventoController.GetEventos();
                if (eventos.Count > 0)
                    gvwDatos.DataSource = eventos;
                else
                    gvwDatos.DataSource = null;
                gvwDatos.DataBind();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "menssaje", "<script> swal('Error!', '" + ex.Message + "!', 'error')</script>");
            }
        }

        public void GetEventosXml()
        {
            try
            {
                EventoControllerXml eventoController = new EventoControllerXml();
              var eventos = eventoController.GetEventos_xml();
                if (eventos != null)
                    gvwDatos.DataSource = eventos;
                else
                    gvwDatos.DataSource = null;
                gvwDatos.DataBind();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "menssaje", "<script> swal('Error!', '" + ex.Message + "!', 'error')</script>");
            }
        }
    }
}