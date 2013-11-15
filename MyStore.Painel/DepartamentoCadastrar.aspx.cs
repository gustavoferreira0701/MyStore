using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyStore.RegraNegocio;

namespace MyStore.Painel
{
    public partial class DepartamentoCadastrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lkbCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCampos())
                {
                    Departamento departamento = new Departamento();

                    departamento.Nome = txtNome.Text;

                    departamento.Cadastrar();

                    Response.Redirect("~/DepartamentoGerenciar.aspx");
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

                if (string.IsNullOrEmpty(txtNome.Text))
                    retorno = false;

                return retorno;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}