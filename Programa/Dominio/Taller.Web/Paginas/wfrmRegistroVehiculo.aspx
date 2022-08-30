<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfrmRegistroVehiculo.aspx.cs" Inherits="Taller.Web.Paginas.wfrmRegistroVehiculo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="text-align: center;">
        <div class="row">
            <div class="col-sm-2"></div>
            <div class="col-sm-8">
                <h3>Registro de Vehículo
                </h3>
                <div class="mb-3" style="display: flex; align-items: center; justify-content: center;">
                    <asp:TextBox ID="txtId" runat="server" CssClass="form-control" placeholder="Ej. 1" Visible="False" Style="margin-top: 1%; margin-bottom: 1%; width: 1500px; max-width: 500px" />
                </div>
                <div class="mb-3" style="display: flex; align-items: center; justify-content: center;">
                    <asp:TextBox ID="txtIdCliente" runat="server" CssClass="form-control" placeholder="Id Cliente" Visible="False" />
                </div>
                <div class="mb-3" style="display: flex; align-items: center; justify-content: center;">
                    <asp:TextBox ID="txtMatricula" runat="server" CssClass="form-control" placeholder="Matricula (Ej. ABC1234)" Style="margin-top: 1%; margin-bottom: 1%; width: 1500px; max-width: 500px" />
                </div>
                <div class="mb-3" style="display: flex; align-items: center; justify-content: center;">
                    <asp:TextBox ID="txtMarca" runat="server" CssClass="form-control" placeholder="Marca" Style="margin-top: 1%; margin-bottom: 1%; width: 1500px; max-width: 500px" />
                </div>
                <div class="mb-3" style="display: flex; align-items: center; justify-content: center;">
                    <asp:TextBox ID="txtModelo" runat="server" CssClass="form-control" placeholder="Modelo" Style="margin-top: 1%; margin-bottom: 1%; width: 1500px; max-width: 500px" />
                </div>
                <div class="mb-3" style="display: flex; align-items: center; justify-content: center;">
                    <asp:TextBox ID="txtAnio" runat="server" CssClass="form-control" placeholder="Año" Style="margin-top: 1%; margin-bottom: 1%; width: 1500px; max-width: 500px" />
                </div>
                <div class="mb-3" style="display: flex; align-items: center; justify-content: center;">
                    <asp:TextBox ID="txtColor" runat="server" CssClass="form-control" placeholder="Color" Style="margin-top: 1%; margin-bottom: 1%; width: 500px; max-width: 500px" />
                </div>
                <div class="mb-3" style="display: flex; align-items: center; justify-content: center;">
                    <asp:Label ID="lblMensajes" runat="server" />
                </div>

                <div>
                    <asp:RegularExpressionValidator ID="revMatricula" runat="server" ControlToValidate="txtMatricula"
                        ErrorMessage="Ingresa una matrícula válida." ForeColor="Black" ValidationExpression="[A-Z]{3}[0-9]{4}" />
                </div>

                <div class="mb-3">
                    <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="btn btn-default" OnClick="btnRegistrar_Click" />
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-default" OnClick="btnEliminar_Click" />
                </div>
                <br />
                <p style="text-align: center">Tus vehículos</p>
                <div class="mb-8" style="display: flex; align-items: center; justify-content: center;">
                    <asp:ListBox ID="lstVehiculos" runat="server" CssClass="form-control" AutoPostBack="True" Style="margin-top: 1%; margin-bottom: 1%; width: 500px; max-width: 1500px" OnSelectedIndexChanged="lstVehiculos_SelectedIndexChanged" />
                </div>
            </div>
            <div class="col-sm-2"></div>
        </div>
    </div>
</asp:Content>
