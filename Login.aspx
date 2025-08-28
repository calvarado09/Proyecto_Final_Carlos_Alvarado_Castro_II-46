<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Login.aspx.vb" Inherits="Proyecto_Final_Carlos_Alvarado_Castro_II_46.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-flex justify-content-center align-items-center" style="height: 80vh;">
        <div class="card p-4 shadow" style="width: 350px; border-radius: 15px;">
            <h2 class="text-center mb-4">Iniciar Sesión</h2>

            <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger text-center d-block mb-2"></asp:Label>

            <div class="mb-3">
                <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" placeholder="Usuario"></asp:TextBox>
            </div>

            <div class="mb-3">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Contraseña"></asp:TextBox>
            </div>

            <div class="d-grid">
                <asp:Button ID="btnLogin" runat="server" Text="Ingresar" CssClass="btn btn-primary" OnClick="btnLogin_Click" />
            </div>

            <div class="text-center mt-3">
                <a href="RegistrodePacientesPublico.aspx" class="text-decoration-none">Crear un usuario</a>
            </div>

            <p class="text-center mt-3 mb-0 text-muted" style="font-size: 0.9em;">Proyecto Final - Sistema de Citas Médicas</p>
        </div>
    </div>
</asp:Content>
