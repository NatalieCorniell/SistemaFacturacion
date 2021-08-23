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
    public class FacturaConsultaController : Controller
    {
        readonly Factura factura = new Factura();
        readonly Mercancia Mercancia = new Mercancia();

        // GET: FacturaConsulta
        public ActionResult Consulta_Factura_View()
        {
            var Lista = new List<Dto_Factura>();
            var model = factura.Listar();
            foreach (var item in model)
            {
                Dto_Factura Dto_Factura = new Dto_Factura
                {
                   Id_Factura = item.Id_Factura,
                   Id_Cliente = item.Id_Cliente,
                   Id_Producto = (int)item.Id_Producto,
                   ITBIS = (double)item.ITBIS,
                   Cantidad = (int)item.Cantidad,
                   Descuento = (double)item.Descuento,
                   Total = (double)item.Total,
                   Nombre_Cliente = item.Nombre_Cliente,
                   Nombre_Producto = Mercancia.Listar().Find(x => x.Id_Producto == item.Id_Producto).Nombre,
                   Categoria = item.Categoria,
                   Fecha = (DateTime)item.Fecha
                };
                Lista.Add(Dto_Factura);
            }
            return View(Lista);
        }
    }
}