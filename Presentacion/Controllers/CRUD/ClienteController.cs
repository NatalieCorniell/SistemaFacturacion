using C_Datos;
using C_Datos.DTOS;
using C_Dominio.Procesos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentacion.Controllers.CRUD
{
    public class ClienteController : Controller
    {

        readonly Cliente _TCliente = new Cliente();
        // GET: cliente
        public ActionResult Principal()
        {
            var Lista = new List<Dto_Cliente>();
            var model = _TCliente.Listar();
            foreach (var item in model)
            {
                Dto_Cliente cliente = new Dto_Cliente
                {
                    Id_Cliente = item.Id_Cliente,
                    Nombre = item.Nombre,
                    RNC = item.RNC,
                    Telefono = item.Telefono,
                    Correo = item.Correo,
                    Categoria = item.Categoria
                };
                Lista.Add(cliente);
            }
            return View("ClienteView", Lista);
        }
        public ActionResult ClienteView()
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
        [HttpPost]
        public ActionResult Agregar(TCliente cliente)
        {

            ViewBag.Categorias = new SelectList(_TCliente.Categorias(), "Id_Categoria", "Categoria", "Id_Categoria");
            var Nombre = cliente.Nombre;
            var RNC = cliente.RNC;
            var Telefono = cliente.Telefono;
            var Correo = cliente.Correo;
            var Categoria = cliente.Id_Categoria.ToString();

            if (!string.IsNullOrEmpty(Nombre) && !string.IsNullOrEmpty(RNC) && !string.IsNullOrEmpty(Categoria) && !string.IsNullOrEmpty(Telefono) && !string.IsNullOrEmpty(Correo))
            {
                cliente.Categoria = _TCliente.Categorias().Find(x => x.Id_Categoria.ToString() == cliente.Categoria).Categoria;
                _TCliente.Guardar(cliente);
                return Principal();
            }
            return PartialView("../Cliente/Partials/AgregarPartial");
        }
        public ActionResult Editar(TCliente cliente)
        {
            var Nombre = cliente.Nombre;
            var RNC = cliente.RNC;
            var Telefono = cliente.Telefono;
            var Correo = cliente.Correo;
            var Categoria = cliente.Categoria;

            if (!string.IsNullOrEmpty(Nombre) && !string.IsNullOrEmpty(RNC) && !string.IsNullOrEmpty(Telefono) 
                && !string.IsNullOrEmpty(Correo) && !string.IsNullOrEmpty(Categoria))
            {
                _TCliente.Editar(cliente);
                return Principal();
            }
            return PartialView("../Cliente/Partials/EditarPartial");
        }

        [HttpPost]
        public ActionResult Eliminar(int? id)
        {
            if (id > 0)
            {
                _TCliente.Eliminar((int)id);
                return Principal();
            }
            return RedirectToAction("../Cliente/Partials/Eliminar");
        }
        [HttpGet]
        public ActionResult GetID(int? ID)
        {
            var lista = _TCliente.Listar();
            TCliente cliente = lista.ToList().Find(x => x.Id_Cliente == ID);
            ViewBag.Categorias = new SelectList(_TCliente.Categorias(), "Id_Categoria", "Categoria", "Id_Categoria");

            if (cliente == null)
            {
                return HttpNotFound();
            }
            return PartialView("../Cliente/Partials/EditarPartial", cliente);
        }
        [HttpGet]
        public ActionResult EliminarID(int? ID)
        {
            var lista = _TCliente.Listar();
            TCliente cliente = lista.ToList().Find(x => x.Id_Cliente == ID);
           
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return PartialView("../Cliente/Partials/Eliminar", cliente);
        }
    }
}