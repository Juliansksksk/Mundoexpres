using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Api.Models;


namespace Mundoexpres.web.CarpetaTP
{
    public partial class TiposdeProducto : System.Web.UI.Page
    {
        private string apiBaseUrl = "https://localhost:44318/"; // Cambia la URL base a la de tu API

        protected async void Page_Load(object sender, EventArgs e)
        {
            lnkClientes.NavigateUrl = ResolveUrl("~/web/ListaClientes.aspx");

            if (!IsPostBack)
            {
                await CargarTiposProducto();
            }
        }

        protected async Task CargarTiposProducto()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/tiposproducto");
                if (response.IsSuccessStatusCode)
                {
                    List<TipoProducto> tiposProducto = await response.Content.ReadAsAsync<List<TipoProducto>>();
                    GridViewTiposProducto.DataSource = tiposProducto;
                    GridViewTiposProducto.DataBind();
                }
            }
        }

        protected async void btnCrear_Click(object sender, EventArgs e)
        {
            string nuevoNombre = txtNuevoNombre.Text;

            TipoProducto nuevoTipoProducto = new TipoProducto
            {
                Nombre = nuevoNombre
            };

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.PostAsJsonAsync("api/tiposproducto", nuevoTipoProducto);
                if (response.IsSuccessStatusCode)
                {
                    await CargarTiposProducto();
                    LimpiarCampos();
                }
            }
        }

        protected async void GridViewTiposProducto_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewTiposProducto.EditIndex = e.NewEditIndex;
            await CargarTiposProducto();
        }

        protected async void GridViewTiposProducto_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridViewTiposProducto.Rows[e.RowIndex];
            int tipoProductoId = Convert.ToInt32(GridViewTiposProducto.DataKeys[e.RowIndex].Value);


            string nuevoNombre = (row.Cells[1].Controls[0] as TextBox)?.Text;


            TipoProducto tipoProductoActualizado = new TipoProducto
                {
                    TipoProductoId = tipoProductoId,
                    Nombre = nuevoNombre
                };

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiBaseUrl);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.PutAsJsonAsync($"api/tiposproducto/{tipoProductoId}", tipoProductoActualizado);
                    if (response.IsSuccessStatusCode)
                    {
                        GridViewTiposProducto.EditIndex = -1;
                        await CargarTiposProducto();
                    }
                }
            
        }



        protected async void GridViewTiposProducto_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewTiposProducto.EditIndex = -1;
            await CargarTiposProducto();
        }

        protected async void GridViewTiposProducto_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int tipoProductoId = Convert.ToInt32(GridViewTiposProducto.DataKeys[e.RowIndex].Value);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.DeleteAsync($"api/tiposproducto/{tipoProductoId}");
                if (response.IsSuccessStatusCode)
                {
                    await CargarTiposProducto();
                }
            }
        }

        private void LimpiarCampos()
        {
            txtNuevoNombre.Text = string.Empty;
        }

        protected async void DetailsViewTipoProducto_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            if (e.Exception == null) // Verifica si no hubo excepción durante la inserción
            {
                await CargarTiposProducto(); // Vuelve a cargar la lista de tipos de producto
                DetailsViewTipoProducto.ChangeMode(DetailsViewMode.ReadOnly); // Cambia el modo del DetailsView a "ReadOnly"
            }
            else
            {
                // Si ocurre una excepción durante la inserción, puedes manejarla aquí
                e.ExceptionHandled = true; // Indica que la excepción ya ha sido manejada
            }
        }

        protected async void DetailsViewTipoProducto_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            if (e.Exception == null) // Verifica si no hubo excepción durante la actualización
            {
                GridViewTiposProducto.EditIndex = -1; // Salir del modo de edición del GridView
                await CargarTiposProducto(); // Vuelve a cargar la lista de tipos de producto
            }
            else
            {
                // Si ocurre una excepción durante la actualización, puedes manejarla aquí
                e.ExceptionHandled = true; // Indica que la excepción ya ha sido manejada
            }
        }

        protected void DetailsViewTipoProducto_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            // Aquí puedes agregar lógica para manipular los valores antes de la actualización
        }







        protected void DetailsViewTipoProducto_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {
            if (e.CancelingEdit) // Si se está cancelando la edición
            {
                e.Cancel = true; // Cancela el cambio de modo
            }
        }
    }
}