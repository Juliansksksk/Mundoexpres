using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Api.Models;

namespace Api.Controllers
{
    public class BodegaTerrestreController : ApiController
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MiConexionBD"].ConnectionString;

        // GET api/bodegaterrestre
        public IEnumerable<BodegaTerrestre> GetBodegasAlmacenamientoTerrestre()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM BodegasAlmacenamientoTerrestre";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                List<BodegaTerrestre> BodegasAlmacenamientoTerrestre = new List<BodegaTerrestre>();

                while (reader.Read())
                {
                    BodegaTerrestre bodegaTerrestre = new BodegaTerrestre
                    {
                        BodegaId = Convert.ToInt32(reader["BodegaId"]),
                        Nombre = reader["Nombre"].ToString(),
                        //Direccion = reader["Direccion"].ToString(),
                        //Ciudad = reader["Ciudad"].ToString(),
                        //Pais = reader["Pais"].ToString()
                    };
                    BodegasAlmacenamientoTerrestre.Add(bodegaTerrestre);
                }

                return BodegasAlmacenamientoTerrestre;
            }
        }

        // POST api/bodegaterrestre
        public IHttpActionResult PostBodegaTerrestre(BodegaTerrestre bodegaTerrestre)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO BodegasAlmacenamientoTerrestre (Nombre, Direccion, Ciudad, Pais) VALUES (@Nombre, @Direccion, @Ciudad, @Pais)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", bodegaTerrestre.Nombre);
                command.Parameters.AddWithValue("@Direccion", bodegaTerrestre.Direccion);
                command.Parameters.AddWithValue("@Ciudad", bodegaTerrestre.Ciudad);
                command.Parameters.AddWithValue("@Pais", bodegaTerrestre.Pais);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("No se pudo agregar la bodega terrestre");
                }
            }
        }

        public IHttpActionResult PutBodegaTerrestre(int id, BodegaTerrestre bodegaTerrestre)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE BodegasAlmacenamientoTerrestre SET Nombre = @Nombre, Direccion = @Direccion, Ciudad = @Ciudad, Pais = @Pais WHERE BodegaId = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Nombre", bodegaTerrestre.Nombre);
                command.Parameters.AddWithValue("@Direccion", bodegaTerrestre.Direccion);
                command.Parameters.AddWithValue("@Ciudad", bodegaTerrestre.Ciudad);
                command.Parameters.AddWithValue("@Pais", bodegaTerrestre.Pais);

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

        // DELETE api/bodegaterrestre/5
        public IHttpActionResult DeleteBodegaTerrestre(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM BodegasAlmacenamientoTerrestre WHERE BodegaId = @Id";
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
