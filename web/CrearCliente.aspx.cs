using Api.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.UI;

namespace Mundoexpres.web
{
    public partial class CrearCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected async void btnCrear_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string email = txtEmail.Text;

            Cliente nuevoCliente = new Cliente
            {
                Nombre = nombre,
                Email = email
                // Completa con más campos si es necesario
            };

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44318/"); // Cambia la URL base a tu API
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.PostAsJsonAsync("api/clientes", nuevoCliente);
                if (response.IsSuccessStatusCode)
                {
                    // Redirige a la página de lista de clientes después de crear
                    Response.Redirect("ListaClientes.aspx");
                }
            }
        }
    }
}