<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfrmEstadistica.aspx.cs" Inherits="Taller.Web.Paginas.wfrmEstadistica" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="text-align: center;">
        <div class="row">
            <div class="col-sm-1"></div>

            <div class="col-sm-3">
                <h3>Reparaciones completas</h3>
                <div class="mb-3" style="display: flex; align-items: center; justify-content: center;">
                    <asp:ListBox ID="lstReparacionesCompletas" runat="server" CssClass="form-control" AutoPostBack="True" Style="margin-top: 1%; margin-bottom: 1%; width: 500px; max-width: 500px" OnSelectedIndexChanged="lstReparacionesCompletas_SelectedIndexChanged" />
                </div>
                <div class="mb-3">
                    <asp:TextBox ID="dtpFecha1C1" runat="server" CssClass="form-control" Style="display: inline; margin-top: 1%; margin-bottom: 2%; width: 100px;" TextMode="Date" />
                    <asp:TextBox ID="dtpFecha2C1" runat="server" CssClass="form-control" Style="display: inline; margin-top: 1%; margin-bottom: 2%; width: 100px;" TextMode="Date" />
                </div>
                <p>
                    <asp:Label ID="lblMensajesCompletas" runat="server" />
                </p>
                <div class="mb-3">
                    &nbsp;<asp:Button ID="btnConsulta1" runat="server" Text="Consultar" CssClass="btn btn-default" OnClick="btnConsulta1_Click" />
                </div>
            </div>

            <div class="col-sm-3">
                <h3>Reparaciones pendientes</h3>
                <div class="mb-3" style="display: flex; align-items: center; justify-content: center;">
                    <asp:ListBox ID="lstReparacionesPendientes" runat="server" CssClass="form-control" AutoPostBack="True" Style="margin-top: 1%; margin-bottom: 1%; width: 500px; max-width: 500px" OnSelectedIndexChanged="lstReparacionesPendientes_SelectedIndexChanged" />
                </div>
                <div class="mb-3">
                    <asp:TextBox ID="dtpFecha1C2" runat="server" CssClass="form-control" Style="display: inline; margin-top: 1%; margin-bottom: 2%; width: 100px;" TextMode="Date" />
                    <asp:TextBox ID="dtpFecha2C2" runat="server" CssClass="form-control" Style="display: inline; margin-top: 1%; margin-bottom: 2%; width: 100px;" TextMode="Date" />
                </div>
                <p>
                    <asp:Label ID="lblMensajesPendientes" runat="server" />
                </p>
                <div class="mb-3">
                    &nbsp;<asp:Button ID="btnConsulta2" runat="server" Text="Consultar" CssClass="btn btn-default" OnClick="btnConsulta2_Click" />
                </div>
            </div>

            <div class="col-sm-3">
                <h3>Repuestos más vendidos</h3>
                <div class="mb-3" style="display: flex; align-items: center; justify-content: center;">
                    <asp:ListBox ID="lstRepuestosMasVendidos" runat="server" CssClass="form-control" AutoPostBack="True" Style="margin-top: 1%; margin-bottom: 1%; width: 500px; max-width: 500px" OnSelectedIndexChanged="lstRepuestosMasVendidos_SelectedIndexChanged" />
                </div>
            </div>

            <div class="col-sm-1"></div>
        </div>
    </div>
</asp:Content>
