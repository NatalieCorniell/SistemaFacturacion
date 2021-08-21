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
    public class StockController : Controller
    {

        readonly Stock stock = new Stock();
        // GET: producto
        public ActionResult Principal()
        {
            var Lista = new List<Dto_Producto>();
            var model = stock.Listar();
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
            var model = stock.Listar();
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
                stock.Guardar(producto);
                return Principal();
            }
            return PartialView("../Stock/Partials/AgregarPartial");
        }
        public ActionResult Editar(TProducto producto)
        {
            var id = producto.Id_Producto;
            var Nombre = producto.Nombre;
            var precio = producto.Precio;

            if (!string.IsNullOrEmpty(Nombre) && id > 0 && !string.IsNullOrEmpty(precio.ToString()))
            {
                stock.Editar(producto);
                return Principal();
            }
            return PartialView("../Stock/Partials/EditarPartial");
        }

        [HttpPost]
        public ActionResult Eliminar(int? id)
        {
            if (id > 0)
            {
                stock.Eliminar((int)id);
                return Principal();
            }
            return PartialView("../Stock/Partials/EliminarPartial");
        }
        [HttpGet]
        public ActionResult GetID(int? ID)
        {
            var lista = stock.Listar();
            TProducto T_producto = lista.ToList().Find(x => x.Id_Producto == ID);
            if (T_producto == null)
            {
                return HttpNotFound();
            }
            return PartialView("../Stock/Partials/EditarPartial", T_producto);
        }
        [HttpGet]
        public ActionResult EliminarID(int? ID)
        {
            var lista = stock.Listar();
            TProducto T_producto = lista.ToList().Find(x => x.Id_Producto == ID);
            if (T_producto == null)
            {
                return HttpNotFound();
            }
            return PartialView("../Stock/Partials/EliminarPartial", T_producto);
        }
        public TProducto GetElement(List<TProducto> list, int index)
        {
            return list[index - 1];
        }
    }
}