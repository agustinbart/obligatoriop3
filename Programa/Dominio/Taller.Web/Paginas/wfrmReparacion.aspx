<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfrmReparacion.aspx.cs" Inherits="Taller.Web.Paginas.wfrmReparacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="text-align: center;">
        <div class="row">
            <div class="col-sm-1"></div>

            <div class="col-sm-3">
                <h3>Reparación</h3>
                <div class="mb-3" style="display: flex; align-items: center; justify-content: center;">
                    <asp:TextBox ID="txtId" runat="server" CssClass="form-control" placeholder="Id" Style="margin-top: 1%; margin-bottom: 1%; width: 500px; max-width: 500px" />
                </div>
                <div class="mb-3" style="display: flex; align-items: center; justify-content: center;">
                    <asp:TextBox ID="txtAnio" runat="server" CssClass="form-control" placeholder="Año" Style="margin-top: 1%; margin-bottom: 1%; width: 500px; max-width: 500px" Enabled="false"  />
                </div>
                <div class="mb-3" style="display: flex; align-items: center; justify-content: center;">
                    <asp:DropDownList ID="ddlVehiculo" runat="server" CssClass="form-control" placeholder="Vehiculo" Style="margin-top: 1%; margin-bottom: 1%; width: 500px; max-width: 500px" Enabled="False" OnSelectedIndexChanged="ddlVehiculo_SelectedIndexChanged" />
                </div>
                <div class="mb-3" style="display: flex; align-items: center; justify-content: center;">
                    <asp:TextBox ID="dtpFechaEntrada" runat="server" CssClass="form-control" Style="margin-top: 1%; margin-bottom: 1%; width: 500px; max-width: 500px" TextMode="Date" />
                </div>
                <div class="mb-3" style="display: flex; align-items: center; justify-content: center;">
                    <asp:TextBox ID="dtpFechaSalida" runat="server" CssClass="form-control" Style="margin-top: 1%; margin-bottom: 1%; width: 500px; max-width: 500px" TextMode="Date" />
                </div>
                <div class="mb-3" style="display: flex; align-items: center; justify-content: center;">
                    <asp:DropDownList ID="ddlMecanico" runat="server" CssClass="form-control" placeholder="" Style="margin-top: 1%; margin-bottom: 1%; width: 500px; max-width: 500px" OnSelectedIndexChanged="ddlMecanico_SelectedIndexChanged" />
                </div>
                <div class="mb-3" style="display: flex; align-items: center; justify-content: center;">
                    <asp:TextBox ID="txtDescripcionEntrada" runat="server" CssClass="form-control" placeholder="Descripción de entrada" Style="margin-top: 1%; margin-bottom: 1%; width: 500px; max-width: 500px" />
                </div>
                <div class="mb-3" style="display: flex; align-items: center; justify-content: center;">
                    <asp:TextBox ID="txtDescripcionSalida" runat="server" CssClass="form-control" placeholder="Descripción de Salida" Style="margin-top: 1%; margin-bottom: 1%; width: 500px; max-width: 500px" />
                </div>
                <div class="mb-3" style="display: flex; align-items: center; justify-content: center;">
                    <asp:TextBox ID="txtKmEntrada" runat="server" CssClass="form-control" placeholder="Kilometros de entrada" Style="margin-top: 1%; margin-bottom: 1%; width: 500px; max-width: 500px" />
                </div>
                <div class="mb-8">
                    <asp:Button ID="btnAlta" runat="server" Text="Alta" CssClass="btn btn-default" OnClick="btnAlta_Click" />
                    &nbsp;<asp:Button ID="btnBaja" runat="server" Text="Baja" CssClass="btn btn-default" OnClick="btnBaja_Click" />
                    &nbsp;<asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-default" OnClick="btnModificar_Click" />
                </div>
                <p>
                    <asp:Label ID="lblMensajes" runat="server" />
                </p>
                <div class="mb-8" style="display: flex; align-items: center; justify-content: center;">
                    <asp:ListBox ID="lstReparaciones" runat="server" CssClass="form-control" AutoPostBack="True" Style="margin-top: 1%; margin-bottom: 1%; width: 500px; max-width: 500px" OnSelectedIndexChanged="lstReparaciones_SelectedIndexChanged" />
                </div>
                <div class="mb-8">
                    &nbsp;<asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn btn-default" OnClick="btnLimpiar_Click" />
                </div>
            </div>

            <div class="col-sm-3">
                <h3>Repuestos</h3>
                <div class="mb-3" style="display: flex; align-items: center; justify-content: center;">
                    <asp:TextBox ID="txtIdRepuestos" runat="server" CssClass="form-control" placeholder="Id" Style="margin-top: 1%; margin-bottom: 1%; width: 500px; max-width: 500px" Enabled="False" />
                </div>
                <div class="mb-3" style="display: flex; align-items: center; justify-content: center;">
                    <asp:TextBox ID="txtAnioRepuestos" runat="server" CssClass="form-control" placeholder="Año" Style="margin-top: 1%; margin-bottom: 1%; width: 500px; max-width: 500px" Enabled="False" />
                </div>
                <div class="mb-3" style="display: flex; align-items: center; justify-content: center;">
                    <asp:DropDownList ID="ddlRepuestos" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlRepuestos_SelectedIndexChanged" AutoPostBack="True" />
                </div>
                <div class="mb-3" style="display: flex; align-items: center; justify-content: center;">
                    <asp:TextBox ID="txtCantidadRepuesto" runat="server" CssClass="form-control" placeholder="Cantidad repuesto" Style="margin-top: 1%; margin-bottom: 1%; width: 500px; max-width: 500px" />
                </div>
                <div class="mb-3" style="display: flex; align-items: center; justify-content: center;">
                    <asp:TextBox ID="txtCostoUnitario" runat="server" CssClass="form-control" placeholder="Costo unitario" Style="margin-top: 1%; margin-bottom: 1%; width: 500px; max-width: 500px" Enabled="False" />
                </div>
                <div class="mb-3" style="display: flex; align-items: center; justify-content: center;">
                    <asp:Button ID="btnAgregarRepuesto" runat="server" CssClass="form-control" Text="Agregar repuesto" OnClick="btnAgregarRepuesto_Click" />
                </div>
                <p>
                    <asp:Label ID="lblMensajesRepuesto" runat="server" />
                </p>
                <div class="mb-8" style="display: flex; align-items: center; justify-content: center;">
                    <asp:ListBox ID="lstReparacionRepuestos" runat="server" CssClass="form-control" Style="margin-top: 1%; margin-bottom: 1%; width: 500px; max-width: 500px" AutoPostBack="True" OnSelectedIndexChanged="lstReparacionRepuestos_SelectedIndexChanged" />
                </div>
                <div class="mb-8" style="display: flex; align-items: center; justify-content: center;">
                    <asp:Button ID="btnEliminarRepuesto" runat="server" CssClass="form-control" Text="Eliminar repuesto" OnClick="btnEliminarRepuesto_Click" />
                </div>
            </div>

            <div class="col-sm-3">
                <h3>Horas</h3>
                <div class="mb-3" style="display: flex; align-items: center; justify-content: center;">
                    <asp:TextBox ID="txtIdHoras" runat="server" CssClass="form-control" placeholder="Id" Style="margin-top: 1%; margin-bottom: 1%; width: 500px; max-width: 500px" Enabled="False" />
                </div>
                <div class="mb-3" style="display: flex; align-items: center; justify-content: center;">
                    <asp:TextBox ID="txtAnioHoras" runat="server" CssClass="form-control" placeholder="Año" Style="margin-top: 1%; margin-bottom: 1%; width: 500px; max-width: 500px" Enabled="False" />
                </div>
                <div class="mb-3" style="display: flex; align-items: center; justify-content: center;">
                    <asp:TextBox ID="txtIdMecanicoHoras" runat="server" CssClass="form-control" placeholder="Mecanico" Style="margin-top: 1%; margin-bottom: 1%; width: 500px; max-width: 500px" Enabled="False" />
                </div>
                <div class="mb-3" style="display: flex; align-items: center; justify-content: center;">
                    <asp:TextBox ID="txtHoras" runat="server" CssClass="form-control" placeholder="Horas" Style="margin-top: 1%; margin-bottom: 1%; width: 500px; max-width: 500px" />
                </div>
                <div class="mb-3" style="display: flex; align-items: center; justify-content: center;">
                    <asp:TextBox ID="txtCostoHora" runat="server" CssClass="form-control" placeholder="Costo Hora" Style="margin-top: 1%; margin-bottom: 1%; width: 500px; max-width: 500px" Enabled="False" />
                </div>
                <p>
                    <asp:Label ID="lblMensajesHoras" runat="server" />
                </p>
                <div class="mb-8" style="display: flex; align-items: center; justify-content: center;">
                    <asp:Button ID="btnAgregarHoras" runat="server" CssClass="form-control" Text="Agregar horas" OnClick="btnAgregarHoras_Click" />
                    <asp:Button ID="btnModificarHoras" runat="server" CssClass="form-control" Text="Modificar horas" OnClick="btnModificarHoras_Click" />
                </div>


                <h3>Pendientes</h3>
                <div class="mb-8" style="display: flex; align-items: center; justify-content: center;">
                    <asp:ListBox ID="lstPendientes" runat="server" CssClass="form-control" AutoPostBack="True" Style="margin-top: 1%; margin-bottom: 1%; width: 500px; max-width: 500px" OnSelectedIndexChanged="lstPendientes_SelectedIndexChanged" />
                </div>

                <h3>Reservas</h3>
                <div class="mb-8" style="display: flex; align-items: center; justify-content: center;">
                    <asp:ListBox ID="lstReservas" runat="server" CssClass="form-control" AutoPostBack="True" Style="margin-top: 1%; margin-bottom: 1%; width: 500px; max-width: 500px" OnSelectedIndexChanged="lstReservas_SelectedIndexChanged" />
                    <asp:TextBox ID="txtIdReserva" runat="server" CssClass="form-control" placeholder="Id" Visible="False"/>
                    <asp:TextBox ID="txtIdCliente" runat="server" CssClass="form-control" placeholder="Id Cliente" Visible="False" />

                </div>
                <p>
                    <asp:Label ID="lblMensajesReserva" runat="server" />
                </p>
                <div class="mb-8">
                    &nbsp;<asp:Button ID="btnRechazar" runat="server" Text="Rechazar" CssClass="btn btn-default" OnClick="btnRechazar_Click" />
                    &nbsp;<asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-default" OnClick="btnAceptar_Click" />
                </div>
            </div>

            <div class="col-sm-1"></div>
        </div>
    </div>
</asp:Content>
