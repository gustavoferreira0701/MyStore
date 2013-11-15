using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyStore.RegraNegocio;

namespace MyStore.Painel
{
    public partial class ProdutoCadastrar : System.Web.UI.Page
    {

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
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
                    Produto produto = new Produto();
                    produto.Nome = txtNome.Text;
                    produto.IdCategoria = int.Parse(ddlCategoria.SelectedValue);
                    produto.Cadastrar();

                    Response.Redirect("~/ProdutoGerenciar.aspx", false);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        #endregion

        #region Metodos

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

        private bool ValidarCampos()
        {
            try
            {
                bool retorno = true;

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
                    produto = produto.SelecionarByCategoria(id).Where(item => item.Nome.ToLower() == txtNome.Text.ToLower()).FirstOrDefault();

                    if (produto != null)
                    {
                        strMensagensErro.Append("<li> A categoria selecionada já possui um  </li>");
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


        #endregion

    }
}