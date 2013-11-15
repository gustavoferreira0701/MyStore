<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="ProdutoGerenciar.aspx.cs" Inherits="MyStore.Painel.ProdutoGerenciar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

     <h1>Produtos </h1>

    <div>
        <label>Pesquisar Produto: </label>
        <asp:TextBox ID="txtPesquisar" runat="server"></asp:TextBox><asp:LinkButton Text="Pesquisar" ID="btnPesquisar" runat="server" OnClick="btnPesquisar_Click" />
        
        <label> Categorias: </label><asp:DropDownList ID="ddlCategoria" 
                                                      runat="server" 
                                                      DataValueField="IdCategoria" 
                                                      DataTextField="Nome" 
                                                      AutoPostBack="true"
                                                      OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged"></asp:DropDownList>

        <a href="ProdutoCadastrar.aspx">Cadastrar Produto</a>

    </div>

    <div>
        <asp:Repeater runat="server" ID="repeaterProduto" OnItemCommand="repeaterProduto_ItemCommand" >
            <HeaderTemplate>
                <table>
                    <thead>
                        <tr>
                            <th>Nome</th>
                            <th>Categoria</th>
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
                        <literal><%# DataBinder.Eval(Container.DataItem,"NomeCategoria") %></literal>
                    </td>
                    <td>
                        <input type="checkbox" checked='<%# DataBinder.Eval(Container.DataItem,"Ativo")%>' />
                    </td>
                    <td>
                        <asp:LinkButton ID="lkbEditar" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"IdProduto")%>' CommandName="editar">Editar</asp:LinkButton>
                        <asp:LinkButton ID="lkbExcluir" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"IdProduto")%>' CommandName="excluir">Excluir</asp:LinkButton>
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
