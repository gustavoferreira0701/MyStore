<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="CategoriaGerenciar.aspx.cs" Inherits="MyStore.Painel.CategoriaGerenciar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

    <div class="row margens" style="margin-top: 60px;">
        <div class="col-md-4">
            <h2>Categorias </h2>
        </div>
    </div>

    <div class="row margens">
        <div class="col-md-12">
            <asp:Label ID="lblMensagemErro" runat="server" Visible="false"></asp:Label>
        </div>
    </div>

    <div class="row margens">
        <div class="col-md-8">
            <asp:TextBox ID="txtPesquisar"
                runat="server"
                CssClass="form-control"
                Style="width: 250px; display: inline;"
                placeholder="Pesquisar Categorias"></asp:TextBox>
            <asp:LinkButton Text="Pesquisar" 
                            runat="server" 
                            ID="lkbPesquisar" 
                            OnClick="lkbPesquisar_Click" 
                            Style="width: 110px;"
                            CssClass="btn btn-info" />

            <label>Departamentos: </label>
            <asp:DropDownList ID="ddlDepartamentos"
                runat="server"
                DataTextField="Nome"
                DataValueField="IdDepartamento"
                AutoPostBack="true"
                CssClass="form-control"
                style="width:150px;display:inline;"
                OnSelectedIndexChanged="ddlDepartamentos_SelectedIndexChanged">
            </asp:DropDownList>

        </div>
        <div class="col-md-4">
            <a href="CategoriaCadastrar.aspx" class="pull-right btn btn-info">Cadastrar Categoria </a>
        </div>

    </div>

    <div class="row margens">
        <div class="col-md-12">
            <asp:Repeater ID="repeaterCategoria" runat="server" OnItemCommand="repeaterCategoria_ItemCommand">

                <HeaderTemplate>
                    <table class="table table-stripped table-hover">
                        <thead>
                            <tr>
                                <th>Nome</th>
                                <th>Departamento</th>
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
                            <literal text='<%# DataBinder.Eval(Container.DataItem,"NomeDepartamento") %>'></literal>
                        </td>
                        <td>
                            <asp:CheckBox ID="ckbAtivo" runat="server" Checked='<%# DataBinder.Eval(Container.DataItem,"Ativo") %>' /></td>
                        <td style="text-align:right;">
                            <asp:LinkButton ID="lkbEditar" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"IdCategoria")%>' CommandName="editar">Editar</asp:LinkButton>
                            <asp:LinkButton ID="lkbExcluir" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"IdCategoria")%>' CommandName="excluir">Excluir</asp:LinkButton>
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
