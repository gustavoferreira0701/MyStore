<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="CategoriaGerenciar.aspx.cs" Inherits="MyStore.Painel.CategoriaGerenciar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

    <div>
        <asp:Label id="lblMensagemErro" Visible="false" runat="server"></asp:Label>
    </div>
    <div>

        <label>Pesquisar Categorias: </label>
        <asp:TextBox ID="txtPesquisar" runat="server"></asp:TextBox><asp:LinkButton Text="Pesquisar" runat="server" ID="lkbPesquisar" OnClick="lkbPesquisar_Click" />

        <br />

        <label>Departamentos: </label>
        <asp:DropDownList ID="ddlDepartamentos"
            runat="server"
            DataTextField="Nome"
            DataValueField="IdDepartamento"
            AutoPostBack="true"
            OnSelectedIndexChanged="ddlDepartamentos_SelectedIndexChanged">
        </asp:DropDownList>

        <a href="CategoriaCadastrar.aspx"> Cadastrar Categoria </a>

    </div>

    <div>

        <asp:Repeater ID="repeaterCategoria" runat="server" OnItemCommand="repeaterCategoria_ItemCommand">

            <HeaderTemplate>
                <table>
                    <thead>
                        <tr>
                            <th>Nome</th>
                            <th>Departamento</th>
                            <th>Ativo</th>
                            <th>Ações</th>
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
                        <literal Text='<%# DataBinder.Eval(Container.DataItem,"NomeDepartamento") %>'></literal>
                    </td>
                    <td>
                        <asp:CheckBox ID="ckbAtivo" runat="server" Checked='<%# DataBinder.Eval(Container.DataItem,"Ativo") %>' /></td>
                    <td>
                        <asp:LinkButton ID="lkbEditar" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"IdCategoria")%>' CommandName="editar"></asp:LinkButton>
                        <asp:LinkButton ID="lkbExcluir" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"IdCategoria")%>' CommandName="excluir"></asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
                </table>
            </FooterTemplate>

        </asp:Repeater>

    </div>
</asp:Content>
