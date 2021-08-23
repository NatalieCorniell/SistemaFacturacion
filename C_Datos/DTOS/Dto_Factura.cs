using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace C_Datos.DTOS
{
    public class Dto_Factura
    {
        [Required]
        public int Id_Factura { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public int Id_Producto { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public double Total { get; set; }
        [Required]
        public string Categoria { get; set; }
        [Required]
        public double Descuento { get; set; }
        [Required]
        public double ITBIS { get; set; }
        [Required]
        public string Nombre_Cliente { get; set; }
        [Required]
        public string Id_Cliente { get; set; }
        [Required]
        public string Nombre_Producto { get; set; }
        public List<SelectListItem> Productos { get; set; }

    }
}
