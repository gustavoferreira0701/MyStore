using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyStore.RegraNegocio;

namespace MyStore.Painel
{
    public partial class UsuarioEditar : System.Web.UI.Page
    {
        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack && ValidarAcesso())
                    CarregarDados();

            }
            catch (Exception)
            {

            }
        }



        #endregion


        #region Metodos

        private bool ValidarAcesso()
        {
            try
            {
                ///Validar existência de querystring
                if (Request.QueryString["id"] == null)
                {
                    Response.Redirect("~/UsuarioGerenciar.aspx", true);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void CarregarDados()
        {
            try
            {
                int id = int.Parse(Request.QueryString["id"]);

                Usuario usuario = new Usuario();

                usuario.IdUsuario = id;

                usuario = usuario.Selecionar().FirstOrDefault();

                if (usuario != null || usuario.IdUsuario != null)
                {
                    txtNome.Text = usuario.Nome;
                    txtEmail.Text = usuario.Email;
                    txtSenha.Text = usuario.Senha;
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