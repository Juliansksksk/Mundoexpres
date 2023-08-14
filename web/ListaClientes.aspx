<%@ Page Language="C#" AutoEventWireup="true" Async="true" CodeBehind="ListaClientes.aspx.cs" Inherits="Mundoexpres.web.ListaClientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Lista de Clientes</title>
</head>
<body>
    <form runat="server">

    <h1>Lista de Clientes</h1>
    <asp:GridView ID="GridViewClientes" runat="server" AutoGenerateColumns="False" OnRowEditing="GridViewClientes_RowEditing" OnRowUpdating="GridViewClientes_RowUpdating" OnRowCancelingEdit="GridViewClientes_RowCancelingEdit" OnRowDeleting="GridViewClientes_RowDeleting" DataKeyNames="clienteId">
    <Columns>
        <asp:BoundField DataField="ClienteId" HeaderText="ID" />
        <asp:TemplateField HeaderText="Nombre" SortExpression="Nombre">
            <ItemTemplate><%# Eval("Nombre") %></ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtEditNombre" runat="server" Text='<%# Bind("Nombre") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Email" SortExpression="Email">
            <ItemTemplate><%# Eval("Email") %></ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtEditEmail" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:CommandField ButtonType="Button" ShowEditButton="True" />
        <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
    </Columns>
</asp:GridView>

        </form>
    <div>
<asp:HyperLink ID="lnkCrearCliente" runat="server" NavigateUrl="CrearCliente.aspx" Text="Crear Nuevo Cliente" /><br />

    </div>

     <div>
           <asp:HyperLink ID="lnkClientes" runat="server" NavigateUrl='<%# ResolveUrl("~/web/CarpetaTP/TiposdeProducto.aspx") %>' Text="Ir a Tipos de Productos"></asp:HyperLink>

        </div>



</body>
</html>