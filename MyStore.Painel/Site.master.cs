using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyStore.RegraNegocio;

namespace MyStore.Painel
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["usuario"] != null)
                    {
                        var usuario = (Usuario)Session["usuario"];
                        ltlNomeUsuario.Text = usuario.Nome;
                    }
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        protected void btnSair_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Login.aspx", true);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}