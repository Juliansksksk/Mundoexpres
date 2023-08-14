<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnviosTerrestres.aspx.cs" Inherits="Mundoexpres.EnviosTerrestres" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Envíos Terrestres</title>
    <style>
        /* Estilos aquí */
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Envíos Terrestres</h1>
            <div class="message">
                <asp:Literal ID="ltMessage" runat="server"></asp:Literal>
            </div>

            <h2>Registrar Nuevo Envío Terrestre</h2>
            <div>
                <label for="tipoProducto">Tipo de Producto:</label>
                <select id="tipoProducto" runat="server">
                    <!-- Aquí podrías cargar los tipos de producto desde la base de datos -->
                </select>
            </div>
            <div>
                <label for="cantidad">Cantidad:</label>
                <input type="number" id="cantidad" runat="server" />
            </div>
            <div>
                <label for="fechaEntrega">Fecha de Entrega:</label>
                <input type="date" id="fechaEntrega" runat="server" />
            </div>
            <div>
                <label for="bodegaEntrega">Bodega de Entrega:</label>
                <select id="bodegaEntrega" runat="server">
                    <!-- Aquí podrías cargar las bodegas desde la base de datos -->
                </select>
            </div>
            <div>
                <label for="precioEnvio">Precio de Envío:</label>
                <input type="number" id="precioEnvio" runat="server" step="0.01" />
            </div>
            <div>
                <label for="placaVehiculo">Placa del Vehículo:</label>
                <input type="text" id="placaVehiculo" runat="server" />
            </div>
            <div>
                <label for="numeroGuia">Número de Guía:</label>
                <input type="text" id="numeroGuia" runat="server" />
            </div>
            <div>
                <asp:Button ID="btnRegistrarEnvio" runat="server" Text="Registrar Envío" OnClick="btnRegistrarEnvio_Click" />
            </div>
        </div>
    </form>
</body>
</html>