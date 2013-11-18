using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyStore.RegraNegocio;

namespace MyStore.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                    CarregarDados();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        private void CarregarDados()
        {
            try
            {
                Departamento departamento = new Departamento();

                repeaterDepartamentos.DataSource = departamento.Selecionar();
                repeaterDepartamentos.DataBind();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        protected void repeaterDepartamentos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                switch (e.CommandName)
                {
                    case "categoria":
                        int id = Convert.ToInt32(e.CommandArgument);

                        Categoria categoria = new Categoria();
                        List<Categoria> listaCategorias = categoria.SelecionarByDepartamento(id);

                        repeaterCategorias.DataSource = listaCategorias;
                        repeaterCategorias.DataBind();

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

        protected void repeaterCategorias_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                switch (e.CommandName)
                {
                    case "produto":
                        int id = Convert.ToInt32(e.CommandArgument);

                        Produto produto = new Produto();
                        List<Produto> produtos = produto.SelecionarByCategoria(id);

                        repeaterProdutos.DataSource = produtos;
                        repeaterProdutos.DataBind();

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
    }
}