using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricaConexiones
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Una sencilla fábrica de conexiones *****");

            MyConnection myConnection = new MyConnection(DataProvider.OleDb);
            myConnection.Conectar();
            myConnection.TipoConexion();

            Console.ReadLine();
        }
    }
}
