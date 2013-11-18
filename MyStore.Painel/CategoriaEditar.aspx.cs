using MyStore.RegraNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyStore.Painel
{
    public partial class CategoriaEditar : System.Web.UI.Page
    {
        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (ValidarAcesso())
                    {
                        Inicializar();
                        CarregarDados();
                    }
                    else
                        Response.Redirect("Login.aspx", true);

                }
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

                    categoria.IdCategoria = int.Parse(Request.QueryString["id"]);
                    categoria.Nome = txtNome.Text;
                    categoria.Ativo = ckbAtivo.Checked;
                    categoria.IdDepartamento = int.Parse(ddlDepartamento.SelectedValue);

                    categoria.Editar();

                    Response.Redirect("CategoriaEditar.aspx", false);
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
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region Metodos

        private void CarregarDados()
        {
            try
            {
                int id = int.Parse(Request.QueryString["id"]);

                Categoria categoria = new Categoria();

                categoria.IdCategoria = id;
                categoria = categoria.Selecionar().FirstOrDefault();

                txtNome.Text = categoria.Nome;
                ckbAtivo.Checked = categoria.Ativo;
                ddlDepartamento.SelectedValue = categoria.IdDepartamento.ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void Inicializar()
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

        private bool ValidarAcesso()
        {
            try
            {
                bool retorno = true;

                if (Request.QueryString["id"] == null)
                {
                    Response.Redirect("~/CategoriaGerenciar.aspx", true);
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

        #endregion
    }
}