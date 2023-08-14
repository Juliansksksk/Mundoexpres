<%@ Page Language="C#" AutoEventWireup="true" Async="true" CodeBehind="CrearCliente.aspx.cs" Inherits="Mundoexpres.web.CrearCliente" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Crear Cliente</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-4bw+/aepP/YC94hEpVNVgiZdgIC5+VKNBQNGCHeKRQN+PtmoHDEXuppvnDJzQIu9" crossorigin="anonymous">
</head>
<body class="container mt-5">
    <h1>Crear Cliente</h1>
    <form id="form1" runat="server">
        <div class="mb-3">
            <label for="txtNombre" class="form-label">Nombre:</label>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label for="txtEmail" class="form-label">Email:</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <asp:Button ID="btnCrear" runat="server" Text="Crear Cliente" OnClick="btnCrear_Click" CssClass="btn btn-primary" />

        <div class="mt-3">
            <asp:HyperLink ID="lnkVolverListar" runat="server" NavigateUrl="ListaClientes.aspx" Text="Volver a Listar Clientes" CssClass="btn btn-secondary" /><br />
        </div>
    </form>
</body>
</html>
