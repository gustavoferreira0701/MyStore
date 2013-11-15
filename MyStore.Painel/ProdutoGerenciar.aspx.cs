using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyStore.RegraNegocio;

namespace MyStore.Painel
{
    public partial class ProdutoGerenciar : System.Web.UI.Page
    {

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    Inicializar();
                    CarregarDados();
                }
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
                string termo = txtPesquisar.Text;

                Produto produto = new Produto();    
                List<Produto> lista = new List<Produto>();

                if (string.IsNullOrEmpty(termo))
                    lista = produto.Selecionar();
                else
                    lista = produto.SelecionarByTermo(termo);

                repeaterProduto.DataSource = lista;
                repeaterProduto.DataBind();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(ddlCategoria.SelectedValue);

                Produto produto = new Produto();

                List<Produto> lista = new List<Produto>();

                if (id != 0)
                    lista = produto.SelecionarByCategoria(id);
                else
                    lista = produto.Selecionar();

                repeaterProduto.DataSource = lista;
                repeaterProduto.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void repeaterProduto_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(e.CommandArgument);

                switch (e.CommandName)
                {
                    case "editar":
                        Response.Redirect("~/ProdutoEditar.aspx?id=" + id, false);
                        break;
                    case "excluir":
                        Produto produto = new Produto();
                        produto.IdProduto = id;
                        produto.Excluir();
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

        #region Metodos

        private void CarregarDados()
        {
            try
            {
                Produto produto = new Produto();

                repeaterProduto.DataSource = produto.Selecionar();
                repeaterProduto.DataBind();

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
                Categoria categoria = new Categoria();
                
                ddlCategoria.DataSource = categoria.Selecionar();
                ddlCategoria.DataBind();

                ddlCategoria.Items.Insert(0, new ListItem { Text = "Selecione", Value = "0" });
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        #endregion

      
    }
}