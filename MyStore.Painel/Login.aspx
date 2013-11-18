<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MyStore.Painel.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MyStore - Acesso </title>
    <link rel="stylesheet" type="text/css" href="Content/css/bootstrap.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="Content/css/signin.css" media="screen" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="form-signin">
                <h2 class="form-signin-heading">MyStore - Log in</h2>

                <div class="alert-danger" id="blcMensagemErro" runat="server" visible="false" style="margin-top:5px;">
                   <asp:Literal ID="ltrMensagemErro" runat="server"></asp:Literal>
                </div>

                <asp:TextBox ID="txtLogin" runat="server" placeholder="Email" CssClass="form-control" AutoComplete="off"></asp:TextBox>
                <asp:TextBox ID="txtSenha" runat="server" TextMode="Password" placeholder="Senha" CssClass="form-control" AutoComplete="off"></asp:TextBox>
                <asp:LinkButton ID="lkbLogin" Text="Entrar" runat="server" OnClick="lkbLogin_Click" CssClass="btn btn-info btn-block" />

                
            </div>
        </div>
    </form>
    <!--Javascript here -->
    <script type="text/javascript" src="Content/js/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="Content/js/bootstrap.min.js"></script>
</body>
</html>
