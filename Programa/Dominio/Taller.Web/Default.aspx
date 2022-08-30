<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Taller.Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron" style="text-align: center">
        <h2 style="font-size: 60px">Taller Mecánico</h2>
        <p>Somos un taller mecánico altamente especializado en multimarcas, brindando a todos nuestros clientes la confianza y el respaldo brindado a través de todos nuestros servicios.</p>
        <img src="/Imagenes/mecanico.png" style="width: 200px;" />
    </div>

    <div class="row">
        <div class="col-md-4">
            <h3>1. Registrese</h3>
            <p>
                Para poder acceder a registrar su vehículo y solicitar una reserva, necesita iniciar sesión.
            </p>
            <p>
                <a class="btn btn-default" runat="server" href="~/Paginas/wfrmRegistro">Registrarse</a>
            </p>
        </div>
        <div class="col-md-4">
            <h3>2. Registre su vehículo</h3>
            <p>
                Antes de solicitar una reserva, registre su vehículo.
            </p>
            <p>
                <a class="btn btn-default" runat="server" href="~/Paginas/wfrmRegistroVehiculo">Registrar vehículo</a>
            </p>
        </div>
        <div class="col-md-4">
            <h3>3. Solicitar Reserva</h3>
            <p>
                Para solicitar una reserva, necesitamos los datos del vehículo, la fecha que desea llevarlo al taller y una breve descripción del problema.
            </p>
            <p>
                <a class="btn btn-default" runat="server" href="~/Paginas/wfrmAgendarVehiculo">Solicitar reserva</a>
            </p>
        </div>
    </div>

</asp:Content>
