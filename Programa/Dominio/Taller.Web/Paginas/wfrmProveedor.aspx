<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfrmProveedor.aspx.cs" Inherits="Taller.Web.Paginas.wfrmProveedor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="text-align: center;">
        <div class="row">
            <div class="col-sm-2"></div>
            <div class="col-sm-8">
                <h3>Proveedores
                </h3>
                <div class="mb-3" style="display: flex; align-items: center; justify-content: center;">
                    <asp:TextBox ID="txtRUT" runat="server" CssClass="form-control" placeholder="RUT (Ej. 123456789123)" Style="margin-top: 1%; margin-bottom: 1%; width: 1500px; max-width: 500px" />
                </div>
                <div class="mb-3" style="display: flex; align-items: center; justify-content: center;">
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Nombre" Style="margin-top: 1%; margin-bottom: 1%; width: 1500px; max-width: 500px" />
                </div>
                <div class="mb-3" style="display: flex; align-items: center; justify-content: center;">
                    <asp:TextBox ID="txtMail" runat="server" CssClass="form-control" placeholder="Mail" Style="margin-top: 1%; margin-bottom: 1%; width: 1500px; max-width: 500px" TextMode="Email" />
                </div>
                <div class="mb-3" style="display: flex; align-items: center; justify-content: center;">
                    <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" placeholder="Teléfono (Ej. 099123456 o 4586 1234)" Style="margin-top: 1%; margin-bottom: 1%; width: 1500px; max-width: 500px" />
                </div>
                <p>
                    <asp:Label ID="lblMensajes" runat="server" />
                </p>
                <div class="mb-8" style="display: flex; align-items: center; justify-content: center;">
                    <asp:Button ID="btnAlta" runat="server" Text="Alta" CssClass="btn btn-default" OnClick="btnAlta_Click" />
                    <asp:Button ID="btnBaja" runat="server" Text="Eliminar" CssClass="btn btn-default" OnClick="btnBaja_Click" />
                    <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-default" OnClick="btnModificar_Click" />
                    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn btn-default" OnClick="btnLimpiar_Click" />
                </div>
                <div>
                    <asp:RegularExpressionValidator ID="revRUT" runat="server" ControlToValidate="txtRUT"
                        ErrorMessage="Ingresa un RUT válido." ForeColor="Black" ValidationExpression="[1-9]{1}[0-9]{11}" />
                </div>
                <div class="mb-8" style="display: flex; align-items: center; justify-content: center;">
                    <asp:ListBox ID="lstProveedores" runat="server" CssClass="form-control" AutoPostBack="True" Style="margin-top: 1%; margin-bottom: 1%; width: 600px; max-width: 1500px" Font-Size="Medium" OnSelectedIndexChanged="lstProveedores_SelectedIndexChanged" />
                </div>
            </div>
            <div class="col-sm-2"></div>
        </div>
    </div>
</asp:Content>
