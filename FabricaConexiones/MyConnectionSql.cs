using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Agregar los namespaces necesarios para poder realizar la conexión
using System.Data;
using System.Data.SqlClient;

namespace FabricaConexiones
{
    class MyConnectionSql : MyConnection
    {
        public MyConnectionSql(DataProvider theDataProvider) : base(theDataProvider)
        {
            SqlConnection conn = new SqlConnection(@"server = (local)\sqlexpress; integrated security = true");

            try
            {
                // Abrir la conexión
                conn.Open();

                // Detalles de la conexión
                this.DetallesConexion(conn);
            }
            catch (SqlException ex)
            {
                // Desplegar la causa del error (excepción)
                Console.WriteLine("Error: " + ex.Message + ex.StackTrace);
            }
            finally
            {
                // SIEMPRE cerrar la conexión
                conn.Close();
                Console.WriteLine("Conexión cerrada");
            }
        }

        protected void DetallesConexion(SqlConnection connection)
        {
            Console.WriteLine("Conexión establecida");
            Console.WriteLine("\tConnection string: {0}", connection.ConnectionString);
            Console.WriteLine("\tBase de datos: {0}", connection.Database);
            Console.WriteLine("\tFuente de datos: {0}", connection.DataSource);
            Console.WriteLine("\tVersión del servidor: {0}", connection.ServerVersion);
            Console.WriteLine("\tEstado: {0}", connection.State);
            Console.WriteLine("\tId estación de trabajo: {0}", connection.WorkstationId);
        }
    }
}
