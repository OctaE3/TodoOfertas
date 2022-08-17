using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOOFERTAS.Persistencia
{
    public class Conexion
    {
        public static string CadenaDeConexion
        {
            get
            {
                return @"Server=localhost\SQLEXPRESS;Initial Catalog=todo_ofertas; Integrated Security=True";
            }
        }
    }
}