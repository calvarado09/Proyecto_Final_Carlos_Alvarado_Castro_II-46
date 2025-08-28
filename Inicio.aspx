<%@ Page Title="Inicio" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Inicio.aspx.vb" Inherits="Proyecto_Final_Carlos_Alvarado_Castro_II_46.Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
.hero {
    background-color: #87CEEB; 
    color: white;
    text-align: center;
    padding: 120px 20px;
    border-radius: 12px;
    position: relative;
    margin-bottom: 40px;
    overflow: hidden;
}

.hero::after {
    content: '';
    position: absolute;
    top: 0; left: 0;
    width: 100%; height: 100%;
    background: rgba(0,0,0,0.2); 
    border-radius: 12px;
}

.hero h1, .hero p, .hero .btn {
    position: relative;
    z-index: 1;
}

.hero h1 {
    font-size: 3rem;
    font-weight: bold;
    margin-bottom: 15px;
}

.hero p {
    font-size: 1.2rem;
    margin-bottom: 25px;
}

.hero .btn {
    font-size: 1.2rem;
    padding: 12px 30px;
    border-radius: 8px;
    box-shadow: 0 4px 10px rgba(0,0,0,0.2);
    background-color: #0099FF;
    border: none;
    transition: transform 0.2s, background-color 0.2s;
    color: white;
}

.hero .btn:hover {
    transform: translateY(-3px);
    background-color: #007ACC;
}


.section {
    padding: 50px 20px;
}


.services .card {
    background-color: #E0F7FF; 
    border-radius: 12px;
    box-shadow: 0 6px 15px rgba(0,0,0,0.05);
    transition: transform 0.3s, box-shadow 0.3s;
}

.services .card:hover {
    transform: translateY(-7px);
    box-shadow: 0 8px 20px rgba(0,0,0,0.1);
}

.services .card-body {
    text-align: center;
}

.services .card-title {
    color: #007ACC;
    font-weight: bold;
}


.bg-light {
    background-color: #87CEEB; 
    color: #003366;
    padding: 50px 20px;
    border-radius: 12px;
    margin-top: 40px;
    text-align: center;
}

.bg-light p {
    margin: 5px 0;
    font-size: 1.1rem;
     color: #003366;
}


h2 {
    color: #007ACC;
    margin-bottom: 20px;
}

p {
    line-height: 1.6;
}
</style>


<div class="hero d-flex flex-column justify-content-center align-items-center">
    <h1>Clínica Salud Total</h1>
    <p>Atención médica de calidad para toda la familia</p>
    <asp:Button ID="btnReservar" runat="server" CssClass="btn btn-primary" Text="Reservar Cita" PostBackUrl="~/DoctoresPublico.aspx" />
</div>


<div class="section text-center">
    <h2>Bienvenido a nuestra clínica</h2>
    <p>En Clínica Salud Total nos preocupamos por tu bienestar. Nuestro equipo de doctores altamente calificado está listo para ofrecerte la mejor atención.</p>
</div>

<div class="section services container">
    <h2 class="text-center mb-5">Nuestros Servicios</h2>
    <div class="row">
        <div class="col-md-4 mb-4">
            <div class="card p-3">
                <div class="card-body">
                    <h5 class="card-title">Medicina General</h5>
                    <p class="card-text">Consultas generales y atención primaria para toda la familia.</p>
                </div>
            </div>
        </div>
        <div class="col-md-4 mb-4">
            <div class="card p-3">
                <div class="card-body">
                    <h5 class="card-title">Pediatría</h5>
                    <p class="card-text">Cuidado especializado para el bienestar de tus hijos.</p>
                </div>
            </div>
        </div>
        <div class="col-md-4 mb-4">
            <div class="card p-3">
                <div class="card-body">
                    <h5 class="card-title">Especialistas</h5>
                    <p class="card-text">Contamos con especialistas en diversas áreas para cuidar tu salud y la de toda tu familia.</p>
                </div>
            </div>
        </div>
    </div>
</div>

<div class="section bg-light text-center">
    <h2>Contáctanos</h2>
    <p>Teléfono: (506) 1234-5678 | Correo: info@clinicasaludtotal.com</p>
    <p>Dirección: Calle Principal, San José, Costa Rica</p>
</div>

</asp:Content>

