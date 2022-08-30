<%@ Page Title="Formulario Administradores" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfrmAdministrador.aspx.cs" Inherits="Taller.Web.Paginas.wfrmAdministrador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="text-align: center">
        <div class="row">
            <div class="col-sm-2"></div>
            <div class="col-sm-8">
                <h3>Administrador
                </h3>
                <div class="mb-3" style="display: flex; align-items:center; justify-content:center;">
                    <asp:TextBox ID="txtId" runat="server" CssClass="form-control" placeholder="Ej. 1" Visible="False" Style="margin-top: 1%; margin-bottom: 1%; width: 1500px; max-width: 500px"/>
                </div>
                <div class="mb-3" style="display: flex; align-items:center; justify-content:center;">
        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Nombre" Style="margin-top: 1%; margin-bottom: 1%; width: 1500px; max-width: 500px"/>
                </div>
                <div class="mb-3" style="display: flex; align-items:center; justify-content:center;">
        <asp:TextBox ID="txtCedula" runat="server" CssClass="form-control" placeholder="Cédula (Ej. 1.234.567-8)" Style="margin-top: 1%; margin-bottom: 1%; width: 1500px; max-width: 500px"/>
                </div>
                <div class="mb-3" style="display: flex; align-items:center; justify-content:center;">
        <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" placeholder="Teléfono (Ej. 099123456 o 4586 1234)" Style="margin-top: 1%; margin-bottom: 1%; width: 1500px; max-width: 500px"/>
                </div>
                <div class="mb-3" style="display: flex; align-items:center; justify-content:center;">
        <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" placeholder="Dirección" Style="margin-top: 1%; margin-bottom: 1%; width: 1500px; max-width: 500px"/>
                </div>
                <div class="mb-3" style="display: flex; align-items:center; justify-content:center;">
        <asp:TextBox ID="txtMail" runat="server" CssClass="form-control" placeholder="Mail (ejemplo@gmail.com)" TextMode="Email" Style="margin-top: 1%; margin-bottom: 1%; width: 1500px; max-width: 500px"/>
                </div>
                <div class="mb-3" style="display: flex; align-items:center; justify-content:center;">
                    <asp:TextBox ID="dtpFechaRegistro" runat="server" CssClass="form-control" TextMode="Date" Visible="False" />
                </div>
                <div class="mb-3" style="display: flex; align-items:center; justify-content:center;">
        <asp:TextBox ID="txtContrasena" runat="server" CssClass="form-control" placeholder="Contraseña" TextMode="Password" Style="margin-top: 1%; margin-bottom: 1%; width: 1500px; max-width: 500px"/>
                </div>
                <div class="mb-8">
                    <asp:Button ID="btnAlta" runat="server" Text="Alta" CssClass="btn btn-default" OnClick="btnAlta_Click" />
                    &nbsp;<asp:Button ID="btnBaja" runat="server" Text="Baja" CssClass="btn btn-default" OnClick="btnBaja_Click" />
                    &nbsp;<asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-default" OnClick="btnModificar_Click" />
                    &nbsp;<asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn btn-default" OnClick="btnLimpiar_Click" />
                    <p>
                    <p>
                        <asp:Label ID="lblMensajes" runat="server" />
                    </p>
                    <div class="mb-8" style="display: flex; align-items:center; justify-content:center;">
                        <asp:ListBox ID="lstAdministradores" runat="server" CssClass="form-control" OnSelectedIndexChanged="lstAdministradores_SelectedIndexChanged" AutoPostBack="True" Style="margin-top: 1%; margin-bottom: 1%; width: 1500px; max-width: 1500px"/>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
