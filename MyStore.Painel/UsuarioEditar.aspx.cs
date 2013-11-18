using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyStore.RegraNegocio;
using System.Text;
using System.Text.RegularExpressions;

namespace MyStore.Painel
{
    public partial class UsuarioEditar : System.Web.UI.Page
    {
        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                    if (ValidarAcesso())
                        CarregarDados();
                    else
                        Response.Redirect("~/Login.aspx", true);

            }
            catch (Exception)
            {

            }
        }

        protected void lkbSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCampos())
                {
                    int id = int.Parse(Request.QueryString["id"]);

                    Usuario usuario = new Usuario();

                    usuario.IdUsuario = id;
                    usuario.Nome = txtNome.Text;
                    usuario.Email = txtEmail.Text;
                    usuario.Senha = txtSenha.Text;

                    usuario.Editar();

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

        private bool ValidarAcesso()
        {
            try
            {
                bool retorno = true;

                if (Request.QueryString["id"] == null)
                {
                    Response.Redirect("~/UsuarioGerenciar.aspx", true);
                    retorno = false;
                }

                if (Session["usuario"] == null)
                    retorno = false;


                return retorno;

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

        private bool ValidarCampos()
        {
            try
            {
                bool retorno = true;

                StringBuilder strMensagemErro = new StringBuilder();

                Regex regexEmail = new Regex(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$");

                strMensagemErro.Append("<ul>");

                if (string.IsNullOrEmpty(txtNome.Text))
                {
                    strMensagemErro.Append("<li> O campo nome é obrigatório </li>");
                    retorno = false;
                }

                if (string.IsNullOrEmpty(txtEmail.Text))
                {
                    strMensagemErro.Append("<li> O campo e-mail é obrigatório </li>");
                    retorno = false;
                }
                else if (!regexEmail.IsMatch(txtEmail.Text))
                {
                    strMensagemErro.Append("<li> Formato de e-mail inválido </li>");
                    retorno = false;
                }
                else if (Usuario.VerificarExistenciaUsuario(txtEmail.Text, int.Parse(Request.QueryString["id"])))
                {
                    strMensagemErro.Append("<li>Já existe um usuário cadastrado com este email </li>");
                    retorno = false;
                }
                if (string.IsNullOrEmpty(txtSenha.Text))
                {
                    strMensagemErro.Append("<li> O campo senha é obrigatório </li>");
                    retorno = false;
                }
                else if (txtSenha.Text.Count() < 6)
                {
                    strMensagemErro.Append("<li> O campo senha deve conter no mínimo 6 caracteres </li>");
                    retorno = false;
                }
                else if (txtSenha.Text != txtConfirmaSenha.Text)
                {
                    strMensagemErro.Append("<li> As senhas informadas não conferem </li>");
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