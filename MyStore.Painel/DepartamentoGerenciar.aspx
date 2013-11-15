<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="DepartamentoGerenciar.aspx.cs" Inherits="MyStore.Painel.DepartamentoGerenciar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <h1>Departamentos </h1>

    <div>
        <label>Pesquisar Departamento: </label>
        <asp:TextBox ID="txtPesquisar" runat="server"></asp:TextBox><asp:LinkButton Text="Pesquisar" ID="btnPesquisar" runat="server" OnClick="btnPesquisar_Click" />
        
        <a href="DepartamentoCadastrar.aspx">Cadastrar Departamento</a>

    </div>

    <div>
        <asp:Repeater runat="server" ID="repeaterDepartamento" OnItemCommand="repeaterDepartamento_ItemCommand" >
            <HeaderTemplate>
                <table>
                    <thead>
                        <tr>
                            <th>Nome</th>
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
                        <input type="checkbox" checked='<%# DataBinder.Eval(Container.DataItem,"Ativo")%>' />
                    </td>
                    <td>
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
</asp:Content>
