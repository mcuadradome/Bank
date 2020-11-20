<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Bank_web.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Cuenta 1"></asp:Label>
            <input id="txtCuenta1" type="text" />

             <asp:Label ID="Label2" runat="server" Text="Cuenta 1"></asp:Label>
            <input id="txtCuenta2" type="text" />

             <asp:Label ID="Label3" runat="server" Text="Cuenta 1"></asp:Label>
            <input id="Nuevo saldo" type="text" />
        </div>

        <div>
            <asp:Button Text="Tranferir" runat="server" />
             <asp:Button Text="Consultar" runat="server" />
            
        </div>
    </form>
</body>
</html>
