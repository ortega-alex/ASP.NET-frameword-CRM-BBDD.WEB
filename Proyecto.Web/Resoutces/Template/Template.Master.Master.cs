using System;

namespace Proyecto.Web.Resoutces.Template
{
    public partial class Template_Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                String[] stEmail = null;
                if (Session["sessionEmail"] != null)
                {
                    stEmail = Session["sessionEmail"].ToString().Split('@');
                    lblUsuario.Text = stEmail[0];
                } else
                {
                    Response.Redirect("../../Views/Login/Login.aspx");
                }

            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            //Session.Remove("sessionEmail"); //elimina valiable de session en espesifico
            Session.RemoveAll(); //remueve todas las variables de session
            Response.Redirect("../../Views/Login/Login.aspx");
        }
    }
}