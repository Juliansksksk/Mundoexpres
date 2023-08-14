using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;
using System.Web.Http;
using Api.Models;

namespace Api.Controllers
{
    public class EnviosMaritimosController : ApiController
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MiConexionBD"].ConnectionString;

        // GET: api/EnviosMaritimos
        public IHttpActionResult GetEnviosMaritimos()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM EnviosMaritimos";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<EnvioMaritimo> enviosMaritimos = new List<EnvioMaritimo>();

                    while (reader.Read())
                    {
                        EnvioMaritimo envioMaritimo = new EnvioMaritimo();

                        envioMaritimo.EnvioMaritimoId = Convert.ToInt32(reader["EnvioMaritimoId"]);
                        envioMaritimo.TipoProductoId = Convert.ToInt32(reader["TipoProductoId"]);
                        envioMaritimo.ClienteId = Convert.ToInt32(reader["ClienteId"]);
                        envioMaritimo.Cantidad = Convert.ToInt32(reader["Cantidad"]);
                        envioMaritimo.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);
                        envioMaritimo.FechaEntrega = Convert.ToDateTime(reader["FechaEntrega"]);
                        envioMaritimo.PuertoEntregaId = Convert.ToInt32(reader["PuertoEntregaId"]);
                        envioMaritimo.PrecioEnvio = Convert.ToDecimal(reader["PrecioEnvio"]);
                        envioMaritimo.NumeroFlota = reader["NumeroFlota"].ToString();
                        envioMaritimo.NumeroGuia = reader["NumeroGuia"].ToString();

                        enviosMaritimos.Add(envioMaritimo);
                    }

                    return Ok(enviosMaritimos);
                }
            }
        }

        // GET: api/EnviosMaritimos/5
        public IHttpActionResult GetEnvioMaritimo(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM EnviosMaritimos WHERE EnvioMaritimoId = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        EnvioMaritimo envioMaritimo = new EnvioMaritimo();

                        envioMaritimo.EnvioMaritimoId = Convert.ToInt32(reader["EnvioMaritimoId"]);
                        envioMaritimo.TipoProductoId = Convert.ToInt32(reader["TipoProductoId"]);
                        envioMaritimo.ClienteId = Convert.ToInt32(reader["ClienteId"]);
                        envioMaritimo.Cantidad = Convert.ToInt32(reader["Cantidad"]);
                        envioMaritimo.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);
                        envioMaritimo.FechaEntrega = Convert.ToDateTime(reader["FechaEntrega"]);
                        envioMaritimo.PuertoEntregaId = Convert.ToInt32(reader["PuertoEntregaId"]);
                        envioMaritimo.PrecioEnvio = Convert.ToDecimal(reader["PrecioEnvio"]);
                        envioMaritimo.NumeroFlota = reader["NumeroFlota"].ToString();
                        envioMaritimo.NumeroGuia = reader["NumeroGuia"].ToString();

                        return Ok(envioMaritimo);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
        }

        // POST: api/EnviosMaritimos
        public IHttpActionResult PostEnvioMaritimo(EnvioMaritimo envioMaritimo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO EnviosMaritimos (TipoProductoId, ClienteId, Cantidad, FechaRegistro, FechaEntrega, PuertoEntregaId, PrecioEnvio, NumeroFlota, NumeroGuia) VALUES (@TipoProductoId, @ClienteId, @Cantidad, @FechaRegistro, @FechaEntrega, @PuertoEntregaId, @PrecioEnvio, @NumeroFlota, @NumeroGuia)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TipoProductoId", envioMaritimo.TipoProductoId);
                command.Parameters.AddWithValue("@ClienteId", envioMaritimo.ClienteId);
                command.Parameters.AddWithValue("@Cantidad", envioMaritimo.Cantidad);
                command.Parameters.AddWithValue("@FechaRegistro", envioMaritimo.FechaRegistro);
                command.Parameters.AddWithValue("@FechaEntrega", envioMaritimo.FechaEntrega);
                command.Parameters.AddWithValue("@PuertoEntregaId", envioMaritimo.PuertoEntregaId);
                command.Parameters.AddWithValue("@PrecioEnvio", envioMaritimo.PrecioEnvio);
                command.Parameters.AddWithValue("@NumeroFlota", envioMaritimo.NumeroFlota);
                command.Parameters.AddWithValue("@NumeroGuia", envioMaritimo.NumeroGuia);

                command.ExecuteNonQuery();
            }

            return CreatedAtRoute("DefaultApi", new { id = envioMaritimo.EnvioMaritimoId }, envioMaritimo);
        }

        // PUT: api/EnviosMaritimos/5
        public IHttpActionResult PutEnvioMaritimo(int id, EnvioMaritimo envioMaritimo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != envioMaritimo.EnvioMaritimoId)
            {
                return BadRequest();
            }

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE EnviosMaritimos SET TipoProductoId = @TipoProductoId, ClienteId = @ClienteId, Cantidad = @Cantidad, FechaRegistro = @FechaRegistro, FechaEntrega = @FechaEntrega, PuertoEntregaId = @PuertoEntregaId, PrecioEnvio = @PrecioEnvio, NumeroFlota = @NumeroFlota, NumeroGuia = @NumeroGuia WHERE EnvioMaritimoId = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TipoProductoId", envioMaritimo.TipoProductoId);
                command.Parameters.AddWithValue("@ClienteId", envioMaritimo.ClienteId);
                command.Parameters.AddWithValue("@Cantidad", envioMaritimo.Cantidad);
                command.Parameters.AddWithValue("@FechaRegistro", envioMaritimo.FechaRegistro);
                command.Parameters.AddWithValue("@FechaEntrega", envioMaritimo.FechaEntrega);
                command.Parameters.AddWithValue("@PuertoEntregaId", envioMaritimo.PuertoEntregaId);
                command.Parameters.AddWithValue("@PrecioEnvio", envioMaritimo.PrecioEnvio);
                command.Parameters.AddWithValue("@NumeroFlota", envioMaritimo.NumeroFlota);
                command.Parameters.AddWithValue("@NumeroGuia", envioMaritimo.NumeroGuia);
                command.Parameters.AddWithValue("@Id", id);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    return NotFound();
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/EnviosMaritimos/5
        public IHttpActionResult DeleteEnvioMaritimo(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM EnviosMaritimos WHERE EnvioMaritimoId = @Id";
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
    }
}
