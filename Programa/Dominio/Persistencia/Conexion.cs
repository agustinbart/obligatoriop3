using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class Conexion
    {
        protected static string CadenaDeConexion
        {
            get
            {
                return @"Server=AGUSTIN\SQLEXPRESS;Initial Catalog=obligatoriop3; Integrated Security=True";
            }
        }
    }
}
