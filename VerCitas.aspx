<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="VerCitas.aspx.vb" Inherits="Proyecto_Final_Carlos_Alvarado_Castro_II_46.VerCitas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Listado de Citas</h2>

    <asp:GridView ID="gvCitas" runat="server" AutoGenerateColumns="False" CssClass="table table-striped"
        DataKeyNames="CitaID" OnRowDeleting="gvCitas_RowDeleting">
        <Columns>
            <asp:BoundField DataField="CitaID" HeaderText="ID" />
            <asp:BoundField DataField="Paciente" HeaderText="Paciente" />
            <asp:BoundField DataField="Doctor" HeaderText="Doctor" />
            <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="Hora" HeaderText="Hora" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" />
            <asp:CommandField ShowDeleteButton="True" DeleteText="Cancelar" />
        </Columns>
    </asp:GridView>
    <asp:Button CssClass="btn btn-primary py-2 w-50" ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" />



    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
</asp:Content>
