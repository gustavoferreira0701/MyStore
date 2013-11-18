<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="DepartamentoGerenciar.aspx.cs" Inherits="MyStore.Painel.DepartamentoGerenciar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

    <div class="row margens" style="margin-top: 60px;">
        <div class="col-md-4">
            <h2>Departamentos </h2>
        </div>
    </div>

    <div class="row margens">
        <div class="col-md-12">
            <asp:Label ID="lblMensagemErro" runat="server" Visible="false"></asp:Label>
        </div>
    </div>

    <div class="row margens">
        <div class="col-md-8">
            <asp:TextBox ID="txtPesquisar" runat="server" Style="width: 250px; display: inline;" placeholder="Pesquisar Departamento" CssClass="form-control"></asp:TextBox>
            <asp:LinkButton Text="Pesquisar"
                ID="btnPesquisar"
                runat="server"
                OnClick="btnPesquisar_Click"
                CssClass="btn btn-info"
                Style="width: 110px;" />
        </div>
        <div class="col-md-4">
            <a href="DepartamentoCadastrar.aspx" class="btn btn-info pull-right">Cadastrar Departamento</a>
        </div>
    </div>


    <div class="row margens">
        <div class="col-md-12">

            <asp:Repeater runat="server" ID="repeaterDepartamento" OnItemCommand="repeaterDepartamento_ItemCommand">
                <HeaderTemplate>
                    <table class="table table-stripped table-hover">
                        <thead>
                            <tr>
                                <th>Nome</th>
                                <th>Ativo</th>
                                <th style="text-align:right;">Ações</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <literal><%# DataBinder.Eval(Container.DataItem,"Nome") %></literal>
                        </td>
                        <td>
                            <input type="checkbox" checked='<%# DataBinder.Eval(Container.DataItem,"Ativo")%>' />
                        </td>
                        <td style="text-align:right;">
                            <asp:LinkButton ID="lkbEditar" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"IdDepartamento")%>' CommandName="editar">Editar</asp:LinkButton>
                            <asp:LinkButton ID="lkbExcluir" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"IdDepartamento")%>' CommandName="excluir">Excluir</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
                </table>
                </FooterTemplate>
            </asp:Repeater>

        </div>

    </div>
</asp:Content>
