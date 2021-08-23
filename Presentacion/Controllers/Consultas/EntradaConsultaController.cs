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
    public class EntradaConsultaController : Controller
    {
        readonly Entrada entrada = new Entrada();

        // GET: EntradaConsulta
        [HttpGet]
        public ActionResult Consulta_Entrada_View()
        {
            var Lista = new List<Dto_Entrada>();
            var model = entrada.Listar();
            foreach (var item in model)
            {
                Dto_Entrada Dto_Entrada = new Dto_Entrada
                {
                    Id_Proveedor = item.Id_Entrada,
                    Fecha = (DateTime)item.Fecha,
                    Cantidad = (int)item.Cantidad,
                    Id_Producto = (int)item.Id_Producto
                };
                Lista.Add(Dto_Entrada);
            }
            return View(Lista);
        }
    }
}