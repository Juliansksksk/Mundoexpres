using Api.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.UI;

namespace Mundoexpres.web
{
    public partial class EditarCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Obtiene el ID del cliente a editar desde la consulta en la URL
                int idCliente = Convert.ToInt32(Request.QueryString["id"]);
                _ = CargarDatosCliente(idCliente);
            }
        }

        protected async Task CargarDatosCliente(int idCliente)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44318/"); // Cambia la URL base a tu API
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync($"api/clientes/{idCliente}");
                if (response.IsSuccessStatusCode)
                {
                    Cliente cliente = await response.Content.ReadAsAsync<Cliente>();
                    txtNombre.Text = cliente.Nombre;
                    txtCorreo.Text = cliente.Email;
                }
            }
        }

        protected async void btnActualizar_Click(object sender, EventArgs e)
        {
            int idCliente = Convert.ToInt32(Request.QueryString["ClienteId"]);
            string nombre = txtNombre.Text;
            string correo = txtCorreo.Text;

            Cliente clienteActualizado = new Cliente
            {
                ClienteId = idCliente,
                Nombre = nombre,
                Email = correo
                // Completa con más campos si es necesario
            };

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44318/"); // Cambia la URL base a tu API
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.PutAsJsonAsync($"api/clientes/{idCliente}", clienteActualizado);
                if (response.IsSuccessStatusCode)
                {
                    // Redirige a la página de lista de clientes después de actualizar
                    Response.Redirect("ListaClientes.aspx");
                }
            }
        }
    }
}