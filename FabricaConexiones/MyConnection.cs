using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Necesitamos definir diferentes interfaces
// para los objetos de conexión
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data.OleDb;

namespace FabricaConexiones
{
    // Un listado de posibles proveedores a utlizar
    // para realizar la conexión
    public enum DataProvider { SqlServer, OleDb, Odbc, None }

    class MyConnection
    {
        protected DataProvider dataProvider;    

        // Constructor
        public MyConnection(DataProvider theDataProvider)
        {
            dataProvider = theDataProvider;
        }

        // Métodos
        /// <summary>
        /// Realiza una conexión a una base de datos según la
        /// tecnología elegida.
        /// </summary>
        public void Conectar()
        {
            switch (dataProvider)
            {
                case DataProvider.SqlServer:
                    MyConnectionSql myConnection = new MyConnectionSql(dataProvider);
                    break;
                case DataProvider.OleDb:
                    MyConnectionOleDb myOtherConnection = new MyConnectionOleDb(dataProvider);
                    break;
                case DataProvider.Odbc:
                    break;
                case DataProvider.None:
                    Console.WriteLine("¡Tipo de conexión no disponible!");
                    break;
                default:
                    Console.WriteLine("Favor elegir un tipo de conexión");
                    break;
            }
        }

        /// <summary>
        /// Muestra el tipo de conexión que está utilizando el usuario.
        /// </summary>
        public void TipoConexion()
        {
            Console.WriteLine("Tu conexión actual es mediante {0}", dataProvider);
        }
    }
}
