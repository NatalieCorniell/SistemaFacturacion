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
    public class ProductoConsultaController : Controller
    {
        readonly Mercancia Mercancia = new Mercancia();

        // GET: ProductoConsulta
        [HttpGet]
        public ActionResult Consulta_Producto_View()
        {
            return View("Consulta_Producto_View", Data());
        }
        public List<Dto_Producto> Data()
        {
            var Lista = new List<Dto_Producto>();
            var model = Mercancia.Listar();
            foreach (var item in model)
            {
                Dto_Producto Dto_Producto = new Dto_Producto
                {
                    Id_Producto = item.Id_Producto,
                    Nombre = item.Nombre,
                    Precio = item.Precio
                };
                Lista.Add(Dto_Producto);
            }
            return Lista;
        }
    }
}