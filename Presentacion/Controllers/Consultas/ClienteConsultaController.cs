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
    public class ClienteConsultaController : Controller
    {
        readonly Cliente _TCliente = new Cliente();

        // GET: ClienteConsulta
        [HttpGet]
        public ActionResult Consulta_Cliente_View()
        {
            var Lista = new List<Dto_Cliente>();
            var model = _TCliente.Listar();
            foreach (var item in model)
            {
                Dto_Cliente Dto_Cliente = new Dto_Cliente
                {
                    Id_Cliente = item.Id_Cliente,
                    Nombre = item.Nombre,
                    RNC = item.RNC,
                    Telefono = item.Telefono,
                    Correo = item.Correo,
                    Categoria = item.Categoria
                };
                Lista.Add(Dto_Cliente);
            }
            return View(Lista);
        }
    }
}
