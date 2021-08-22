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


namespace Presentacion.Controllers
{
    public class MercanciaController : Controller
    {

        readonly Mercancia Mercancia = new Mercancia();
        // GET: producto
        public ActionResult Principal()
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
            return View("MercanciaView", Lista);
        }
            public ActionResult MercanciaView()
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
            return View(Lista);
        }

        [HttpPost]
        public ActionResult Agregar(TProducto producto)
        {
            var Nombre = producto.Nombre;
            var Precio = producto.Precio;

            if (!string.IsNullOrEmpty(Nombre) && !string.IsNullOrEmpty(Precio.ToString()))
            {
                Mercancia.Guardar(producto);
                return Principal();
            }
            return PartialView("../Mercancia/Partials/AgregarPartial");
        }
        public ActionResult Editar(TProducto producto)
        {
            var id = producto.Id_Producto;
            var Nombre = producto.Nombre;
            var precio = producto.Precio;

            if (!string.IsNullOrEmpty(Nombre) && id > 0 && !string.IsNullOrEmpty(precio.ToString()))
            {
                Mercancia.Editar(producto);
                return Principal();
            }
            return PartialView("../Mercancia//Partials/EditarPartial");
        }

        [HttpPost]
        public ActionResult Eliminar(int? id)
        {
            if (id > 0)
            {
                Mercancia.Eliminar((int)id);
                return Principal();
            }
            return PartialView("../Mercancia/Partials/EliminarPartial");
        }
        [HttpGet]
        public ActionResult GetID(int? ID)
        {
            var lista = Mercancia.Listar();
            TProducto T_producto = lista.ToList().Find(x => x.Id_Producto == ID);
            if (T_producto == null)
            {
                return HttpNotFound();
            }
            return PartialView("../Mercancia/Partials/EditarPartial", T_producto);
        }
        [HttpGet]
        public ActionResult EliminarID(int? ID)
        {
            var lista = Mercancia.Listar();
            TProducto T_producto = lista.ToList().Find(x => x.Id_Producto == ID);
            if (T_producto == null)
            {
                return HttpNotFound();
            }
            return PartialView("../Mercancia/Partials/EliminarPartial", T_producto);
        }
    }
}