<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DoctoresPublico.aspx.vb" Inherits="Proyecto_Final_Carlos_Alvarado_Castro_II_46.DoctoresPublico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <style>
          .doctor-card {
              border: 1px solid #ddd;
              border-radius: 12px;
              padding: 16px;
              margin: 12px;
              text-align: center;
              width: 250px;
              box-shadow: 0 2px 8px rgba(0,0,0,0.1);
              transition: transform 0.2s ease-in-out;
              height: 300px; 
              display: flex;
              flex-direction: column;
              justify-content: space-between; 
              align-items: center;
          }
        .doctor-card:hover {
            transform: scale(1.03);
        }
        .doctor-card img {
            width: 120px;
            height: 120px;
            object-fit: cover;
            border-radius: 50%;
            margin-bottom: 10px;
        }
        .doctor-container {
            display: flex;
            flex-wrap: wrap;
            justify-content: center;
        }
        .btn-agendar {
            display: inline-block;
            padding: 8px 14px;
            background-color: #007bff;
            color: white;
            border-radius: 6px;
            text-decoration: none;
        }
        .btn-agendar:hover {
            background-color: #0056b3;
        }
    </style>

    <div class="doctor-container">
        <asp:Repeater ID="rptDoctores" runat="server">
            <ItemTemplate>
                <div class="doctor-card">
                    <img src='<%# ResolveUrl(Eval("Foto").ToString()) %>' alt="Foto Doctor" />
                    <h4><%# Eval("Nombre") %></h4>
                    <p><strong>Especialidad:</strong> <%# Eval("Especialidad") %></p>
                    <a href='<%# "ReservarCita.aspx?idDoctor=" & Eval("DoctorId") %>' class="btn-agendar">
                        Agendar Cita
                    </a>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
