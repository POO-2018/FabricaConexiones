using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Agregar los namespaces necesarios para lograr la conexión
using System.Data;
using System.Data.OleDb;

namespace FabricaConexiones
{
    class MyConnectionOleDb : MyConnection
    {
        public MyConnectionOleDb(DataProvider theDataProvidet) : base(theDataProvidet)
        {
            // Crear la cadena de conexión
            OleDbConnection conn = new OleDbConnection(@"provider = sqloledb;
                data source = (local)\sqlexpress; integrated security = sspi;");

            try
            {
                // Establecer la conexión
                conn.Open();
                Console.WriteLine("Conexión establecida.");

                // Detalles de la conexión
                this.DetallesConexion(conn);
            }
            catch (OleDbException ex)
            {
                // Desplegar error en la conexión
                Console.WriteLine("Error: " + ex.Message + ex.StackTrace);
            }
            finally
            {
                // Cerrar la conexión
                conn.Close();
            }
        }

        protected void DetallesConexion(OleDbConnection connection)
        {
            Console.WriteLine("Conexión establecida");
            Console.WriteLine("\tConnection string: {0}", connection.ConnectionString);
            Console.WriteLine("\tBase de datos: {0}", connection.Database);
            Console.WriteLine("\tFuente de datos: {0}", connection.DataSource);
            Console.WriteLine("\tVersión del servidor: {0}", connection.ServerVersion);
            Console.WriteLine("\tEstado: {0}", connection.State);
        }
    }
}
