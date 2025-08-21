<%@ Page Title="Reservar Cita" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ReservarCita.aspx.vb" Inherits="Proyecto_Final_Carlos_Alvarado_Castro_II_46.ReservarCita" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .reserva-container {
            max-width: 500px;
            margin: 50px auto;
            padding: 30px;
            background-color: #fff;
            border-radius: 12px;
            box-shadow: 0 4px 12px rgba(0,0,0,0.1);
            text-align: center;
        }
        .doctor-info img {
            width: 150px;
            height: 150px;
            object-fit: cover;
            border-radius: 50%;
            margin-bottom: 15px;
        }
        .form-group {
            margin: 15px 0;
            text-align: left;
        }
        .form-group label {
            font-weight: bold;
        }
        .form-control, .btn-confirmar {
            width: 100%;
            padding: 8px 12px;
            margin-top: 5px;
            border-radius: 6px;
            border: 1px solid #ccc;
        }
        .btn-confirmar {
            background-color: #007bff;
            color: white;
            border: none;
            cursor: pointer;
            margin-top: 20px;
        }
        .btn-confirmar:hover {
            background-color: #0056b3;
        }
        #lblMensajeCita {
            margin-top: 15px;
            display: block;
            text-align: center;
        }
    </style>

    <div class="reserva-container">
        <div class="doctor-info">
            <asp:Image ID="imgDoctor" runat="server" />
            <h3 id="lblNombreDoctor" runat="server"></h3>
            <p id="lblEspecialidadDoctor" runat="server"></p>
        </div>

        <asp:HiddenField ID="hfDoctorID" runat="server" />

        <div class="form-group">
            <label for="txtFechaCita">Fecha de la cita:</label>
            <asp:TextBox ID="txtFechaCita" runat="server" CssClass="form-control" TextMode="Date" AutoPostBack="True" OnTextChanged="txtFechaCita_TextChanged"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="ddlHorasCita">Hora de la cita:</label>
            <asp:DropDownList ID="ddlHorasCita" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>

        <asp:Button ID="btnConfirmarCita" runat="server" CssClass="btn-confirmar" Text="Confirmar cita" OnClick="btnConfirmarCita_Click" />
        <asp:Label ID="lblMensajeCita" runat="server"></asp:Label>
    </div>
</asp:Content>
