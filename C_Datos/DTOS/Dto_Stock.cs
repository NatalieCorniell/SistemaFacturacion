using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Datos.DTOS
{
    public class Dto_Stock
    {

        [Required]
        public int Id_Producto { get; set; }
        [Required]
        public int Nombre_Producto { get; set; }
        [Required]
        public int Cantidad { get; set; }
    }
}
