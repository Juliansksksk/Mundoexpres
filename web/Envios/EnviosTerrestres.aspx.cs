using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Api.Models;
using Mundoexpres.web.CarpetaTP;

namespace Mundoexpres.web.Envios
{
    public partial class EnviosTerrestres : System.Web.UI.Page
    {
        private string apiBaseUrl = "https://localhost:44318/"; // Reemplazar con la URL real del API

        protected async void Page_Load(object sender, EventArgs e)
        {
            lnkClientes.NavigateUrl = ResolveUrl("~/web/ListaClientes.aspx");

            if (!IsPostBack)
            {
                await CargarClientes();
                await CargarTiposDeProducto();
                await CargarEnviosTerrestres();
                await CargarBodegasEntrega();
            }
        }

        private async Task CargarClientes()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseUrl);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/Clientes");
                if (response.IsSuccessStatusCode)
                {
                    var clientes = await response.Content.ReadAsAsync<Cliente[]>();
                    ddlClientes.DataSource = clientes;
                    ddlClientes.DataTextField = "Nombre"; // Cambiar por la propiedad del cliente que desees mostrar
                    ddlClientes.DataValueField = "ClienteId";
                    ddlClientes.DataBind();

                    ddlClientes.Items.Insert(0, new ListItem("Selecciona el cliente", "-1"));
                }
            }
        }

        private async Task CargarEnviosTerrestres()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseUrl);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/EnviosTerrestres");
                if (response.IsSuccessStatusCode)
                {
                    var enviosTerrestres = await response.Content.ReadAsAsync<EnvioTerrestre[]>();
                    GridViewEnviosTerrestres.DataSource = enviosTerrestres;
                    GridViewEnviosTerrestres.DataBind();
                }
            }
        }

        private void LimpiarCampos()
        {
            ddlprod.SelectedIndex = -1; // Limpiar selección de tipo de producto
            ddlClientes.SelectedIndex = -1; // Limpiar selección de cliente
            TxtCantidad.Text = string.Empty;
            txtFechaRegistro.Text = string.Empty;
            txtFechaEntrega.Text = string.Empty;
            ddlBodegaEntregaId.SelectedIndex = -1; // Limpiar selección de bodega de entrega
            txtPrecioEnvio.Text = string.Empty;
            txtPlacaVehiculo.Text = string.Empty;
            txtNumeroGuia.Text = string.Empty;
        }

        protected async void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                // Recuperar datos de los campos en la página
                int tipoProductoId = Convert.ToInt32(ddlprod.SelectedValue);
                int clienteId = Convert.ToInt32(ddlClientes.SelectedValue);
                int cantidad = Convert.ToInt32(TxtCantidad.Text);

                DateTime? fechaRegistro = null;
                DateTime? fechaEntrega = null;

                if (DateTime.TryParse(txtFechaRegistro.Text, out DateTime parsedFechaRegistro))
                {
                    fechaRegistro = parsedFechaRegistro;
                }
                else
                {
                    // Mostrar mensaje de error al usuario
                    MostrarMensajeError("La fecha de registro ingresada no es válida.");
                    return;
                }

                if (DateTime.TryParse(txtFechaEntrega.Text, out DateTime parsedFechaEntrega))
                {
                    fechaEntrega = parsedFechaEntrega;
                }
                else
                {
                    // Mostrar mensaje de error al usuario
                    MostrarMensajeError("La fecha de entrega ingresada no es válida.");
                    return;
                }

                int bodegaEntregaId = Convert.ToInt32(ddlBodegaEntregaId.SelectedValue);
                decimal precioEnvio = Convert.ToDecimal(txtPrecioEnvio.Text);
                string placaVehiculo = txtPlacaVehiculo.Text;
                string numeroGuia = txtNumeroGuia.Text;

                // Crear objeto EnvioTerrestre
                EnvioTerrestre nuevoEnvioTerrestre = new EnvioTerrestre
                {
                    TipoProductoId = tipoProductoId,
                    ClienteId = clienteId,
                    Cantidad = cantidad,
                    FechaRegistro = parsedFechaRegistro,
                    FechaEntrega = parsedFechaEntrega,
                    BodegaEntregaId = bodegaEntregaId,
                    PrecioEnvio = precioEnvio,
                    PlacaVehiculo = placaVehiculo,
                    NumeroGuia = numeroGuia
                };

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiBaseUrl);
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.PostAsJsonAsync("api/EnviosTerrestres", nuevoEnvioTerrestre);
                    if (response.IsSuccessStatusCode)
                    {
                        await CargarEnviosTerrestres();
                        LimpiarCampos();
                    }
                    else
                    {
                        // Mostrar mensaje de error al usuario
                        MostrarMensajeError("Error al crear el envío terrestre. Por favor, inténtalo de nuevo más tarde.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción de manera adecuada (por ejemplo, mostrar un mensaje al usuario o registrar el error)
                MostrarMensajeError("Ocurrió un error en el proceso. Por favor, inténtalo de nuevo más tarde.");
            }
        }

        private void MostrarMensajeError(string mensaje)
        {
            lblError.Text = mensaje;
            lblError.Visible = true;
        }



        protected async void GridViewEnviosTerrestres_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewEnviosTerrestres.EditIndex = e.NewEditIndex;
            await CargarEnviosTerrestres();
        }

        protected void ddlBodegaEntregaId_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Aquí puedes obtener el valor seleccionado del DropDownList
            int bodegaEntregaId = Convert.ToInt32(ddlBodegaEntregaId.SelectedValue);

            // Puedes realizar acciones adicionales con el valor seleccionado si es necesario
        }

        protected async void GridViewEnviosTerrestres_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridViewEnviosTerrestres.Rows[e.RowIndex];
            int envioTerrestreId = Convert.ToInt32(GridViewEnviosTerrestres.DataKeys[e.RowIndex].Value);

            // Encuentra los controles de edición dentro de la fila
            TextBox txtTipoProductoId = (TextBox)row.FindControl("ddlprod");
            TextBox txtClienteId = (TextBox)row.FindControl("ddlClientes");
            TextBox txtCantidad = (TextBox)row.FindControl("TxtCantidad");
            TextBox txtFechaRegistro = (TextBox)row.FindControl("txtFechaRegistro");
            TextBox txtFechaEntrega = (TextBox)row.FindControl("txtFechaEntrega");
            DropDownList ddlBodegaEntregaId = (DropDownList)row.FindControl("ddlBodegaEntregaId");
            TextBox txtPrecioEnvio = (TextBox)row.FindControl("txtPrecioEnvio");
            TextBox txtPlacaVehiculo = (TextBox)row.FindControl("txtPlacaVehiculo");
            TextBox txtNumeroGuia = (TextBox)row.FindControl("txtNumeroGuia");

            // Realiza la validación y conversión de cada TextBox
            int tipoProductoId;
            if (!int.TryParse(txtTipoProductoId.Text, out tipoProductoId))
            {
                // Mostrar mensaje de error y salir del evento
                return;
            }

            int clienteId;
            if (!int.TryParse(txtClienteId.Text, out clienteId))
            {
                // Mostrar mensaje de error y salir del evento
                return;
            }

            int cantidad;
            if (!int.TryParse(txtCantidad.Text, out cantidad))
            {
                // Mostrar mensaje de error y salir del evento
                return;
            }

            DateTime fechaRegistro;
            if (!DateTime.TryParse(txtFechaRegistro.Text, out fechaRegistro))
            {
                // Mostrar mensaje de error y salir del evento
                return;
            }

            DateTime fechaEntrega;
            if (!DateTime.TryParse(txtFechaEntrega.Text, out fechaEntrega))
            {
                // Mostrar mensaje de error y salir del evento
                return;
            }

            int bodegaEntregaId;
            if (!int.TryParse(ddlBodegaEntregaId.Text, out bodegaEntregaId))
            {
                // Mostrar mensaje de error y salir del evento
                return;
            }

            decimal precioEnvio;
            if (!decimal.TryParse(txtPrecioEnvio.Text, out precioEnvio))
            {
                // Mostrar mensaje de error y salir del evento
                return;
            }

            string placaVehiculo = txtPlacaVehiculo.Text;
            string numeroGuia = txtNumeroGuia.Text;

            // Construir el objeto EnvioTerrestre con los valores validados
            EnvioTerrestre envioTerrestreActualizado = new EnvioTerrestre
            {
                EnvioTerrestreId = envioTerrestreId,
                TipoProductoId = tipoProductoId,
                ClienteId = clienteId,
                Cantidad = cantidad,
                FechaRegistro = fechaRegistro,
                FechaEntrega = fechaEntrega,
                BodegaEntregaId = bodegaEntregaId,
                PrecioEnvio = precioEnvio,
                PlacaVehiculo = placaVehiculo,
                NumeroGuia = numeroGuia
            };

            // Realizar la actualización utilizando el objeto envioTerrestreActualizado
            // ...

            // Limpia la edición en la fila y recarga los datos
            GridViewEnviosTerrestres.EditIndex = -1;
            await CargarEnviosTerrestres();
        }





        protected async void GridViewEnviosTerrestres_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewEnviosTerrestres.EditIndex = -1;
            await CargarEnviosTerrestres();
        }

        protected async void GridViewEnviosTerrestres_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowIndex = e.RowIndex;

            if (rowIndex >= 0 && rowIndex < GridViewEnviosTerrestres.Rows.Count)
            {
                int envioTerrestreId = Convert.ToInt32(GridViewEnviosTerrestres.DataKeys[rowIndex].Value);

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiBaseUrl);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.DeleteAsync($"api/Enviosterrestres/{envioTerrestreId}");

                    if (response.IsSuccessStatusCode)
                    {
                        await CargarEnviosTerrestres();
                    }
                }
            }
        }



        private async Task CargarBodegasEntrega()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/bodegaterrestre");
                if (response.IsSuccessStatusCode)
                {
                    var bodegasTerrestres = await response.Content.ReadAsAsync<BodegaTerrestre[]>();
                    ddlBodegaEntregaId.DataSource = bodegasTerrestres;
                    ddlBodegaEntregaId.DataTextField = "Nombre"; // Cambiar por la propiedad de la bodega de entrega que deseas mostrar
                    ddlBodegaEntregaId.DataValueField = "BodegaId";
                    ddlBodegaEntregaId.DataBind();

                    // Agregar una opción por defecto si lo deseas
                    ddlBodegaEntregaId.Items.Insert(0, new ListItem("Seleccionar Bodega de Entrega", "-1"));
                }
            }
        }


        private async Task CargarTiposDeProducto()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/tiposproducto");
                if (response.IsSuccessStatusCode)
                {
                    var tiposDeProducto = await response.Content.ReadAsAsync<TipoProducto[]>(); // Reemplaza TipoDeProducto con tu tipo de dato
                    ddlprod.DataSource = tiposDeProducto;
                    ddlprod.DataTextField = "Nombre"; // Cambiar por la propiedad del tipo de producto que deseas mostrar
                    ddlprod.DataValueField = "TipoProductoId";
                    ddlprod.DataBind();

                    // Agregar una opción por defecto si lo deseas
                    ddlprod.Items.Insert(0, new ListItem("Seleccionar Tipo de Producto", "-1"));
                }
            }
        }

        //protected async void ddlprod_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    // Cargar tipos de producto nuevamente
        //    await CargarTiposDeProducto();
        //}

        //protected async void ddlClientes_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    // Cargar clientes nuevamente
        //    await CargarClientes();
        //}


        // Métodos para manejar eventos de GridView (RowEditing, RowUpdating, RowCancelingEdit, RowDeleting)
        // ...

        // Otros métodos auxiliares
        // ...
    }
}