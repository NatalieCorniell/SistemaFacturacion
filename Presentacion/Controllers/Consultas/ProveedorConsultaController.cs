using C_Datos;
using C_Datos.DTOS;
using C_Dominio;
using C_Dominio.Procesos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Presentacion.Controllers.Consultas
{
    public class ProveedorConsultaController : Controller
    {
        readonly Proveedor Prov = new Proveedor();

        // GET: ProveedorConsulta
        [HttpGet]
        public ActionResult Consulta_Proveedor_View()
        {
            var Lista = new List<Dto_Proveedor>();
            var model = Prov.Listar();
            foreach (var item in model)
            {
                Dto_Proveedor dto_Proveedor = new Dto_Proveedor
                {
                    Id_Proveedor = item.Id_Proveedor,
                    Nombre = item.Nombre,
                    RNC = item.RNC,
                    Telefono = item.Telefono,
                    Correo = item.Correo
                };
                Lista.Add(dto_Proveedor);
            }
            return View(Lista);
        }
    }   
}