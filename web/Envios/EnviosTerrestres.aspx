<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnviosTerrestres.aspx.cs" Inherits="Mundoexpres.web.Envios.EnviosTerrestres" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Envíos Terrestres</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Envíos Terrestres</h1>

        <div>
<h2>Crear Envío Terrestre</h2>
<asp:Label ID="lblTipoProductoId" runat="server" Text="Tipo de Producto Id:"></asp:Label>
<asp:DropDownList ID="ddlprod" runat="server"></asp:DropDownList><br />

<asp:Label ID="lblClienteId" runat="server" Text="Cliente:"></asp:Label>
<asp:DropDownList ID="ddlClientes" runat="server"></asp:DropDownList><br />

<asp:Label ID="lblCantidad" runat="server" Text="Cantidad:"></asp:Label>
<asp:TextBox ID="TxtCantidad" runat="server"></asp:TextBox>

<asp:Label ID="lblFechaRegistro" runat="server" Text="Fecha de Registro:"></asp:Label>
<asp:TextBox ID="txtFechaRegistro" runat="server"></asp:TextBox>
<asp:CalendarExtender ID="calFechaRegistro" runat="server" TargetControlID="txtFechaRegistro"></asp:CalendarExtender><br />

<asp:Label ID="lblFechaEntrega" runat="server" Text="Fecha de Entrega:"></asp:Label>
<asp:TextBox ID="txtFechaEntrega" runat="server"></asp:TextBox>
<asp:CalendarExtender ID="calFechaEntrega" runat="server" TargetControlID="txtFechaEntrega"></asp:CalendarExtender><br />
            <asp:Label ID="lblBodegaEntregaId" runat="server" Text="Bodega Entrega Id:"></asp:Label>
            <asp:TextBox ID="txtBodegaEntregaId" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblPrecioEnvio" runat="server" Text="Precio de Envío:"></asp:Label>
            <asp:TextBox ID="txtPrecioEnvio" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblPlacaVehiculo" runat="server" Text="Placa del Vehículo:"></asp:Label>
            <asp:TextBox ID="txtPlacaVehiculo" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblNumeroGuia" runat="server" Text="Número de Guía:"></asp:Label>
            <asp:TextBox ID="txtNumeroGuia" runat="server"></asp:TextBox><br />
            <asp:Button ID="btnCrear" runat="server" Text="Crear Envío" OnClick="btnCrear_Click" />
        </div>

        <h2>Lista de Envíos Terrestres</h2>
        <asp:GridView ID="GridViewEnviosTerrestres" runat="server" AutoGenerateColumns="False"
            OnRowEditing="GridViewEnviosTerrestres_RowEditing" OnRowUpdating="GridViewEnviosTerrestres_RowUpdating"
            OnRowCancelingEdit="GridViewEnviosTerrestres_RowCancelingEdit" OnRowDeleting="GridViewEnviosTerrestres_RowDeleting"
            DataKeyNames="EnvioTerrestreId">
            <Columns>
                <asp:BoundField DataField="EnvioTerrestreId" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="TipoProductoId" HeaderText="Tipo de Producto Id" />
                <asp:BoundField DataField="ClienteId" HeaderText="Cliente Id" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                <asp:BoundField DataField="FechaRegistro" HeaderText="Fecha de Registro" />
                <asp:BoundField DataField="FechaEntrega" HeaderText="Fecha de Entrega" />
                <asp:BoundField DataField="BodegaEntregaId" HeaderText="Bodega Entrega Id" />
                <asp:BoundField DataField="PrecioEnvio" HeaderText="Precio de Envío" />
                <asp:BoundField DataField="PlacaVehiculo" HeaderText="Placa del Vehículo" />
                <asp:BoundField DataField="NumeroGuia" HeaderText="Número de Guía" />
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>

    </form>
</body>
</html>