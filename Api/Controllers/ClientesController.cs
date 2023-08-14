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
    public class ClientesController : ApiController
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MiConexionBD"].ConnectionString;

        // GET api/clientes
        public IEnumerable<Cliente> GetClientes()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Clientes";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                List<Cliente> clientes = new List<Cliente>();

                while (reader.Read())
                {
                    Cliente cliente = new Cliente
                    {
                        ClienteId = Convert.ToInt32(reader["ClienteId"]), // Usar "ClienteId" en lugar de "Id"
                        Nombre = reader["Nombre"].ToString(),
                        Email = reader["Email"].ToString(),
                    };
                    clientes.Add(cliente);
                }

                return clientes;
            }
        }

        // POST api/clientes
        public IHttpActionResult PostCliente(Cliente cliente)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Clientes (Nombre,Email) VALUES (@Nombre, @Email)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                command.Parameters.AddWithValue("@Email", cliente.Email);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("No se pudo agregar el cliente");
                }
            }
        }

        // DELETE api/clientes/5
        public IHttpActionResult DeleteCliente(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Clientes WHERE ClienteId = @Id"; // Usar "ClienteId" en lugar de "Id"
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
                // Si ocurre una excepción debido a la restricción de clave externa, devuelve un mensaje de error
                if (ex.Number == 547)
                {
                    return BadRequest("No se puede eliminar el cliente debido a restricciones de clave externa.");
                }
                else
                {
                    // En caso de otras excepciones de SQL, devuelve un mensaje genérico
                    return InternalServerError(ex);
                }
            }
        }

        public IHttpActionResult PutCliente(int id, Cliente cliente)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Clientes SET Nombre = @Nombre, Email = @Email WHERE ClienteId = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                command.Parameters.AddWithValue("@Email", cliente.Email);
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
