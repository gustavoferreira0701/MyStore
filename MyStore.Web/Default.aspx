<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MyStore.Web.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Repeater ID="repeaterDepartamentos"
                runat="server"
                OnItemCommand="repeaterDepartamentos_ItemCommand">
                <HeaderTemplate>
                    <ul>
                </HeaderTemplate>
                <ItemTemplate>

                    <li>
                        <asp:LinkButton ID="lkbDepartamento"
                            runat="server"
                            Text='<%# DataBinder.Eval(Container.DataItem,"Nome") %>'
                            CommandArgument='<%# DataBinder.Eval(Container.DataItem,"IdDepartamento") %>'
                            CommandName="categoria"></asp:LinkButton></li>

                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                </FooterTemplate>

            </asp:Repeater>

        </div>
        <div>
            <asp:Repeater ID="repeaterCategorias"
                runat="server"
                OnItemCommand="repeaterCategorias_ItemCommand">
                <HeaderTemplate>
                    <ul>
                </HeaderTemplate>
                <ItemTemplate>
                    <li>
                        <asp:LinkButton ID="lkbCategoria"
                            runat="server"
                            Text='<%# DataBinder.Eval(Container.DataItem,"Nome") %>'
                            CommandArgument='<%# DataBinder.Eval(Container.DataItem,"IdCategoria") %>'
                            CommandName="produto"></asp:LinkButton>
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                </FooterTemplate>
            </asp:Repeater>

        </div>

        <div>
            <asp:Repeater ID="repeaterProdutos"
                runat="server">
                <HeaderTemplate>
                   <ul>
                </HeaderTemplate>
                <ItemTemplate>
                    <li>
                        <literal><%# DataBinder.Eval(Container.DataItem,"Nome") %></literal>
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                  </ul>
                </FooterTemplate>

            </asp:Repeater>

        </div>
    </form>
</body>
</html>
