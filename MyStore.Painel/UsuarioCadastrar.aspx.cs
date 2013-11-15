using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyStore.RegraNegocio;
using System.Text;

namespace MyStore.Painel
{
    public partial class UsuarioCadastrar : System.Web.UI.Page
    {
        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void lkbSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCampos())
                {
                    Usuario usuario = new Usuario();

                    usuario.Nome = txtNome.Text;
                    usuario.Email = txtEmail.Text;
                    usuario.Senha = txtSenha.Text;

                    usuario.Cadastrar();

                    Response.Redirect("~/UsuarioGerenciar.aspx", false);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region Metodos

        private bool ValidarCampos()
        {
            try
            {
                bool retorno = true;

                StringBuilder strMensagemErro = new StringBuilder();

                strMensagemErro.Append("<ul>");

                if (string.IsNullOrEmpty(txtNome.Text))
                {
                    strMensagemErro.Append("<li> O campo nome é obrigatório </li>");
                    retorno = false;
                }
                else if (Usuario.VerificarExistenciaUsuario(txtNome.Text))
                {
                    strMensagemErro.Append("<li>Já existe um usuário cadastrado com este email </li>");
                    retorno = false;
                }

                if (string.IsNullOrEmpty(txtSenha.Text))
                {
                    strMensagemErro.Append("<li> O campo senha é obrigatório </li>");
                    retorno = false;
                }


                strMensagemErro.Append("</ul>");

                ltrMensagemErro.Text = strMensagemErro.ToString();

                ltrMensagemErro.Visible = !retorno;

                return retorno;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        #endregion

        
    }
}