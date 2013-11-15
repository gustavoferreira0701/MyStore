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
    public partial class ProdutoEditar : System.Web.UI.Page
    {
        #region Eventos

        protected void lkbSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCampos())
                {
                    Produto produto = new Produto();
                    produto.Nome = txtNome.Text;
                    produto.IdCategoria = int.Parse(ddlCategoria.SelectedValue);
                    produto.Ativo = ckbAtivo.Checked;

                    produto.Editar();
                    Response.Redirect("ProdutoGerenciar.aspx", false);
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

                int idProduto = int.Parse(Request.QueryString["id"]);

                StringBuilder strMensagensErro = new StringBuilder();

                strMensagensErro.Append("<ul>");

                if (string.IsNullOrEmpty(txtNome.Text))
                {
                    strMensagensErro.Append("<li> O campo nome deve ser preenchido </li>");
                    retorno = false;
                }

                int id = int.Parse(ddlCategoria.SelectedValue);

                if (id != 0)
                {
                    Produto produto = new Produto();
                    produto = produto.SelecionarByCategoria(id).Where(item => (item.Nome.ToLower() == txtNome.Text.ToLower()) && item.IdProduto != idProduto).FirstOrDefault();

                    if (produto != null)
                    {
                        strMensagensErro.Append("<li> A categoria selecionada já possui um produto cadastrado com este nome </li>");
                        retorno = false;
                    }
                }
                else
                {
                    strMensagensErro.Append("<li> Selecione uma categoria para este produto  </li>");
                    retorno = false;
                }


                ltrMensagemErro.Text = strMensagensErro.ToString();
                ltrMensagemErro.Visible = !retorno;

                return retorno;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

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

        #endregion

        #region Metodos

        private void CarregarDados()
        {
            try
            {
                int id = int.Parse(Request.QueryString["id"]);

                Produto produto = new Produto();

                produto.IdProduto = id;

                produto = produto.Selecionar().FirstOrDefault();

                txtNome.Text = produto.Nome;
                ckbAtivo.Checked = produto.Ativo;
                ddlCategoria.SelectedValue = produto.IdCategoria.ToString();

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Inicializar()
        {
            try
            {
                if (Request.QueryString["id"] == null)
                    Response.Redirect("ProdutoGerenciar.aspx", true);
                else
                {
                    int id = int.Parse(Request.QueryString["id"]);
                    Categoria categoria = new Categoria();

                    ddlCategoria.DataSource = categoria.Selecionar();
                    ddlCategoria.DataBind();
                    ddlCategoria.Items.Insert(0, new ListItem { Text = "Selecionar", Value = "0" });

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