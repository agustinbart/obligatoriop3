<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfrmLogin.aspx.cs" Inherits="Taller.Web.Paginas.wfrmLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container" style="text-align: center;">
        <div class="row">
            <div class="col-sm-2"></div>

            <div class="col-sm-8">
                <h3>Login
                </h3>
                <div class="mb-3" style="display: flex; align-items: center; justify-content: center;">
                    <asp:TextBox ID="txtCedula" runat="server" CssClass="form-control" placeholder="Cédula (Ej. 1.234.567-8)" Style="margin-top: 1%; margin-bottom: 1%; width: 1500px; max-width: 500px" />
                </div>
                <div class="mb-3" style="display: flex; align-items: center; justify-content: center;">
                    <asp:TextBox ID="txtContrasena" runat="server" CssClass="form-control" placeholder="Contraseña" Style="margin-top: 1%; margin-bottom: 1%; width: 1500px; max-width: 500px" TextMode="Password" />
                </div>
                <p>
                    <asp:Label ID="lblMensajes" runat="server" />
                </p>
                <div class="mb-8">
                    <asp:Button ID="btnLogin" runat="server" Text="Iniciar Sesión" CssClass="btn btn-default" OnClick="btnLogin_Click" />
                </div>
                <br />
                <div class="mb-8">
                    <p>No estás registrado? <a runat="server" href="~/Paginas/wfrmRegistro">Registrate aquí</a></p>
                    <p>Tienes cuenta de administrador? <a runat="server" href="~/Paginas/wfrmLoginAdmin">Ingresa aquí</a></p>
                </div>

                
                <asp:RegularExpressionValidator ID="revCedula" runat="server" ControlToValidate="txtCedula"
                    ErrorMessage="Ingresa una cédula válida." ForeColor="Black" ValidationExpression="[1-9].[0-9]{3}.[0-9]{3}-[0-9]{1}" />
            </div>

            <div class="col-sm-2"></div>
        </div>
    </div>

</asp:Content>
