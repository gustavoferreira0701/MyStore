using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyStore.RegraNegocio;

namespace MyStore.Painel
{
    public partial class UsuarioGerenciar : System.Web.UI.Page
    {

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                    CarregarDados();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void CarregarDados()
        {
            try
            {
                Usuario usuario = new Usuario();

                repeaterUsuario.DataSource = usuario.Selecionar();
                repeaterUsuario.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = new Usuario();

                repeaterUsuario.DataSource = string.IsNullOrEmpty(txtPesquisar.Text) ? usuario.Selecionar() : usuario.SelecionarByTermo(txtPesquisar.Text);
                repeaterUsuario.DataBind();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void repeaterUsuario_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(e.CommandArgument);

                switch (e.CommandName)
                {
                    case "editar":
                        Response.Redirect("UsuarioEditar.aspx?id=" + id, false);
                        break;
                    case "excluir":
                        Usuario usuario = new Usuario();
                        usuario.IdUsuario = id;
                        usuario.Excluir();
                        CarregarDados();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion
    }
}