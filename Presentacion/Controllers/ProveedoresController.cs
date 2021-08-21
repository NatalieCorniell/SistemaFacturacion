using C_Datos;
using C_Datos.DTOS;
using C_Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Presentacion.Controllers
{
    public class ProveedoresController : Controller
    {
       
        readonly Proveedor Prov = new Proveedor();
        // GET: Proveedor
        public ActionResult Proveedor()
        {
            var Lista = new List<Dto_Proveedor>();
            var model = Prov.Listar();
            foreach (var item in model)
            {
                Dto_Proveedor dto_Proveedor = new Dto_Proveedor
                {
                    Id_Proveedor = item.Id_Proveedor,
                    Nombre = item.Nombre,
                    RNC = item.RNC,
                    Telefono = item.Telefono,
                    Correo = item.Correo
                };
                Lista.Add(dto_Proveedor);
            }
            return View(Lista);
        }
      
        [HttpPost]
        public ActionResult Agregar(TProveedor proveedor)
        {
            var Nombre = proveedor.Nombre;
            var RNC = proveedor.RNC;
            var Telefono = proveedor.Telefono;
            var Correo = proveedor.Correo;

            if (!string.IsNullOrEmpty(Nombre) && !string.IsNullOrEmpty(RNC) && !string.IsNullOrEmpty(Telefono) && !string.IsNullOrEmpty(Correo))
            {
                Prov.Guardar(proveedor);
                return View(Proveedor());
            }
            return PartialView("../Partials/AgregarPartial");
        }
        public ActionResult Editar(TProveedor proveedor)
        {
            var Nombre = proveedor.Nombre;
            var RNC = proveedor.RNC;
            var Telefono = proveedor.Telefono;
            var Correo = proveedor.Correo;

            if (!string.IsNullOrEmpty(Nombre) && !string.IsNullOrEmpty(RNC) && !string.IsNullOrEmpty(Telefono) && !string.IsNullOrEmpty(Correo))
            {
                Prov.Editar(proveedor.Id_Proveedor, proveedor);
                return View(Proveedor());
            }
            return PartialView("../Partials/EditarPartial");
        }

        [HttpPost]
        public ActionResult Eliminar(TProveedor model)
        {
            Prov.Eliminar(model.Id_Proveedor);

            return RedirectToAction("../Partials/EliminarPartial");
        }
        [HttpGet]
        public ActionResult GetID(int? ID)
        {
            var lista = Prov.Listar();
            TProveedor T_Proveedor = lista.ToList().Find(x => x.Id_Proveedor == ID);
            if (T_Proveedor == null)
            {
                return HttpNotFound();
            }
            return PartialView("../Partials/EditarPartial", T_Proveedor);
        }
        [HttpGet]
        public ActionResult EliminarID(int? ID)
        {
            var lista = Prov.Listar();
            TProveedor T_Proveedor = lista.ToList().Find(x => x.Id_Proveedor == ID);
            if (T_Proveedor == null)
            {
                return HttpNotFound();
            }
            return PartialView("../Partials/EliminarPartial", T_Proveedor);
        }
        public TProveedor GetElement(List<TProveedor> list, int index)
        {
            return list[index];
        }
    }
}
