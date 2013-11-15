<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="ProdutoEditar.aspx.cs" Inherits="MyStore.Painel.ProdutoEditar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

    <div>
        <asp:Literal ID="ltrMensagemErro" runat="server" Visible="false"></asp:Literal>

        <ul>

            <li>
                <label>Nome: </label>
                <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
            </li>
            <li>
                <label>Categoria: </label>
                <asp:DropDownList ID="ddlCategoria"
                    runat="server"
                    DataValueField="IdCategoria"
                    DataTextField="Nome"
                    AutoPostBack="false">
                </asp:DropDownList>
            </li>
            <li>
                <label>Ativo: </label><asp:CheckBox ID="ckbAtivo" runat="server" />
            </li>
            <li>
                <asp:LinkButton ID="lkbSalvar" runat="server" OnClick="lkbSalvar_Click">Salvar</asp:LinkButton>
                <a href="ProdutoGerenciar.aspx">Voltar</a>
            </li>


        </ul>

    </div>
</asp:Content>
