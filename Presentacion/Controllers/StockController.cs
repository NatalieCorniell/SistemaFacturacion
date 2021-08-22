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
            var Lista = new List<Dto_Stock>();
            var model = stock.Listar();
            foreach (var item in model)
            {
                Dto_Stock Dto_Producto = new Dto_Stock
                {
                    Id_Producto = (int)item.Id_Producto,
                    Cantidad = (int)item.Cantidad
                };
                Lista.Add(Dto_Producto);
            }
            return View("MercanciaView", Lista);
        }
        public ActionResult StockView()
        {
            var Lista = new List<Dto_Stock>();
            var model = stock.Listar();
            foreach (var item in model)
            {
                Dto_Stock _Dto_Stock = new Dto_Stock
                {
                    Id_Producto = (int)item.Id_Producto,
                    Cantidad = (int)item.Cantidad
                };
                Lista.Add(_Dto_Stock);
            }
            return View(Lista);
        }

        [HttpPost]
        public ActionResult Agregar(TStockProduct stockProducto)
        {
            var Cantidad = stockProducto.Cantidad;

            if (Cantidad > 0)
            {
                stock.Guardar(stockProducto);
                return Principal();
            }
            return PartialView("../Stock/Partials/AgregarPartial");
        }
        public ActionResult Editar(TStockProduct stockProducto)
        {
            var Cantidad = stockProducto.Cantidad;

            if (Cantidad > 0)
            {
                stock.Editar(stockProducto);
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
            TStockProduct _TStockProduct = lista.ToList().Find(x => x.Id_Stock == ID);
            if (_TStockProduct == null)
            {
                return HttpNotFound();
            }
            return PartialView("../Stock/Partials/EditarPartial", _TStockProduct);
        }
        [HttpGet]
        public ActionResult EliminarID(int? ID)
        {
            var lista = stock.Listar();
            TStockProduct _TStockProduct = lista.ToList().Find(x => x.Id_Stock == ID);
            if (_TStockProduct == null)
            {
                return HttpNotFound();
            }
            return PartialView("../Stock/Partials/EliminarPartial", _TStockProduct);
        }
        public TProducto GetElement(List<TProducto> list, int index)
        {
            return list[index - 1];
        }
    }
}