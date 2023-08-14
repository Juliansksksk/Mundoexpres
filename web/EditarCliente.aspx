<%@ Page Language="C#" AutoEventWireup="true" Async="true" CodeBehind="EditarCliente.aspx.cs" Inherits="Mundoexpres.web.EditarCliente" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Editar Cliente</title>
</head>
<body>
    <h1>Editar Cliente</h1>
    <form id="form1" runat="server">
        <div>
            <label for="txtNombre">Nombre:</label>
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            <br />
            <label for="txtCorreo">Correo:</label>
            <asp:TextBox ID="txtCorreo" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnActualizar" runat="server" Text="Actualizar Cliente" OnClick="btnActualizar_Click" />
        </div>


        <div>

       
        <asp:HyperLink ID="lnkCrearCliente" runat="server" NavigateUrl="CrearCliente.aspx" Text="Crear Nuevo Cliente" /><br />
        <asp:HyperLink ID="lnkVolverListar" runat="server" NavigateUrl="ListarClientes.aspx" Text="Volver a Listar Clientes" /><br />

        </div>



    </form>
</body>
</html>