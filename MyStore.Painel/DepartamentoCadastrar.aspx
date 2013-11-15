<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="DepartamentoCadastrar.aspx.cs" Inherits="MyStore.Painel.DepartamentoCadastrar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

    <div>

        <ul>
            <li>
                <label> Nome : </label><asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
            </li>
            <li>
                <asp:LinkButton ID="lkbCadastrar" runat="server" Text="Salvar" OnClick="lkbCadastrar_Click"></asp:LinkButton>
                <a href="DepartamentoGerenciar.aspx">Voltar</a>
            </li>
        </ul>

    </div>
</asp:Content>
