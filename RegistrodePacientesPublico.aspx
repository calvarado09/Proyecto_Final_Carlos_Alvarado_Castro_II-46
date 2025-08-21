<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="RegistrodePacientesPublico.aspx.vb" Inherits="Proyecto_Final_Carlos_Alvarado_Castro_II_46.RegistrodePacientesPublico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>

    body {
        background-color: #f2f6fc;
        min-height: 100vh;
    }

   
    .card-custom {
        width: 700px;
        padding: 40px;
        margin: 50px auto;
        box-shadow: 0 4px 8px rgba(0,0,0,0.2);
        border-radius: 15px;
        background-color: #ffffff;
    }


    .form-group {
        width: 90%; 
        margin: 10px auto; 
        display: flex;
        flex-direction: column;
        align-items: center; 
    }


        .form-group .form-control {
            width: 100%; 
        }

    
    .btn-group-custom {
        width: 90%;
        margin: 20px auto 0 auto;
        display: flex;
        gap: 15px;
    }

    
    #<%= lblMensaje.ClientID %> {
        text-align: center;
    }
</style>

<asp:HiddenField ID="IdPaciente" runat="server" />

<div class="card-custom">
    <h2 class="text-center text-primary mb-4">Registro de Pacientes</h2>

    <div class="form-group">
        <label for="txtCedula">Cédula</label>
        <asp:TextBox ID="txtCedula" runat="server" CssClass="form-control" placeholder="Ej: 1-1234-5678"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="txtNombre">Nombre</label>
        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="txtApellido1">Primer Apellido</label>
        <asp:TextBox ID="txtApellido1" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="txtApellido2">Segundo Apellido</label>
        <asp:TextBox ID="txtApellido2" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="txtFechaNacimiento">Fecha de Nacimiento</label>
        <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="ddlGenero">Género</label>
        <asp:DropDownList ID="ddlGenero" runat="server" CssClass="form-control">
            <asp:ListItem Text="Seleccione..." Value="" />
            <asp:ListItem Text="Masculino" Value="M" />
            <asp:ListItem Text="Femenino" Value="F" />
        </asp:DropDownList>
    </div>

    <div class="form-group">
        <label for="txtTelefono">Teléfono</label>
        <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" placeholder="8888-8888"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="txtEmail">Correo</label>
        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
    </div>

    <hr />
    <h3 class="text-center">Crear Usuario</h3>

    <div class="form-group">
        <label>Usuario:</label>
        <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" />
    </div>

    <div class="form-group">
        <label>Contraseña:</label>
        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" />
    </div>

        <div class="btn-group-custom">
        <asp:Button CssClass="btn btn-success py-2 w-50" ID="btnGuardar" runat="server" Text="Registrarse" OnClick="btnGuardar_Click" />
        <asp:Button CssClass="btn btn-danger py-2 w-50" ID="btnLimpiar" runat="server" Text="Cancelar" OnClick="btnLimpiar_Click" />
    </div>


    <asp:Label ID="lblMensaje" runat="server" CssClass="mt-3 d-block"></asp:Label>
</div>
</asp:Content>
