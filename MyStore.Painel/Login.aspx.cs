using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyStore.RegraNegocio;
using System.Text;

namespace MyStore.Painel
{
    public partial class Login : System.Web.UI.Page
    {
        public Usuario usuario { get; set; }

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                    usuario = new Usuario();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void lkbLogin_Click(object sender, EventArgs e)
        {
            try
            {

                usuario = new Usuario { Email = txtLogin.Text, Senha = txtSenha.Text };

                if (ValidarCampos())
                {
                    AutenticarSessao(usuario);
                    Response.Redirect("~/DepartamentoGerenciar.aspx", false);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region Metodos

        private void AutenticarSessao(Usuario usuario)
        {
            try
            {
                Session["usuario"] = usuario;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool ValidarCampos()
        {
            try
            {
                LimparCampos();

                Regex regex = new Regex(@"\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b");

                bool retorno = true;

                StringBuilder strMensagem = new StringBuilder();

                strMensagem.Append("<ul>");

                if (string.IsNullOrEmpty(txtLogin.Text) && string.IsNullOrEmpty(txtSenha.Text))
                {
                    strMensagem.Append("<li> Os campos e-mail e senha são obrigatórios </li>");
                    retorno = false;
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtLogin.Text))
                    {
                        usuario = usuario.ValidarUsuario(usuario.Email, usuario.Senha);

                        if (usuario == null)
                        {
                            strMensagem.Append("<li> Usuário/Senha inválidos </li>");
                            retorno = false;
                        }
                    }
                    else
                    {
                        strMensagem.Append("<li> O campo e-mail deve ser preenchido </li>");
                        retorno = false;
                    }

                    if (string.IsNullOrEmpty(txtSenha.Text))
                    {
                        strMensagem.Append("<li> O campo senha deve ser preenchido </li>");
                        retorno = false;
                    }

                }

                strMensagem.Append("</ul>");

                ltrMensagemErro.Text = strMensagem.ToString();

                blcMensagemErro.Visible = !retorno;

                return retorno;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void LimparCampos()
        {
            try
            {
                ltrMensagemErro.Text = string.Empty;
                blcMensagemErro.Visible = false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion
    }
}