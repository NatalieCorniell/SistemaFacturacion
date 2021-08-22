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
        readonly Mercancia Mercancia = new Mercancia();
        readonly Proveedor Prov = new Proveedor();


        // GET: producto
        public ActionResult Principal()
        {
            stock.RefreshDB();
            var Lista = new List<Dto_Stock>();
            var model = stock.Listar();
            foreach (var item in model)
            {
                Dto_Stock Dto_Producto = new Dto_Stock
                {
                    Id_Producto = (int)item.Id_Producto,
                    Cantidad = (int)item.Cantidad,
                    Nombre_Proveedor = item.Nombre_Proveedor,
                    Nombre_Producto = item.Nombre_Producto,
                    Fecha = (DateTime)item.Fecha,
                    Id_Stock = item.Id_Stock
                };
                Lista.Add(Dto_Producto);
            }
            return View("StockView", Lista);
        }
      
        private List<Dto_Stock> Listado()
        {
            var Lista = new List<Dto_Stock>();
           
            var model = stock.Listar();
            foreach (var item in model)
            {
                Dto_Stock Dto_Stock = new Dto_Stock
                {
                    Id_Producto = (int)item.Id_Producto,
                    Nombre_Producto = Mercancia.Listar().Find(x => x.Id_Producto == item.Id_Producto).Nombre,
                    Id_Proveedor = Prov.Listar().Find(x => x.Id_Proveedor == item.Id_Proveedor).Id_Proveedor,
                    Nombre_Proveedor = Prov.Listar().Find(x => x.Id_Proveedor == item.Id_Proveedor).Nombre,
                    Cantidad = (int)item.Cantidad,
                    Fecha = (DateTime)item.Fecha,
                    Id_Stock = item.Id_Stock
                };
                Lista.Add(Dto_Stock);
            }
            return Lista;
        }

        public ActionResult StockView()
        {
            return View(Listado());
        }

        [HttpPost]
        public ActionResult Agregar(TStockProduct stockProducto)
        {
           
            var cantidad = +stockProducto.Cantidad;

            ViewBag.Products = new SelectList(Mercancia.Listar(), "Id_Producto", "Nombre", "Id_Producto");
            ViewBag.Proveedores = new SelectList(Prov.Listar(), "Id_Proveedor", "Nombre", "Id_Proveedor");

            if (cantidad > 0 && stockProducto.Id_Proveedor > 0 && stockProducto.Id_Proveedor > 0)
            {
                stockProducto.Fecha = DateTime.Now;
                stockProducto.Nombre_Producto = Mercancia.Listar().Find(x => x.Id_Producto == stockProducto.Id_Producto).Nombre;
                stockProducto.Nombre_Proveedor = Prov.Listar().Find(x => x.Id_Proveedor == stockProducto.Id_Proveedor).Nombre;

                if (stock.ValidarExistencia(stockProducto.Nombre_Producto, stockProducto.Nombre_Proveedor))
                {
                    //Existe
                    stock.Editar(stockProducto);
                    stock.RefreshDB();
                    return Principal();
                }
                stock.Guardar(stockProducto);
                return Principal();
            }


            return PartialView("../Stock/Partials/AgregarPartial");
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
    }
}