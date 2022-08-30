<%@ Page Title="Registro" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfrmRegistro.aspx.cs" Inherits="Taller.Web.Paginas.wfrmRegistro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container" style="text-align: center;">
        <div class="row">
            <div class="col-sm-2"></div>
            <div class="col-sm-8">
                <h3>Registro
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
                <div class="mb-8">
                    <asp:Button ID="btnRegistrar" runat="server" Text="Registrarse" CssClass="btn btn-default" OnClick="btnRegistrar_Click" />
                </div>
                <br />
                <div class="mb-8">
                    <p>Ya estás registrado? <a runat="server" href="~/Paginas/wfrmLogin">Ingresa aquí</a></p>
                </div>

                <div>
                    <asp:RegularExpressionValidator ID="revCedula" runat="server" ControlToValidate="txtCedula"
                        ErrorMessage="Ingresa una cédula válida." ForeColor="Black" ValidationExpression="[1-9].[0-9]{3}.[0-9]{3}-[0-9]{1}" />
                </div>

                <div>
                    <asp:RegularExpressionValidator ID="revTelefono" runat="server" ControlToValidate="txtTelefono"
                        ErrorMessage="Ingresa un telefono válido." ForeColor="Black" ValidationExpression="[0]{1}[1-9]{2}[0-9]{6}" />
                </div>
            </div>
            <div class="col-sm-2"></div>
        </div>
    </div>

</asp:Content>
