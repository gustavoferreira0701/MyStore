<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="DepartamentoEditar.aspx.cs" Inherits="MyStore.Painel.DepartamentoEditar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .mensagemErro {
            color:red;
            font-family:'Trebuchet MS', Arial, sans-serif;
            font-size: 14px;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

    <div>
        <asp:Literal ID="ltrMensagemErro" runat="server"></asp:Literal>

        <ul>
            <li>
                <label> Nome : </label><asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
                
            </li>
            <li>
                <label> Ativo: </label><asp:CheckBox ID="ckbAtivo" runat="server" />
            </li>
            <li>
                <asp:LinkButton ID="lkbSalvar" runat="server" Text="Salvar" OnClick="lkbSalvar_Click"></asp:LinkButton>
                <a href="DepartamentoGerenciar.aspx">Voltar</a>
            </li>
        </ul>
    </div>
</asp:Content>
