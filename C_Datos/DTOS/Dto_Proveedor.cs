using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Datos.DTOS
{
   public class Dto_Proveedor
    {
        [Required]
        public int Id_Proveedor { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string RNC { get; set; }
        [Required]
        public string Telefono { get; set; }
        [EmailAddress]
        public string Correo { get; set; }
    }
}
