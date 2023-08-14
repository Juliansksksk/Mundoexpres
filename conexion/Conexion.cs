using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Mundoexpres.conexion
{
    public class Conexion
    {

        public static SqlConnection GetConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MiConexionBD"].ConnectionString;
            return new SqlConnection(connectionString);
        }




    }
}