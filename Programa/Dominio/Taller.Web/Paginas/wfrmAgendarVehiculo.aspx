<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfrmAgendarVehiculo.aspx.cs" Inherits="Taller.Web.Paginas.wfrmAgendarVehiculo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="text-align: center;">
        <div class="row">
            <div class="col-sm-2"></div>
            <div class="col-sm-8">
                <h3>Agendar Vehículo
                </h3>
                <div class="mb-3" style="display: flex; align-items: center; justify-content: center;">
                    <asp:TextBox ID="txtId" runat="server" CssClass="form-control" placeholder="Id" Visible="False" />
                </div>
                <div class="mb-3" style="display: flex; align-items: center; justify-content: center;">
                    <asp:TextBox ID="txtIdCliente" runat="server" CssClass="form-control" placeholder="Id Cliente" Visible="False"/>
                </div>
                <div class="mb-3" style="display: flex; align-items: center; justify-content: center;">
                    <asp:TextBox ID="dtpFecha" runat="server" CssClass="form-control" Style="margin-top: 1%; margin-bottom: 1%; width: 1500px; max-width: 500px" TextMode="Date" />
                </div>
                <div class="mb-3" style="display: flex; align-items: center; justify-content: center;">
                    <asp:TextBox ID="txtDescripcionProblema" runat="server" CssClass="form-control" placeholder="Descripción del problema" Style="margin-top: 1%; margin-bottom: 1%; width: 1500px; max-width: 500px" />
                </div>
                <div class="mb-3" style="display: flex; align-items: center; justify-content: center;">
                    <asp:DropDownList ID="ddlVehiculos" runat="server" CssClass="form-control" placeholder="" Style="margin-top: 1%; margin-bottom: 1%; width: 500px; max-width: 500px" OnSelectedIndexChanged="ddlVehiculos_SelectedIndexChanged" />
                </div>
                <p>
                    <asp:Label ID="lblMensajes" runat="server" />
                </p>
                <div class="mb-8">
                    <asp:Button ID="btnAgendar" runat="server" Text="Solicitar reserva" CssClass="btn btn-default" OnClick="btnAgendar_Click" />
                </div>
            </div>
            <div class="col-sm-2"></div>
        </div>
    </div>
</asp:Content>
