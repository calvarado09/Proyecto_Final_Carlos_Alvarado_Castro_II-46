<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="RegistrodeDoctores.aspx.vb" Inherits="Proyecto_Final_Carlos_Alvarado_Castro_II_46.RegistrodeDoctores" %>
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

    <asp:HiddenField ID="IdDoctor" runat="server" />

    <div class="card-custom">
        <h2 class="text-center text-primary mb-4">Registro de Doctores</h2>

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
            <label for="txtEspecialidad">Especialidad</label>
            <asp:TextBox ID="txtEspecialidad" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="txtCodigo">Código de colegiado </label>
            <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="txtTelefono">Teléfono</label>
            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" placeholder="8888-8888"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="txtEmail">Correo</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
        </div>


        <div class="form-group w-75 mx-auto mb-3">
            <label for="fuFoto">Foto del Doctor</label>
            <asp:FileUpload ID="fuFoto" runat="server" CssClass="form-control-file" />
        </div>

        <div class="form-group text-center">
            <asp:Image ID="imgDoctor" runat="server" Width="150px" Height="150px" Visible="False" CssClass="mb-3 rounded" />
        </div>


        <div class="btn-group-custom">
            <asp:Button CssClass="btn btn-success py-2 w-50" ID="btnGuardar" runat="server" Text="Guardar Doctor" OnClick="btnGuardar_Click" />
            <asp:Button CssClass="btn btn-danger py-2 w-50" ID="btnLimpiar" runat="server" Text="Cancelar" OnClick="btnLimpiar_Click" />
        </div>

        <asp:Label ID="lblMensaje" runat="server" CssClass="mt-3 d-block"></asp:Label>
    </div>

    <div class="d-flex justify-content-center mt-5">
    <div class="mi-gridview-container">
        <h3 class="text-center mb-3">Lista de Doctores</h3>

        <asp:GridView ID="gvDoctores" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="DoctorID"
            OnSelectedIndexChanged="gvDoctores_SelectedIndexChanged"
            OnRowDeleting="gvDoctores_RowDeleting"
            CssClass="mi-gridview"
            HeaderStyle-BackColor="#007bff" HeaderStyle-ForeColor="white"
            RowStyle-BackColor="#e7f1f4" RowStyle-ForeColor="#000000"
            AlternatingRowStyle-BackColor="#bdd3f1" AlternatingRowStyle-ForeColor="#000000"
            GridLines="None">

            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="DoctorID" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Apellido1" HeaderText="Apellido1" />
                <asp:BoundField DataField="Apellido2" HeaderText="Apellido2" />
                <asp:BoundField DataField="Especialidad" HeaderText="Especialidad" />
                <asp:BoundField DataField="CodigoColegiado" HeaderText="Código" />
                <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Cedula" HeaderText="Cédula" />

                <asp:TemplateField HeaderText="Foto">
                    <ItemTemplate>
                        <asp:Image ID="imgGridFoto" runat="server" Width="50px" Height="50px"
                            ImageUrl='<%# Eval("Foto") %>' CssClass="rounded-circle" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
    </div>
</div>

<style>
.mi-gridview-container {
    width: 95%;
    margin: 0 auto;
    overflow-x: auto; /* scroll horizontal si es necesario */
}

.mi-gridview {
    border-radius: 10px;
    overflow: hidden;
    box-shadow: 0 4px 8px rgba(0,0,0,0.1);
    table-layout: fixed; /* columnas distribuidas uniformemente */
    width: 100%;
}

.mi-gridview th, .mi-gridview td {
    text-align: center;
    word-wrap: break-word;
}
</style>


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
