using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Api.Models;


namespace Mundoexpres.web.Envios
{
    public partial class EnviosTerrestres : System.Web.UI.Page
    {
        private string apiBaseUrl = "https://localhost:44318/"; // Reemplazar con la URL real del API
        private string connectionString = ConfigurationManager.ConnectionStrings["MiConexionBD"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _ = CargarEnviosTerrestres();
                _ = CargarClientes();
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
            ddlprod.Text = string.Empty;
            ddlClientes.SelectedIndex = -1; // Limpiar selección de cliente
            TxtCantidad.Text = string.Empty;
            txtFechaRegistro.Text = string.Empty;
            txtFechaEntrega.Text = string.Empty;
            txtBodegaEntregaId.Text = string.Empty;
            txtPrecioEnvio.Text = string.Empty;
            txtPlacaVehiculo.Text = string.Empty;
            txtNumeroGuia.Text = string.Empty;
        }

        protected async void btnCrear_Click(object sender, EventArgs e)
        {
            // Recuperar datos de los campos en la página
            int tipoProductoId = Convert.ToInt32(ddlprod.Text);
            int clienteId = Convert.ToInt32(ddlClientes.SelectedValue);
            int cantidad = Convert.ToInt32(TxtCantidad.Text);
            DateTime fechaRegistro = Convert.ToDateTime(txtFechaRegistro.Text);
            DateTime fechaEntrega = Convert.ToDateTime(txtFechaEntrega.Text);
            int bodegaEntregaId = Convert.ToInt32(txtBodegaEntregaId.Text);
            decimal precioEnvio = Convert.ToDecimal(txtPrecioEnvio.Text);
            string placaVehiculo = txtPlacaVehiculo.Text;
            string numeroGuia = txtNumeroGuia.Text;

            // Crear objeto EnvioTerrestre
            EnvioTerrestre nuevoEnvioTerrestre = new EnvioTerrestre
            {
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
            }
        }

        // Métodos para manejar eventos de GridView (RowEditing, RowUpdating, RowCancelingEdit, RowDeleting)
        // ...

        // Otros métodos auxiliares
        // ...
    }
}