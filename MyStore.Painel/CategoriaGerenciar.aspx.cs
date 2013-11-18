using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyStore.RegraNegocio;

namespace MyStore.Painel
{
    public partial class CategoriaGerenciar : System.Web.UI.Page
    {
        #region Metodos

        private void CarregarDados()
        {
            try
            {
                Categoria categoria = new Categoria();
                repeaterCategoria.DataSource = categoria.Selecionar();
                repeaterCategoria.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void Inicializar()
        {
            try
            {
                Departamento departamento = new Departamento();

                ddlDepartamentos.DataSource = departamento.Selecionar();
                ddlDepartamentos.DataBind();

                ddlDepartamentos.Items.Insert(0, new ListItem { Text = "Selecionar", Value = "0" });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void ValidarAcesso()
        {
            try
            {
                bool retorno = true;

                retorno = Session["usuario"] != null;

                if (!retorno)
                    Response.Redirect("~/Login.aspx", true);
            }
            catch (Exception)
            {

            }
        }

        #endregion

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ValidarAcesso();
                    Inicializar();
                    CarregarDados();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void lkbPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                string termo = txtPesquisar.Text;

                Categoria categoria = new Categoria();

                repeaterCategoria.DataSource = string.IsNullOrEmpty(termo) ? categoria.Selecionar() : categoria.SelecionarByTermo(termo);
                repeaterCategoria.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void ddlDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(ddlDepartamentos.SelectedValue);

                Categoria categoria = new Categoria();

                repeaterCategoria.DataSource = id != 0 ? categoria.SelecionarByDepartamento(id) : categoria.Selecionar();
                repeaterCategoria.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void repeaterCategoria_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(e.CommandArgument);

                switch (e.CommandName)
                {
                    case "editar":
                        Response.Redirect(string.Format("CategoriaEditar.aspx?id={0}", id), false);
                        break;
                    case "excluir":
                        Categoria categoria = new Categoria();
                        categoria.IdCategoria = id;
                        categoria.Excluir();
                        CarregarDados();
                        break;
                    default:
                        break;
                }
            }
            catch (EntityCommandExecutionException)
            {
                lblMensagemErro.Visible = true;
                lblMensagemErro.Text = "Houve um erro ao remover a categoria selecionada, verifique se ela está relacionada a algum produto específico";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion
    }
}