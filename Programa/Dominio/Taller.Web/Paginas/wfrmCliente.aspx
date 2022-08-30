<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfrmCliente.aspx.cs" Inherits="Taller.Web.Paginas.wfrmCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="text-align: center;">
        <div class="row">
            <div class="col-sm-2"></div>
            <div class="col-sm-8">
                <h3>Clientes
                </h3>
                <div>
                    <asp:TextBox ID="txtId" runat="server" CssClass="form-control" placeholder="Ej. 1" Visible="False" />
                </div>
                <div class="mb-3" style="display: flex; align-items: center; justify-content: center;">
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Nombre" Style="margin-top: 1%; margin-bottom: 1%; width: 1500px; max-width: 500px" />
                </div>
                <div class="mb-3" style="display: flex; align-items: center; justify-content: center;">
                    <asp:TextBox ID="txtCedula" runat="server" CssClass="form-control" placeholder="Cédula (Ej. 1.234.567-8)" Style="margin-top: 1%; margin-bottom: 1%; width: 1500px; max-width: 500px" />
                </div>
                <div class="mb-3" style="display: flex; align-items: center; justify-content: center;">
                    <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" placeholder="Teléfono (Ej. 099123456)" Style="margin-top: 1%; margin-bottom: 1%; width: 1500px; max-width: 500px" />
                </div>
                <div class="mb-3" style="display: flex; align-items: center; justify-content: center;">
                    <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" placeholder="Dirección" Style="margin-top: 1%; margin-bottom: 1%; width: 1500px; max-width: 500px" />
                </div>
                <div class="mb-3" style="display: flex; align-items: center; justify-content: center;">
                    <asp:TextBox ID="txtMail" runat="server" CssClass="form-control" placeholder="Mail (ejemplo@gmail.com)" TextMode="Email" Style="margin-top: 1%; margin-bottom: 1%; width: 1500px; max-width: 500px" />
                </div>
                <div class="mb-3" style="display: flex; align-items: center; justify-content: center;">
                    <asp:TextBox ID="dtpFechaRegistro" runat="server" CssClass="form-control" TextMode="Date" Visible="False" />
                </div>
                <div class="mb-3" style="display: flex; align-items: center; justify-content: center;">
                    <asp:TextBox ID="txtContrasena" runat="server" CssClass="form-control" placeholder="Contraseña" TextMode="Password" Style="margin-top: 1%; margin-bottom: 1%; width: 1500px; max-width: 500px" />
                </div>
                <p>
                    <asp:Label ID="lblMensajes" runat="server" />
                </p>
                <div class="mb-8" style="display: flex; align-items: center; justify-content: center;">
                    <asp:Button ID="btnBaja" runat="server" Text="Eliminar" CssClass="btn btn-default" OnClick="btnBaja_Click" />
                    <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-default" OnClick="btnModificar_Click" />
                    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn btn-default" OnClick="btnLimpiar_Click" />
                </div>
                <div class="mb-8" style="display: flex; align-items: center; justify-content: center;">
                    <asp:ListBox ID="lstClientes" runat="server" CssClass="form-control" OnSelectedIndexChanged="lstClientes_SelectedIndexChanged" AutoPostBack="True" Style="margin-top: 1%; margin-bottom: 1%; width: 600px; max-width: 1500px" Font-Size="Medium" />
                </div>
                <div class="mb-3">
                    <asp:Button ID="btnAdmin" runat="server" Text="Hacer administrador" CssClass="btn btn-default" OnClick="btnAdmin_Click" />
                </div>
            </div>
            <div class="col-sm-2"></div>
        </div>
    </div>
</asp:Content>
