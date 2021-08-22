﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace C_Datos.DTOS
{
    public class Dto_Cliente
    {
        [Required]
        public int Id_Cliente { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string RNC { get; set; }
        [Required]
        public string Telefono { get; set; }
        [EmailAddress]
        public string Correo { get; set; }
        [Required]
        public string Categoria { get; set; }
        [Required]
        public string Id_Categoria { get; set; }
        [Required]
        public List<SelectListItem> Categorias { get; set; }
    }
}
