<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Login.aspx.vb" Inherits="Proyecto_Final_Carlos_Alvarado_Castro_II_46.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width: 400px; margin: 100px auto; text-align:center;">
        <h2>Login</h2>
        <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" placeholder="Usuario"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Contraseña"></asp:TextBox>
        <br />
        <asp:Button ID="btnLogin" runat="server" Text="Ingresar" CssClass="btn btn-primary" OnClick="btnLogin_Click" />
        <br /><br />
        <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger"></asp:Label>
    </div>
</asp:Content>
