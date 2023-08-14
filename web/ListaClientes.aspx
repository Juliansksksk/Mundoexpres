<%@ Page Language="C#" AutoEventWireup="true" Async="true" CodeBehind="ListaClientes.aspx.cs" Inherits="Mundoexpres.web.ListaClientes" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Lista de Clientes</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-4bw+/aepP/YC94hEpVNVgiZdgIC5+VKNBQNGCHeKRQN+PtmoHDEXuppvnDJzQIu9" crossorigin="anonymous">
</head>
<body>
    <form runat="server" class="container mt-5">

        <h1>Lista de Clientes</h1>

        <div class="mb-4">
            <asp:GridView ID="GridViewClientes" runat="server" AutoGenerateColumns="False" OnRowEditing="GridViewClientes_RowEditing" OnRowUpdating="GridViewClientes_RowUpdating" OnRowCancelingEdit="GridViewClientes_RowCancelingEdit" OnRowDeleting="GridViewClientes_RowDeleting" DataKeyNames="clienteId">
                <Columns>
                    <asp:BoundField DataField="ClienteId" HeaderText="ID" />
                    <asp:TemplateField HeaderText="Nombre" SortExpression="Nombre">
                        <ItemTemplate><%# Eval("Nombre") %></ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEditNombre" runat="server" Text='<%# Bind("Nombre") %>' CssClass="form-control"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email" SortExpression="Email">
                        <ItemTemplate><%# Eval("Email") %></ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEditEmail" runat="server" Text='<%# Bind("Email") %>' CssClass="form-control"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ButtonType="Button" ShowEditButton="True" ControlStyle-CssClass="btn btn-sm btn-outline-primary" />
                    <asp:CommandField ButtonType="Button" ShowDeleteButton="True" ControlStyle-CssClass="btn btn-sm btn-outline-danger" />
                </Columns>
            </asp:GridView>
        </div>

        <div class="mb-4">
            <asp:HyperLink ID="lnkCrearCliente" runat="server" NavigateUrl="CrearCliente.aspx" Text="Crear Nuevo Cliente" CssClass="btn btn-primary"></asp:HyperLink>
        </div>

        <div class="mb-4">
            <asp:HyperLink ID="lnkTiposProducto" runat="server" NavigateUrl='<%# ResolveUrl("~/web/CarpetaTP/TiposdeProducto.aspx") %>' Text="Ir a Tipos de Productos" CssClass="btn btn-secondary"></asp:HyperLink>
        </div>

        <div>
            <asp:HyperLink ID="lnkEnvios" runat="server" NavigateUrl='<%# ResolveUrl("~/web/Envios/EnviosTerrestres.aspx") %>' Text="Hacer un Envío" CssClass="btn btn-secondary"></asp:HyperLink>
        </div>

    </form>
</body>
</html>
