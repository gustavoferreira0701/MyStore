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
    public partial class CategoriaCadastrar : System.Web.UI.Page
    {
        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                    if (ValidarAcesso())
                        Response.Redirect("~/Login.aspx", true);
                    else
                        Inicializar();

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        protected void lkbCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCampos())
                {
                    Categoria categoria = new Categoria();

                    categoria.Nome = txtNome.Text;
                    categoria.IdDepartamento = int.Parse(ddlDepartamento.SelectedValue);

                    categoria.Cadastrar();

                    Response.Redirect("CategoriaGerenciar.aspx", false);
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

                int id = int.Parse(ddlDepartamento.SelectedValue);

                if (id != 0)
                {
                    Categoria categoria = new Categoria();
                    categoria = categoria.SelecionarByDepartamento(id).Where(item => item.Nome.ToLower() == txtNome.Text.ToLower()).FirstOrDefault();

                    if (categoria != null)
                    {
                        strMensagemErro.Append("<li> O departamento selecionado já possui uma categoria cadastrada </li>");
                        retorno = false;
                    }
                }
                else
                {
                    strMensagemErro.Append("<li> Selecione um departamento para esta categoria </li>");
                    retorno = false;
                }

                strMensagemErro.Append("</ul>");


                ltrMensagemErro.Visible = !retorno;
                ltrMensagemErro.Text = strMensagemErro.ToString();


                return retorno;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private bool ValidarAcesso()
        {
            try
            {
                bool retorno = true;

                retorno = (Session["usuario"] != null);

                return retorno;

            }
            catch (Exception)
            {
                return false;
            }
        }

        private void Inicializar()
        {
            try
            {
                Departamento departamento = new Departamento();

                ddlDepartamento.DataSource = departamento.Selecionar();
                ddlDepartamento.DataBind();
                ddlDepartamento.Items.Insert(0, new ListItem { Text = "Selecione", Value = "0" });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion
    }
}