<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AdminPanel.aspx.vb" Inherits="Proyecto_Final_Carlos_Alvarado_Castro_II_46.AdminPanel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <style>
        body {
            background-color: #f5f7fa;
        }

        .admin-container {
            display: flex;
            flex-wrap: wrap;
            justify-content: center;
            gap: 30px;
            margin-top: 50px;
        }

        .admin-card {
            background-color: #ffffff;
            width: 250px;
            height: 200px;
            border-radius: 15px;
            box-shadow: 0 4px 12px rgba(0,0,0,0.15);
            display: flex;
            flex-direction: column;
            justify-content: center;
            align-items: center;
            cursor: pointer;
            text-align: center;
            transition: transform 0.2s ease, box-shadow 0.2s ease;
            text-decoration: none;
            color: #333;
        }

        .admin-card:hover {
            transform: translateY(-5px);
            box-shadow: 0 8px 20px rgba(0,0,0,0.25);
        }

        .admin-card h3 {
            margin: 10px 0 5px 0;
            font-size: 1.3rem;
        }

        .admin-card p {
            font-size: 0.95rem;
            color: #666;
        }

        .admin-card i {
            font-size: 2.5rem;
            color: #007bff;
        }
    </style>

    <div class="admin-container">
        <a href="RegistrodePacientes.aspx" class="admin-card">
            <i class="fas fa-user-plus"></i>
            <h3>Registrar Paciente</h3>
            <p>Crear nuevo paciente y usuario</p>
        </a>

        <a href="RegistroDoctores.aspx" class="admin-card">
            <i class="fas fa-user-md"></i>
            <h3>Registrar Doctor</h3>
            <p>Agregar doctores al sistema</p>
        </a>

        <a href="VerCitas.aspx" class="admin-card">
            <i class="fas fa-calendar-check"></i>
            <h3>Citas Programadas</h3>
            <p>Ver y gestionar citas</p>
        </a>

        <a href="ConfiguracionRoles.aspx" class="admin-card">
            <i class="fas fa-cogs"></i>
            <h3>Roles y Configuración</h3>
            <p>Administrar permisos</p>
        </a>
    </div>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css" rel="stylesheet">
</asp:Content>
