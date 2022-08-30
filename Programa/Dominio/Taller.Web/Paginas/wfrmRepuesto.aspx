<%@ Page Title="Formulario Repuestos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfrmRepuesto.aspx.cs" Inherits="Taller.Web.Paginas.wfrmRepuesto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="text-align: center;">
        <div class="row">
            <div class="col-sm-2"></div>
            <div class="col-sm-8">
                <h3>Repuesto
                </h3>
                <div class="mb-3" style="display: flex; align-items: center; justify-content: center;">
                    <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" placeholder="Código (Ej. ABC123456)" Style="margin-top: 1%; margin-bottom: 1%; width: 500px; max-width: 1500px" />
                </div>
                <div class="mb-3" style="display: flex; align-items: center; justify-content: center;">
                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" placeholder="Descripción" Style="margin-top: 1%; margin-bottom: 1%; width: 500px; max-width: 1500px" />
                </div>
                <div class="mb-3" style="display: flex; align-items: center; justify-content: center;">
                    <asp:TextBox ID="txtCosto" runat="server" CssClass="form-control" placeholder="Costo" Style="margin-top: 1%; margin-bottom: 1%; width: 500px; max-width: 1500px" />
                </div>
                <div class="mb-3" style="display: flex; align-items: center; justify-content: center;">
                    <asp:DropDownList ID="ddlTipo" runat="server" CssClass="form-control" Style="margin-top: 1%; margin-bottom: 1%; width: 1500px; max-width: 500px">
                        <asp:ListItem Text="Motor" Value="Motor" />
                        <asp:ListItem Text="Carrocería" Value="Carroceria" />
                        <asp:ListItem Text="Lubricación" Value="Lubricación" />
                        <asp:ListItem Text="Varios" Value="Varios" />
                    </asp:DropDownList>
                </div>
                <div class="mb-3" style="display: flex; align-items: center; justify-content: center;">
                    <asp:DropDownList ID="ddlProveedor" runat="server" CssClass="form-control" Style="margin-top: 1%; margin-bottom: 1%; width: 1500px; max-width: 500px" OnSelectedIndexChanged="ddlProveedor_SelectedIndexChanged" />
                </div>
                <div class="mb-8">
                    <asp:Button ID="btnAlta" runat="server" Text="Alta" CssClass="btn btn-default" OnClick="btnAlta_Click" />
                    &nbsp;<asp:Button ID="btnBaja" runat="server" Text="Baja" CssClass="btn btn-default" OnClick="btnBaja_Click" />
                    &nbsp;<asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-default" OnClick="btnModificar_Click" />
                    &nbsp;<asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn btn-default" OnClick="btnLimpiar_Click" />
                </div>

                <div>
                    <asp:RegularExpressionValidator ID="revCodigo" runat="server" ControlToValidate="txtCodigo"
                        ErrorMessage="Ingresa una cédula válida." ForeColor="Black" ValidationExpression="[A-Z]{3}[0-9]{6}" />
                </div>

                <p>
                    <asp:Label ID="lblMensajes" runat="server" />
                </p>
                <div class="mb-8" style="display: flex; align-items: center; justify-content: center;">
                    <asp:ListBox ID="lstRepuestos" runat="server" CssClass="form-control" OnSelectedIndexChanged="lstRepuestos_SelectedIndexChanged" AutoPostBack="True" Style="margin-top: 1%; margin-bottom: 1%; width: 600px; max-width: 1000px" />
                </div>
            </div>
            <div class="col-sm-2"></div>
        </div>
    </div>
</asp:Content>
