using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Datos.DTOS
{
    public class Dto_Entrada
    {
        public int Cantidad { get; set; }
        public int Id_Proveedor { get; set; }
        public int Id_Producto { get; set; }
        public DateTime Fecha { get; set; }
    }
}
