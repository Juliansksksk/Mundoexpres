using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Configuration;
using System.Web.Http;
using Api.Models;

namespace Api.Controllers
{
    public class TiposProductoController : ApiController
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MiConexionBD"].ConnectionString;

        // GET api/clientes
        public IEnumerable<TipoProducto> GetTiposProducto()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM TiposDeProducto";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                List<TipoProducto> tiposProducto = new List<TipoProducto>();

                while (reader.Read())
                {
                    TipoProducto tipoProducto = new TipoProducto
                    {
                        TipoProductoId = Convert.ToInt32(reader["TipoProductoId"]),
                        Nombre = reader["Nombre"].ToString()
                    };
                    tiposProducto.Add(tipoProducto);
                }

                return tiposProducto;
            }
        }

        // POST api/tiposproducto
        public IHttpActionResult PostTipoProducto(TipoProducto tipoProducto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO TiposDeProducto (Nombre) VALUES (@Nombre)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", tipoProducto.Nombre);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("No se pudo agregar el tipo de producto");
                }
            }
        }

        public IHttpActionResult PutTipoProducto(int id, TipoProducto tipoProducto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE TiposDeProducto SET Nombre = @Nombre WHERE TipoProductoId = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Nombre", tipoProducto.Nombre);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
        }

        // DELETE api/tiposproducto/5
        public IHttpActionResult DeleteTipoProducto(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM TiposDeProducto WHERE TipoProductoId = @Id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", id);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return Ok();
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
            catch (SqlException ex)
            {
                // Si ocurre una excepción, devuelve un mensaje de error
                return InternalServerError(ex);
            }
        }
    }
}