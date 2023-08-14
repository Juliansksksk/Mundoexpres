<%@ Page Language="C#" AutoEventWireup="true" Async="true" CodeBehind="CrearCliente.aspx.cs" Inherits="Mundoexpres.web.CrearCliente" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Crear Cliente</title>
</head>
<body>
    <h1>Crear Cliente</h1>
    <form id="form1" runat="server">
        <div>
            <label for="txtNombre">Nombre:</label>
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            <br />
            <label for="txtEmail">Email:</label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnCrear" runat="server" Text="Crear Cliente" OnClick="btnCrear_Click" />
        </div>
        <div>

                    
                  
          
                                <asp:HyperLink ID="lnkVolverListar" runat="server" NavigateUrl="ListaClientes.aspx" Text="Volver a Listar Clientes" /><br />
        </div>


    </form>
</body>
</html>