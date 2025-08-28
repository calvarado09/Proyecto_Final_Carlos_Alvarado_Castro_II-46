<%@ Page Title="Contacto" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.vb" Inherits="Proyecto_Final_Carlos_Alvarado_Castro_II_46.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        main {
            max-width: 800px;
            margin: 0 auto;
            padding: 50px 20px;
            background-color: #87CEEB; 
            border-radius: 12px;
            box-shadow: 0 6px 15px rgba(0,0,0,0.1);
            text-align: center;
        }

        main h2 {
            color: #007ACC; 
            font-size: 2.5rem;
            margin-bottom: 20px;
        }

        main p {
            font-size: 1.2rem;
            margin-bottom: 30px;
            color: #003366;
        }

        address {
            font-style: normal;
            color: #003366;
            margin-bottom: 20px;
            line-height: 1.6;
        }

        address a {
            color: #0056b3;
            text-decoration: none;
            transition: color 0.2s;
        }

        address a:hover {
            color: #007ACC;
            text-decoration: underline;
        }

        .contact-section {
            display: flex;
            flex-direction: column;
            gap: 25px;
            align-items: center;
        }

        .contact-card {
            background-color: #E0F7FF; 
            padding: 20px 30px;
            border-radius: 12px;
            width: 100%;
            max-width: 500px;
            box-shadow: 0 4px 12px rgba(0,0,0,0.05);
            transition: transform 0.3s, box-shadow 0.3s;
        }

        .contact-card:hover {
            transform: translateY(-5px);
            box-shadow: 0 6px 18px rgba(0,0,0,0.1);
        }
    </style>

    <main aria-labelledby="title">
        <h2 id="title"><%: Title %></h2>
        <p>Estamos aquí para ayudarte. Contáctanos por cualquiera de estos medios:</p>

        <div class="contact-section">
            <div class="contact-card">
                <strong>Dirección:</strong>
                <address>
                    Calle Principal, San José, Costa Rica
                </address>
            </div>

            <div class="contact-card">
                <strong>Teléfono:</strong>
                <address>
                    <abbr title="Phone"></abbr> (506) 1234-5678
                </address>
            </div>

            <div class="contact-card">
                <strong>Correo:</strong>
                <address>
                    <a href="mailto:info@clinicasaludtotal.com">info@clinicasaludtotal.com</a>
                </address>
            </div>
        </div>
    </main>

</asp:Content>

