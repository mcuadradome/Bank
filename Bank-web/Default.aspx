<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Bank_web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">

        <input type="text" name="txtUser" placeholder="Usuario" id="txtUser" />
          <input type="password" name="txtPass" placeholder="Contraseña" id="txtPass" />
        <asp:Button Text="Ingresar" runat="server" OnClick="Unnamed1_Click" />
         </div>

   

</asp:Content>
