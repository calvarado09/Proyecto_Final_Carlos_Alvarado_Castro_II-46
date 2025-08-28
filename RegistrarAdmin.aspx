<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="RegistrarAdmin.aspx.vb" Inherits="Proyecto_Final_Carlos_Alvarado_Castro_II_46.RegistrarAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="container mt-4">
        <div class="card shadow-sm border-0 rounded-3">
            <div class="card-body">
                <h2 class="mb-4 text-primary">Registrar Usuario Administrativo</h2>

                <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger fw-bold"></asp:Label>

                <div class="mb-3">
                    <asp:Label ID="Label1" runat="server" AssociatedControlID="txtUsuario" CssClass="form-label" Text="Usuario:"></asp:Label>
                    <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="mb-3">
                    <asp:Label ID="Label2" runat="server" AssociatedControlID="txtContraseña" CssClass="form-label" Text="Contraseña:"></asp:Label>
                    <asp:TextBox ID="txtContraseña" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                </div>
                <asp:Button CssClass="btn btn-primary py-2 w-50" ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" />
                <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="btn btn-primary" OnClick="btnRegistrar_Click" />
            </div>

        </div>

        <div class="card shadow-sm border-0 rounded-3 mt-4">
            <div class="card-body">
                <h3 class="mb-3 text-secondary">Lista de Usuarios</h3>
                <div class="table-responsive">
                    <asp:GridView ID="gvUsuarios" runat="server" AutoGenerateColumns="False" GridLines="None"
                                  DataKeyNames="UsuarioID"
                                  OnRowDeleting="gvUsuarios_RowDeleting"
                                  CssClass="table table-striped table-bordered align-middle"
                                  EmptyDataText="No hay usuarios registrados">
                        <Columns>
                            <asp:BoundField DataField="UsuarioID" HeaderText="ID" />
                            <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
                            <asp:BoundField DataField="Rol" HeaderText="Rol" />
                            <asp:BoundField DataField="PacienteNombre" HeaderText="Paciente" />
                            <asp:BoundField DataField="DoctorNombre" HeaderText="Doctor" />
                            <asp:CommandField ShowDeleteButton="True" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
