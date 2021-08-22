using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace C_Datos.DTOS
{
    public class Dto_Stock
    {

        [Required]
        public int Id_Producto { get; set; }
        [Required]
        public int Id_Proveedor { get; set; }
        [Required]
        public string Nombre_Producto { get; set; }
        [Required]
        public string Nombre_Proveedor { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        public List<SelectListItem> TProductos { get; set; }
        public List<SelectListItem> TProveedores { get; set; }
    }
}
