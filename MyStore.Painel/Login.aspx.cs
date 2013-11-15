using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyStore.RegraNegocio;

namespace MyStore.Painel
{
    public partial class Login : System.Web.UI.Page
    {

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lkbLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if(ValidarCampos())
                {
                    Usuario usuario = new Usuario { Nome = txtLogin.Text, Senha = txtSenha.Text };
                    AutenticarSessao(usuario);
                    Response.Redirect("~/DepartamentoGerenciar.aspx",false);
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

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



        #endregion

        #region Metodos

        public bool ValidarCampos()
        {
            try
            {
                LimparCampos();

                Regex regex = new Regex(@"\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b");

                bool retorno = true;

                if (string.IsNullOrEmpty(txtLogin.Text) && string.IsNullOrEmpty(txtSenha.Text))
                {
                    lblMensagemErro.Text = "Os campos e-mail e senha devem ser obrigatórios";
                    lblMensagemErro.Visible = true;
                    retorno = false;
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtLogin.Text))
                    {
                        Usuario usuario = new Usuario();

                        if (!usuario.ValidarUsuario(txtLogin.Text, txtSenha.Text))
                        {
                            lblMensagemErro.Text = "Usuário/Senha inválidos";
                            lblMensagemErro.Visible = true;
                            retorno = false;
                        }
                    }
                    else
                    {
                        lblLogin_Erro.Text = "O campo e-mail deve ser preenchido";
                        lblLogin_Erro.Visible = true;
                        retorno = false;
                    }

                    if (string.IsNullOrEmpty(txtSenha.Text))
                    {
                        lblSenha_Erro.Text = "O campo senha deve ser preenchido";
                        lblSenha_Erro.Visible = true;
                        retorno = false;
                    }

                }
                
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
                lblLogin_Erro.Text = string.Empty;
                lblMensagemErro.Text = string.Empty;
                lblSenha_Erro.Text = string.Empty;

                lblSenha_Erro.Visible = false;
                lblMensagemErro.Visible = false;
                lblLogin_Erro.Visible = false;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        #endregion
    }
}