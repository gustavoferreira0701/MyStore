using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyStore.RegraNegocio;
using System.Data;

namespace MyStore.Painel
{
    public partial class DepartamentoGerenciar : System.Web.UI.Page
    {

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ValidarAcesso();
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

                Departamento departamento = new Departamento();

                List<Departamento> lista = new List<Departamento>();

                if (string.IsNullOrEmpty(termo))
                    lista = departamento.Selecionar();
                else
                    lista = departamento.SelecionarByTermo(termo);

                repeaterDepartamento.DataSource = lista;
                repeaterDepartamento.DataBind();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void repeaterDepartamento_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(e.CommandArgument);

                switch (e.CommandName)
                {
                    case "editar":
                        Response.Redirect(string.Format("~/DepartamentoEditar.aspx?id={0}", id), false);
                        break;
                    case "excluir":
                        Departamento departamento = new Departamento();
                        departamento.IdDepartamento = id;
                        departamento.Excluir();
                        CarregarDados();
                        break;

                    default:
                        break;
                }
            }
            catch (EntityCommandExecutionException)
            {
                lblMensagemErro.Visible = true;
                lblMensagemErro.Text = "Houve um erro ao remover o departamento selecionado, verifique se ele está relacionado a alguma categoria específica";
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
                Departamento departamento = new Departamento();
                repeaterDepartamento.DataSource = departamento.Selecionar();
                repeaterDepartamento.DataBind();
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

    }
}