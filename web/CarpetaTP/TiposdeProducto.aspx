<%@ Page Language="C#" AutoEventWireup="true" Async="true" CodeBehind="TiposdeProducto.aspx.cs" Inherits="Mundoexpres.web.CarpetaTP.TiposdeProducto" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Tipos de Producto</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Tipos de Producto</h1>

        <asp:GridView ID="GridViewTiposProducto" runat="server" AutoGenerateColumns="False" OnRowEditing="GridViewTiposProducto_RowEditing" OnRowDeleting="GridViewTiposProducto_RowDeleting" OnRowUpdating="GridViewTiposProducto_RowUpdating" DataKeyNames="TipoProductoId">
            <Columns>
                <asp:BoundField DataField="TipoProductoId" HeaderText="ID" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>

        <asp:DetailsView ID="DetailsViewTipoProducto" runat="server" AutoGenerateRows="False" OnItemInserted="DetailsViewTipoProducto_ItemInserted" OnItemUpdated="DetailsViewTipoProducto_ItemUpdated"
    OnItemCanceling="DetailsViewTipoProducto_ItemCanceling"
    OnModeChanging="DetailsViewTipoProducto_ModeChanging">
            <Fields>
                <asp:BoundField DataField="TipoProductoId" HeaderText="ID" InsertVisible="False" ReadOnly="True" />
                <asp:TemplateField HeaderText="Nombre">
                    <ItemTemplate>
                        <asp:Label ID="lblNombre" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEditNombre" runat="server" Text='<%# Bind("Nombre") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Fields>
        </asp:DetailsView>

        <div>
            <h2>Crear Nuevo Tipo de Producto</h2>
            <asp:Label ID="lblNuevoNombre" runat="server" Text="Nombre:" AssociatedControlID="txtNuevoNombre"></asp:Label>
            <asp:TextBox ID="txtNuevoNombre" runat="server"></asp:TextBox>
            <asp:Button ID="btnCrear" runat="server" Text="Crear" OnClick="btnCrear_Click" />
        </div>

        <div>
            <asp:HyperLink ID="lnkClientes" runat="server" NavigateUrl='<%# ResolveUrl("~/web/ListaClientes.aspx") %>' Text="Ir a Clientes"></asp:HyperLink>

        </div>
    </form>
</body>
</html>