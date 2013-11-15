<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="UsuarioGerenciar.aspx.cs" Inherits="MyStore.Painel.UsuarioGerenciar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

    <h1> Usuários </h1>

    <div>
        <label>Pesquisar Usuário: </label>
        <asp:TextBox ID="txtPesquisar" runat="server"></asp:TextBox><asp:LinkButton Text="Pesquisar" ID="btnPesquisar" runat="server" OnClick="btnPesquisar_Click" />
        
        <a href="UsuarioCadastrar.aspx">Cadastrar Usuário</a>

    </div>

    <div>
        <asp:Repeater runat="server" ID="repeaterUsuario" OnItemCommand="repeaterUsuario_ItemCommand" >
            <HeaderTemplate>
                <table>
                    <thead>
                        <tr>
                            <th>Nome</th>
                            <th>e-mail</th>
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
                        <literal><%# DataBinder.Eval(Container.DataItem,"Email") %></literal>
                    </td>
                    <td>
                        <input type="checkbox" checked='<%# DataBinder.Eval(Container.DataItem,"Ativo")%>' />
                    </td>
                    <td>
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

</asp:Content>
