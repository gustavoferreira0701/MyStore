<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="CategoriaCadastrar.aspx.cs" Inherits="MyStore.Painel.CategoriaCadastrar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div>
        <asp:Literal ID="ltrMensagemErro" runat="server"></asp:Literal>
        <ul>
            <li> <label> Nome: </label><asp:TextBox ID="txtNome" runat="server"></asp:TextBox> </li>
            <li> <label> Departamento: </label><asp:DropDownList ID="ddlDepartamento"
                                                         runat="server"
                                                         DataValueField="IdDepartamento"
                                                         DataTextField="Nome"
                                                         AutoPostBack="true"></asp:DropDownList>
            </li>
            <li>
                <asp:LinkButton ID="lkbCadastrar" runat="server" Text="Salvar" OnClick="lkbCadastrar_Click"></asp:LinkButton>
                <a href="CategoriaGerenciar.aspx">Voltar</a>
            </li>
        </ul>

    </div>
</asp:Content>
