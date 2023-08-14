using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;
using System.Web.Http;
using Api.Models;

namespace Api.Controllers
{
    public class EnviosTerrestresController : ApiController
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MiConexionBD"].ConnectionString;

        // GET: api/EnviosTerrestres
        public IHttpActionResult GetEnviosTerrestres()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM EnviosTerrestres";
                SqlCommand command = new SqlCommand(query, connection);

                List<EnvioTerrestre> enviosTerrestres = new List<EnvioTerrestre>();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        EnvioTerrestre envioTerrestre = new EnvioTerrestre
                        {
                            EnvioTerrestreId = Convert.ToInt32(reader["EnvioTerrestreId"]),
                            TipoProductoId = Convert.ToInt32(reader["TipoProductoId"]),
                            ClienteId = Convert.ToInt32(reader["ClienteId"]),
                            Cantidad = Convert.ToInt32(reader["Cantidad"]),
                            FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]),
                            FechaEntrega = Convert.ToDateTime(reader["FechaEntrega"]),
                            BodegaEntregaId = Convert.ToInt32(reader["BodegaEntregaId"]),
                            PrecioEnvio = Convert.ToDecimal(reader["PrecioEnvio"]),
                            PlacaVehiculo = reader["PlacaVehiculo"].ToString(),
                            NumeroGuia = reader["NumeroGuia"].ToString()
                        };

                        enviosTerrestres.Add(envioTerrestre);
                    }
                }

                return Ok(enviosTerrestres); // Devolver la lista de envíos terrestres
            }
        }

        public IHttpActionResult GetEnvioTerrestre(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM EnviosTerrestres WHERE EnvioTerrestreId = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Leer los datos del reader y construir un objeto EnvioTerrestre
                        EnvioTerrestre envioTerrestre = new EnvioTerrestre();

                        // Inicializar las propiedades del objeto con los valores leídos
                        // ...

                        return Ok(envioTerrestre); // Devolver el envío terrestre encontrado
                    }
                    else
                    {
                        return NotFound(); // Devolver NotFound si no se encuentra el envío terrestre
                    }
                }
            }
        }

        // POST: api/EnviosTerrestres
        public IHttpActionResult PostEnvioTerrestre(EnvioTerrestre envioTerrestre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO EnviosTerrestres (TipoProductoId, ClienteId, Cantidad, FechaRegistro, FechaEntrega, BodegaEntregaId, PrecioEnvio, PlacaVehiculo, NumeroGuia) VALUES (@TipoProductoId, @ClienteId, @Cantidad, @FechaRegistro, @FechaEntrega, @BodegaEntregaId, @PrecioEnvio, @PlacaVehiculo, @NumeroGuia)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TipoProductoId", envioTerrestre.TipoProductoId);
                command.Parameters.AddWithValue("@ClienteId", envioTerrestre.ClienteId);
                command.Parameters.AddWithValue("@Cantidad", envioTerrestre.Cantidad);
                command.Parameters.AddWithValue("@FechaRegistro", envioTerrestre.FechaRegistro);
                command.Parameters.AddWithValue("@FechaEntrega", envioTerrestre.FechaEntrega);
                command.Parameters.AddWithValue("@BodegaEntregaId", envioTerrestre.BodegaEntregaId);
                command.Parameters.AddWithValue("@PrecioEnvio", envioTerrestre.PrecioEnvio);
                command.Parameters.AddWithValue("@PlacaVehiculo", envioTerrestre.PlacaVehiculo);
                command.Parameters.AddWithValue("@NumeroGuia", envioTerrestre.NumeroGuia);

                command.ExecuteNonQuery();
            }

            return CreatedAtRoute("DefaultApi", new { id = envioTerrestre.EnvioTerrestreId }, envioTerrestre);
        }

        // PUT: api/EnviosTerrestres/5
        public IHttpActionResult PutEnvioTerrestre(int id, EnvioTerrestre envioTerrestre)
        {
            if (!ModelState.IsValid || id != envioTerrestre.EnvioTerrestreId)
            {
                return BadRequest();
            }

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE EnviosTerrestres SET TipoProductoId = @TipoProductoId, ClienteId = @ClienteId, Cantidad = @Cantidad, FechaRegistro = @FechaRegistro, FechaEntrega = @FechaEntrega, BodegaEntregaId = @BodegaEntregaId, PrecioEnvio = @PrecioEnvio, PlacaVehiculo = @PlacaVehiculo, NumeroGuia = @NumeroGuia WHERE EnvioTerrestreId = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@TipoProductoId", envioTerrestre.TipoProductoId);
                command.Parameters.AddWithValue("@ClienteId", envioTerrestre.ClienteId);
                command.Parameters.AddWithValue("@Cantidad", envioTerrestre.Cantidad);
                command.Parameters.AddWithValue("@FechaRegistro", envioTerrestre.FechaRegistro);
                command.Parameters.AddWithValue("@FechaEntrega", envioTerrestre.FechaEntrega);
                command.Parameters.AddWithValue("@BodegaEntregaId", envioTerrestre.BodegaEntregaId);
                command.Parameters.AddWithValue("@PrecioEnvio", envioTerrestre.PrecioEnvio);
                command.Parameters.AddWithValue("@PlacaVehiculo", envioTerrestre.PlacaVehiculo);
                command.Parameters.AddWithValue("@NumeroGuia", envioTerrestre.NumeroGuia);

                command.ExecuteNonQuery();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/EnviosTerrestres/5
        public IHttpActionResult DeleteEnvioTerrestre(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM EnviosTerrestres WHERE EnvioTerrestreId = @Id";
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
