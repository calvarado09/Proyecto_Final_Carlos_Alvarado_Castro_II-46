<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DoctorPanel.aspx.vb" Inherits="Proyecto_Final_Carlos_Alvarado_Castro_II_46.DoctorPanel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <style>
        .panel-container {
            display: flex;
            flex-wrap: wrap;
            gap: 20px;
        }

        .card {
            background: #fff;
            border-radius: 15px;
            box-shadow: 0 4px 10px rgba(0,0,0,0.1);
            padding: 20px;
            flex: 1 1 300px;
        }

        .card img {
            border-radius: 50%;
            width: 120px;
            height: 120px;
            object-fit: cover;
            margin-bottom: 10px;
        }

        .card h3 {
            margin: 10px 0 5px 0;
        }

        .citas-table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 15px;
        }

        .citas-table th, .citas-table td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: center;
        }

        .citas-table th {
            background-color: #4CAF50;
            color: white;
        }

        .section-title {
            margin-bottom: 10px;
            font-size: 20px;
            font-weight: bold;
        }
    </style>

    <div class="panel-container">      
        <div class="card">
            <div class="section-title">Mis Datos</div>
            <asp:Image ID="imgDoctor" runat="server" CssClass="rounded" />
            <h3><asp:Label ID="lblNombre" runat="server" Text=""></asp:Label></h3>
            <p><strong>Especialidad:</strong> <asp:Label ID="lblEspecialidad" runat="server" Text=""></asp:Label></p>
            <p><strong>Email:</strong> <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label></p>
            <p><strong>Teléfono:</strong> <asp:Label ID="lblTelefono" runat="server" Text=""></asp:Label></p>
        </div>
        <div class="card">
            <div class="section-title">Mis Citas Programadas</div>
            <asp:GridView ID="gvCitas" runat="server" CssClass="citas-table" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField DataField="Hora" HeaderText="Hora" />
                    <asp:BoundField DataField="PacienteNombre" HeaderText="Paciente" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
