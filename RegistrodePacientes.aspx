<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="RegistrodePacientes.aspx.vb" Inherits="Proyecto_Final_Carlos_Alvarado_Castro_II_46.RegistrodePacientes" %>
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

        <div class="btn-group-custom">
            <asp:Button CssClass="btn btn-success py-2 w-50" ID="btnGuardar" runat="server" Text="Guardar Paciente" OnClick="btnGuardar_Click" />
            <asp:Button CssClass="btn btn-danger py-2 w-50" ID="btnLimpiar" runat="server" Text="Cancelar" OnClick="btnLimpiar_Click" />
        </div>

        <asp:Label ID="lblMensaje" runat="server" CssClass="mt-3 d-block"></asp:Label>
    </div>

    <div class="d-flex justify-content-center mt-5">
    <div style="width: 95%;">
        <h3 class="text-center mb-3">Lista de Pacientes</h3>

        <asp:GridView ID="gvPacientes" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="PacienteID"
            OnSelectedIndexChanged="gvPacientes_SelectedIndexChanged"
            OnRowDeleting="gvPacientes_RowDeleting"
            CssClass="mi-gridview"
            HeaderStyle-BackColor="#007bff" HeaderStyle-ForeColor="white"
            RowStyle-BackColor="#e7f1f4" RowStyle-ForeColor="#000000"
            AlternatingRowStyle-BackColor="#bdd3f1" AlternatingRowStyle-ForeColor="#000000"
            GridLines="None"
            Width="100%">

            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="PacienteID" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Apellido1" HeaderText="Apellido1" />
                <asp:BoundField DataField="Apellido2" HeaderText="Apellido2" />
                <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha Nacimiento" DataFormatString="{0:yyyy-MM-dd}" />
                <asp:BoundField DataField="Genero" HeaderText="Género" />
                <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Cedula" HeaderText="Cédula" />
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
    </div>
</div>

<style>
.mi-gridview {
    border-radius: 10px;
    overflow: hidden;
    box-shadow: 0 4px 8px rgba(0,0,0,0.1);
}

.mi-gridview th {
    text-align: center;
    font-weight: bold;
}

.mi-gridview td {
    text-align: center;
}
</style>

</asp:Content>
