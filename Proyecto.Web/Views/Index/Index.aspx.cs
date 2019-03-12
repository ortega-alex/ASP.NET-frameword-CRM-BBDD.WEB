using System;

namespace Proyecto.Web.Views.Index
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strEmail = string.Empty;
            if (!IsPostBack)
            {
                if (Request.QueryString["strEmail"] != null) // verifica si esxiste
                {
                    strEmail = Request.QueryString["strEmail"].ToString(); //recupera el valor
                }
            }
        }
    }
}