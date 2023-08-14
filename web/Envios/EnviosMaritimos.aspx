<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnviosMaritimos.aspx.cs" Inherits="Mundoexpres.web.Envios.EnviosMaritimos" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Envíos Marítimos</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Envíos Marítimos</h1>

        <div>
            <h2>Crear Envío Marítimo</h2>
            <asp:Label ID="lblTipoProductoId" runat="server" Text="Tipo de Producto Id:"></asp:Label>
            <asp:TextBox ID="txtTipoProductoId" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblClienteId" runat="server" Text="Cliente Id:"></asp:Label>
            <asp:TextBox ID="txtClienteId" runat="server"></asp:TextBox><br />
            <!-- Agrega más campos aquí según tu modelo -->
            <asp:Button ID="btnCrear" runat="server" Text="Crear Envío" OnClick="btnCrear_Click" />
        </div>

        <h2>Lista de Envíos Marítimos</h2>
        <asp:GridView ID="GridViewEnviosMaritimos" runat="server" AutoGenerateColumns="False"
            OnRowEditing="GridViewEnviosMaritimos_RowEditing" OnRowUpdating="GridViewEnviosMaritimos_RowUpdating"
            OnRowCancelingEdit="GridViewEnviosMaritimos_RowCancelingEdit" OnRowDeleting="GridViewEnviosMaritimos_RowDeleting"
            DataKeyNames="EnvioMaritimoId">
            <Columns>
                <asp:BoundField DataField="EnvioMaritimoId" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="TipoProductoId" HeaderText="Tipo de Producto Id" />
                <asp:BoundField DataField="ClienteId" HeaderText="Cliente Id" />
                <!-- Agrega más columnas aquí según tu modelo -->
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>

    </form>
</body>
</html>