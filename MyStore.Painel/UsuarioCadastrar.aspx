<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="UsuarioCadastrar.aspx.cs" Inherits="MyStore.Painel.UsuarioCadastrar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

    <asp:Literal ID="ltrMensagemErro" runat="server" Visible="false"></asp:Literal>

    <div>

        <ul>
            <li>
                <label> Nome: </label><asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
            </li>
            <li>
                <label> Email: </label><asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>
            </li
            <li>
                <label> Confirmar senha: </label><asp:TextBox ID="txtConfirmaSenha" runat="server" TextMode="Password"></asp:TextBox>
            </li>
            <li>
                <label> Senha: </label><asp:TextBox ID="txtSenha" runat="server" TextMode="Password"></asp:TextBox>
            </li>
            <li>
                <label> Confirmar senha: </label><asp:TextBox ID="TextBox1" runat="server" TextMode="Password"></asp:TextBox>
            </li>
            <li>
                <asp:LinkButton ID="lkbSalvar" runat="server" Text="Salvar" OnClick="lkbSalvar_Click"></asp:LinkButton>
                <a href="UsuarioGerenciar.aspx">Voltar</a>
            </li>
        </ul>

    </div>

</asp:Content>
