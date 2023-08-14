using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Mundoexpres.web
{
    public partial class ListaClientes : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            lnkEnvios.NavigateUrl = ResolveUrl("~/web/Envios/EnviosTerrestres.aspx");
            lnkTiposProducto.NavigateUrl = ResolveUrl("~/web/CarpetaTP/TiposdeProducto.aspx");
            if (!IsPostBack)
            {
                await CargarClientes();
            }
        }

        protected async Task CargarClientes()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44318/"); // Cambia la URL base a tu API
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/clientes");
                if (response.IsSuccessStatusCode)
                {
                    List<Cliente> clientes = await response.Content.ReadAsAsync<List<Cliente>>();
                    GridViewClientes.DataSource = clientes;
                    GridViewClientes.DataBind();
                }
            }
        }


        protected void GridViewClientes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewClientes.EditIndex = e.NewEditIndex;
            Page.RegisterAsyncTask(new PageAsyncTask(CargarClientes)); // Registra el método CargarClientes como tarea asincrónica
        }

        protected async void GridViewClientes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int clienteId = Convert.ToInt32(GridViewClientes.DataKeys[e.RowIndex].Value);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44318/"); // Cambia la URL base a tu API
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.DeleteAsync($"api/clientes/{clienteId}");
                if (response.IsSuccessStatusCode)
                {
                    await CargarClientes(); // Recargar la lista después de eliminar
                }
            }
        }

        protected async void GridViewClientes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridViewClientes.Rows[e.RowIndex];
            int clienteId = Convert.ToInt32(GridViewClientes.DataKeys[e.RowIndex].Value);

            // Obtener los nuevos valores de los campos editados
            string nuevoNombre = (row.FindControl("txtEditNombre") as TextBox).Text;
            string nuevoEmail = (row.FindControl("txtEditEmail") as TextBox).Text;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44318/"); // Cambia la URL base a tu API
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Crear un objeto Cliente con los nuevos valores
                Cliente clienteActualizado = new Cliente
                {
                    ClienteId = clienteId, // Asegúrate de asignar el ID del cliente
                    Nombre = nuevoNombre,
                    Email = nuevoEmail
                    // Completa con más campos si es necesario
                };

                // Enviar la actualización a la API
                HttpResponseMessage response = await client.PutAsJsonAsync($"api/clientes/{clienteId}", clienteActualizado);
                if (response.IsSuccessStatusCode)
                {
                    // Actualizar la vista
                    GridViewClientes.EditIndex = -1; // Salir del modo de edición
                    await CargarClientes(); // Volver a cargar los datos
                }
                else
                {
                    // Manejar el caso en que la actualización falla (puede mostrar un mensaje de error)
                }
            }
        }

        protected void GridViewClientes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewClientes.EditIndex = -1;
            _ = CargarClientes(); // Vuelve a cargar los datos
        }

    }
}