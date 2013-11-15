<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MyStore.Painel.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ul>
                <li>
                    <label>Login:  </label>
                    <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox></li>
                    <asp:Label ID="lblLogin_Erro" runat="server" Visible="false"></asp:Label>
                <li>
                    <label>Senha: </label>
                    <asp:TextBox ID="txtSenha" runat="server" TextMode="Password"></asp:TextBox></li>
                    <asp:Label ID="lblSenha_Erro" runat="server" Visible="false"></asp:Label>
                <li>
                    <asp:LinkButton ID="lkbLogin" Text="Entrar" runat="server" OnClick="lkbLogin_Click" />
                </li>

            </ul>
            <asp:Label ID="lblMensagemErro" runat="server" Visible="false"></asp:Label>
        </div>
    </form>
</body>
</html>
