using System;
using System.Data.SqlClient;

namespace CinemaCtes
{
    public class ConexionBD
    {
        // cadena de conexión configurada 
        private readonly string cadenaConexion = "Server=DESKTOP-PQ8VA1J\\SQLEXPRESS; Database=db_CinemaCtes; Trusted_Connection=True;";

        // Método para obtener una conexión abierta
        public SqlConnection ObtenerConexión()
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            try
            {
                conexion.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al conectar con la base de datos: " + ex.Message);
            }
            return conexion;
        }
    }
}
