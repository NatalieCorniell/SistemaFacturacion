﻿using C_Datos;
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
    public class FacturacionController : Controller
    {

        readonly Factura Factura = new Factura();
        readonly Stock stock = new Stock();


        // GET: producto
        //public ActionResult Principal()
        //{
        //    Factura.RefreshDB();
        //    var Lista = new List<Dto_Factura>();
        //    var model = Factura.Listar();
        //    foreach (var item in model)
        //    {
        //        Dto_Factura Dto_Producto = new Dto_Factura
        //        {
        //            Id_Producto = (int)item.Id_Producto,
        //            Cantidad = (int)item.Cantidad,
        //            Nombre_Proveedor = item.Nombre_Proveedor,
        //            Nombre_Producto = item.Nombre_Producto,
        //            Fecha = (DateTime)item.Fecha,
        //            Id_Factura = item.Id_Factura
        //        };
        //        Lista.Add(Dto_Producto);
        //    }
        //    return View("FacturaView", Lista);
        //}
        [HttpPost]
        private ActionResult Listado()
        {
            ViewBag.Productos = new SelectList(stock.Listar(), "Id_Producto", "Nombre", "Id_Producto");
            var Lista = new List<Dto_Factura>();

            var model = Factura.Listar();
            //foreach (var item in model)
            //{
            
            //    Lista.Add(Dto_Factura);
            //}
            //Dto_Factura Dto_Factura = new Dto_Factura
            //{
            //    Id_Factura = Lista.Id_Factura,
            //    Id_Producto = (int)item.Id_Producto,
            //    Cantidad = (int)item.Cantidad,
            //    Fecha = (DateTime)item.Fecha,
            //    Descuento = (double)item.Descuento,
            //    Categoria = item.Categoria,
            //    ITBIS = (double)item.ITBIS,
            //    Total = (double)item.Total,
            //    Nombre_Producto = stock.Listar().Find(x => x.Id_Producto == item.Id_Producto).Nombre_Producto
            //};
            return View();
        }

        public ActionResult FacturaView()
        {
            ViewBag.Productos = new SelectList(stock.Listar(), "Id_Producto", "Nombre_Producto", "Id_Producto");
            return View();
        }

        //[HttpPost]
        //public ActionResult Agregar(TFacturaProduct FacturaProducto)
        //{

        //    var cantidad = +FacturaProducto.Cantidad;

        //    ViewBag.Products = new SelectList(Mercancia.Listar(), "Id_Producto", "Nombre", "Id_Producto");
        //    ViewBag.Proveedores = new SelectList(Prov.Listar(), "Id_Proveedor", "Nombre", "Id_Proveedor");

        //    if (cantidad > 0 && FacturaProducto.Id_Proveedor > 0 && FacturaProducto.Id_Proveedor > 0)
        //    {
        //        FacturaProducto.Fecha = DateTime.Now;
        //        FacturaProducto.Nombre_Producto = Mercancia.Listar().Find(x => x.Id_Producto == FacturaProducto.Id_Producto).Nombre;
        //        FacturaProducto.Nombre_Proveedor = Prov.Listar().Find(x => x.Id_Proveedor == FacturaProducto.Id_Proveedor).Nombre;

        //        if (Factura.ValidarExistencia(FacturaProducto.Nombre_Producto, FacturaProducto.Nombre_Proveedor))
        //        {
        //            //Existe
        //            Factura.Editar(FacturaProducto);
        //            Factura.RefreshDB();
        //            return Principal();
        //        }
        //        Factura.Guardar(FacturaProducto);
        //        return Principal();
        //    }


        //    return PartialView("../Factura/Partials/AgregarPartial");
        //}

        //[HttpPost]
        //public ActionResult Eliminar(int? id)
        //{
        //    if (id > 0)
        //    {
        //        Factura.Eliminar((int)id);
        //        return Principal();
        //    }
        //    return PartialView("../Factura/Partials/EliminarPartial");
        //}

        //[HttpGet]
        //public ActionResult EliminarID(int? ID)
        //{
        //    var lista = Factura.Listar();
        //    TFacturaProduct _TFacturaProduct = lista.ToList().Find(x => x.Id_Factura == ID);
        //    if (_TFacturaProduct == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return PartialView("../Factura/Partials/EliminarPartial", _TFacturaProduct);
        //}
    }
}