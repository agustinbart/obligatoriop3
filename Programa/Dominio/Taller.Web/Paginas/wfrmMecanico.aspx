<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfrmMecanico.aspx.cs" Inherits="Taller.Web.Paginas.wfrmMecanico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="text-align: center;">
        <div class="row">
            <div class="col-sm-2"></div>
            <div class="col-sm-8">
                <h3>Mecánicos
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
                    <asp:TextBox ID="dtpFechaIngreso" runat="server" CssClass="form-control" TextMode="Date" Style="margin-top: 1%; margin-bottom: 1%; width: 1500px; max-width: 500px" />
                </div>
                <div class="mb-3" style="display: flex; align-items: center; justify-content: center;">
                    <asp:TextBox ID="txtValorHora" runat="server" CssClass="form-control" placeholder="Valor hora" Style="margin-top: 1%; margin-bottom: 1%; width: 1500px; max-width: 500px" />
                </div>
                <div class="mb-3" style="display: flex; align-items: center; justify-content: center;">
                    <p style="margin-right: 50px; font-size: 20px; margin-top: 10px">Activo: </p>
                    <asp:DropDownList ID="ddlActivo" runat="server" CssClass="form-control">
                        <asp:ListItem Text="Si" Value="S" />
                        <asp:ListItem Text="No" Value="N" />
                    </asp:DropDownList>
                </div>

                <div>
                    <asp:RegularExpressionValidator ID="revCedula" runat="server" ControlToValidate="txtCedula"
                        ErrorMessage="Ingresa una cédula válida." ForeColor="Black" ValidationExpression="[1-9].[0-9]{3}.[0-9]{3}-[0-9]{1}" />
                </div>

                <p>
                    <asp:Label ID="lblMensajes" runat="server" />
                </p>
                <div class="mb-8" style="display: flex; align-items: center; justify-content: center;">
                    <asp:Button ID="btnAlta" runat="server" Text="Alta" CssClass="btn btn-default" OnClick="btnAlta_Click" />
                    <asp:Button ID="btnBaja" runat="server" Text="Baja" CssClass="btn btn-default" OnClick="btnBaja_Click" />
                    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn btn-default" OnClick="btnLimpiar_Click" />
                </div>
                <div class="mb-8" style="display: flex; align-items: center; justify-content: center;">
                    <asp:ListBox ID="lstMecanicos" runat="server" CssClass="form-control" AutoPostBack="True" Style="margin-top: 1%; margin-bottom: 1%; width: 600px; max-width: 1500px" Font-Size="Medium" OnSelectedIndexChanged="lstMecanicos_SelectedIndexChanged" />
                </div>
            </div>
            <div class="col-sm-2"></div>
        </div>
    </div>
</asp:Content>
