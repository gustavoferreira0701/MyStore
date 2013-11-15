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
    public partial class DepartamentoEditar : System.Web.UI.Page
    {
        #region Eventos

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

        protected void lkbSalvar_Click(object sender, EventArgs e)
        {
            try
            {

                if (ValidarCampos())
                {
                    Departamento departamento = new Departamento();

                    departamento.IdDepartamento = int.Parse(Request.QueryString["id"]);

                    departamento = departamento.Selecionar().FirstOrDefault();

                    departamento.Nome = txtNome.Text;
                    departamento.Ativo = ckbAtivo.Checked;

                    departamento.Editar();

                    Response.Redirect("~/DepartamentoGerenciar.aspx", false);
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
                if (Request.QueryString["id"] == null)
                    Response.Redirect("~/DepartamentoGerenciar.aspx", true);

                int id = int.Parse(Request.QueryString["id"]);

                Departamento departamento = new Departamento();

                departamento.IdDepartamento = id;
                departamento = departamento.Selecionar().FirstOrDefault();

                txtNome.Text = departamento.Nome;
                ckbAtivo.Checked = departamento.Ativo;
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

                LimparCampos();

                StringBuilder strErros = new StringBuilder();

                strErros.Append("<ul>");

                if (string.IsNullOrEmpty(txtNome.Text))
                {
                    strErros.Append("<li> O campo nome deve ser preenchido </li>");
                    retorno = false;
                }
                else
                {
                    Departamento departamento = new Departamento();
                    List<Departamento> lista = new List<Departamento>();

                    lista = departamento.Selecionar();
                    lista = lista.Where(item => item.Nome.ToLower() == txtNome.Text.ToLower()).ToList();

                    if (lista.Count > 0)
                    {
                        strErros.Append("<li> já existe um departamento cadastrado com este nome </li>");
                        retorno = false;
                    }
                }

                strErros.Append("</ul>");

                ltrMensagemErro.Text = strErros.ToString();
                ltrMensagemErro.Visible = !retorno;

                return retorno;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void LimparCampos()
        {
            ltrMensagemErro.Visible = false;
            ltrMensagemErro.Text = string.Empty;
        }

        #endregion
       
    }
}