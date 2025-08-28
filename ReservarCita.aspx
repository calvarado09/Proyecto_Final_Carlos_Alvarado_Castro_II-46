<%@ Page Title="Reservar Cita" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ReservarCita.aspx.vb" Inherits="Proyecto_Final_Carlos_Alvarado_Castro_II_46.ReservarCita" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .reserva-container {
            max-width: 700px;
            margin: 50px auto;
            padding: 30px;
            background-color: #ffffff;
            border-radius: 12px;
            box-shadow: 0 4px 20px rgba(0,0,0,0.1);
            font-family: Arial, sans-serif;
        }
        .doctor-header {
            display: flex;
            align-items: center;
            margin-bottom: 25px;
            border-bottom: 1px solid #eee;
            padding-bottom: 15px;
        }
        .doctor-header img {
            width: 140px;
            height: 140px;
            object-fit: cover;
            border-radius: 50%;
            margin-right: 20px;
            border: 3px solid #007bff;
        }
        .doctor-info h3 {
            margin: 0;
            color: #333;
        }
        .doctor-info p {
            margin: 3px 0;
            color: #666;
        }
        .form-group {
            margin: 15px 0;
        }
        .form-group label {
            font-weight: bold;
            color: #444;
        }
        .form-control {
            width: 100%;
            padding: 10px;
            margin-top: 5px;
            border-radius: 6px;
            border: 1px solid #ccc;
        }
        .btn-confirmar {
            width: 100%;
            padding: 12px;
            background: linear-gradient(90deg, #007bff, #0056b3);
            color: white;
            border: none;
            border-radius: 8px;
            font-size: 16px;
            cursor: pointer;
            transition: background 0.3s ease;
            margin-top: 20px;
        }
        .btn-confirmar:hover {
            background: linear-gradient(90deg, #0056b3, #00408d);
        }
        #lblMensajeCita {
            margin-top: 15px;
            display: block;
            text-align: center;
            font-weight: bold;
        }
    </style>

    <div class="reserva-container">
        <div class="doctor-header">
            <asp:Image ID="imgDoctor" runat="server" />
            <div class="doctor-info">
                <h3 id="lblNombreDoctor" runat="server"></h3>
                <h3 id="lblApellidos" runat="server"></h3>
                <p id="lblCodigoDoctor" runat="server"></p>
                <p id="lblEspecialidadDoctor" runat="server"></p>
                <p id="lblExperienciaDoctor" runat="server"></p>
            </div>
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
        <asp:Button CssClass="btn btn-primary py-2 w-50" ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" />
        <asp:Button ID="btnConfirmarCita" runat="server" CssClass="btn-confirmar" Text="Confirmar cita" OnClick="btnConfirmarCita_Click" />
        <asp:Label ID="lblMensajeCita" runat="server"></asp:Label>
    </div>
</asp:Content>
