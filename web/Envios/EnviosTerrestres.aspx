<%@ Page Language="C#" AutoEventWireup="true" Async="true" CodeBehind="EnviosTerrestres.aspx.cs" Inherits="Mundoexpres.web.Envios.EnviosTerrestres" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Envíos Terrestres</title>

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-4bw+/aepP/YC94hEpVNVgiZdgIC5+VKNBQNGCHeKRQN+PtmoHDEXuppvnDJzQIu9" crossorigin="anonymous">
    <script>
        function showCalendar(calendarId) {
            var calendar = $find(calendarId);
            calendar._popupBehavior.show();
        }

        function hideCalendar(calendarId) {
            var calendar = $find(calendarId);
            calendar._popupBehavior.hide();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server" class="container mt-5">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <h1 class="mb-4">Envíos Terrestres</h1>

        <!-- Crear Envío Terrestre -->
        <div class="mb-4">
            <h2>Crear Envío Terrestre</h2>
            <div class="row">
                <div class="col-md-6">
                    <label for="ddlprod" class="form-label">Tipo de Producto Id:</label>
                    <asp:DropDownList ID="ddlprod" runat="server" CssClass="form-select"></asp:DropDownList><br />
                    
                    <label for="ddlClientes" class="form-label">Cliente:</label>
                    <asp:DropDownList ID="ddlClientes" runat="server" CssClass="form-select"></asp:DropDownList><br />
                    
                    <label for="TxtCantidad" class="form-label">Cantidad:</label>
                    <asp:TextBox ID="TxtCantidad" runat="server" CssClass="form-control"></asp:TextBox><br />

                    <label for="txtFechaRegistro" class="form-label">Fecha de Registro:</label>
                    <asp:TextBox ID="txtFechaRegistro" runat="server" onmouseover="showCalendar('calFechaRegistro')" CssClass="form-control"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="calFechaRegistro" runat="server" TargetControlID="txtFechaRegistro"></ajaxToolkit:CalendarExtender><br />

                    <label for="txtFechaEntrega" class="form-label">Fecha de Entrega:</label>
                    <asp:TextBox ID="txtFechaEntrega" runat="server" onmouseover="showCalendar('calFechaEntrega')" CssClass="form-control"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="calFechaEntrega" runat="server" TargetControlID="txtFechaEntrega"></ajaxToolkit:CalendarExtender><br />
                    
                    <label for="ddlBodegaEntregaId" class="form-label">Bodega Entrega Id:</label>
                    <asp:DropDownList ID="ddlBodegaEntregaId" runat="server" OnSelectedIndexChanged="ddlBodegaEntregaId_SelectedIndexChanged" CssClass="form-select"></asp:DropDownList><br />
                    
                    <label for="txtPrecioEnvio" class="form-label">Precio de Envío:</label>
                    <asp:TextBox ID="txtPrecioEnvio" runat="server" CssClass="form-control"></asp:TextBox><br />
                    
                    <label for="txtPlacaVehiculo" class="form-label">Placa del Vehículo:</label>
                    <asp:TextBox ID="txtPlacaVehiculo" runat="server" CssClass="form-control"></asp:TextBox><br />
                    
                    <label for="txtNumeroGuia" class="form-label">Número de Guía:</label>
                    <asp:TextBox ID="txtNumeroGuia" runat="server" CssClass="form-control"></asp:TextBox><br />

                    <asp:Button ID="btnCrear" runat="server" Text="Crear Envío" OnClick="btnCrear_Click" CssClass="btn btn-primary"></asp:Button>
                </div>
            </div>
        </div>

        <!-- Mostrar errores -->
        <div>
            <asp:Label ID="lblError" runat="server" CssClass="error-message d-none"></asp:Label>
        </div>

        <!-- Lista de Envíos Terrestres -->
        <h2>Lista de Envíos Terrestres</h2>
        <asp:GridView ID="GridViewEnviosTerrestres" runat="server" AutoGenerateColumns="False" OnRowEditing="GridViewEnviosTerrestres_RowEditing" OnRowDeleting="GridViewEnviosTerrestres_RowDeleting" OnRowUpdating="GridViewEnviosTerrestres_RowUpdating" DataKeyNames="EnvioTerrestreId" CssClass="table">
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

    <div>   

           <div>
            <asp:HyperLink ID="lnkClientes" runat="server" NavigateUrl='<%# ResolveUrl("~/web/ListaClientes.aspx") %>' Text="Ir a Clientes"></asp:HyperLink>

        </div>

    </div>

</body>
</html>
