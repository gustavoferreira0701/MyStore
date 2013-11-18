<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="UsuarioGerenciar.aspx.cs" Inherits="MyStore.Painel.UsuarioGerenciar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

    <div class="row margens" style="margin-top: 60px;">
        <div class="col-md-4">
            <h2>Usuários </h2>
        </div>
    </div>


    <div class="row margens">
        <div class="col-md-8">

            <asp:TextBox ID="txtPesquisar"
                runat="server"
                CssClass="form-control"
                placeholder="Pesquisar Usuário"
                Style="width: 250px; display: inline;"></asp:TextBox>
            <asp:LinkButton Text="Pesquisar"
                ID="btnPesquisar"
                runat="server"
                OnClick="btnPesquisar_Click"
                CssClass="btn btn-info" Style="width: 110px;" />
        </div>
        <div class="col-md-4">
            <a href="UsuarioCadastrar.aspx" class="btn btn-info  pull-right" style="width: 150px;">Cadastrar Usuário</a>
        </div>

    </div>

    <div class="row margens">
        <div class="col-md-12">
            <asp:Repeater runat="server" ID="repeaterUsuario" OnItemCommand="repeaterUsuario_ItemCommand">
                <HeaderTemplate>
                    <table class="table table-striped">
                        <thead>
                            <tr>
                                <th>Nome</th>
                                <th>e-mail</th>
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
                            <literal><%# DataBinder.Eval(Container.DataItem,"Email") %></literal>
                        </td>
                        <td>
                            <input type="checkbox" checked='<%# DataBinder.Eval(Container.DataItem,"Ativo")%>' />
                        </td>
                        <td style="text-align:right;">
                            <asp:LinkButton ID="lkbEditar" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"IdUsuario")%>' CommandName="editar">Editar</asp:LinkButton>
                            <asp:LinkButton ID="lkbExcluir" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"IdUsuario")%>' CommandName="excluir">Excluir</asp:LinkButton>
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
