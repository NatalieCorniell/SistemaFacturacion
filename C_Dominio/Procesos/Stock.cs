using C_Datos;
using C_Datos.DTOS;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Dominio.Procesos
{
    public class Stock
    {

        readonly SistemaFacturacionEntities db = new SistemaFacturacionEntities();

        public void Guardar(TStockProduct model)
        {

            db.TStockProducts.Add(model);
            GuardarEntrada(model);
            db.Entry(model).State = EntityState.Added;
            db.SaveChanges();
        }
        public void GuardarEntrada(TStockProduct model)
        {
            var modelEntrada = db.TEntradas.Add(new TEntrada() { Id_Producto = model.Id_Producto, Id_Proveedor = model.Id_Proveedor, Cantidad = model.Cantidad, Fecha = (DateTime)model.Fecha });
          
            db.Entry(modelEntrada).State = EntityState.Added;
            db.SaveChanges();

        }
        /// <summary>
        /// Listar
        /// </summary>
        /// <returns></returns>
        public List<TStockProduct> Listar()
        {
            return db.TStockProducts.ToList();
        }
        /// <summary>
        /// Editar
        /// </summary>
        /// <param name="index"></param>
        /// <param name="Element"></param>
        public void Editar(TStockProduct Element)
        {
            var producto = new TStockProduct();
            using (var context = new SistemaFacturacionEntities())
            {
                producto = (context.TStockProducts.Where(a => a.Id_Producto == Element.Id_Producto)).SingleOrDefault();
            }

            if (producto != null)
            {
                producto.Cantidad += Element.Cantidad;
            }
            GuardarEntrada(Element);

            using (var dbcontext = new SistemaFacturacionEntities())
            {
                if (producto != null)
                {
                    dbcontext.Entry(producto).State = EntityState.Modified;
                    dbcontext.SaveChanges();
                }
            }
        }
        /// <summary>
        /// Eliminar
        /// </summary>
        /// <param name="index"></param>
        public void Eliminar(int index)
        {
            using (SistemaFacturacionEntities Context = new SistemaFacturacionEntities())
            {
                TStockProduct stock = new TStockProduct { Id_Stock = index };
                Context.Entry(stock).State = EntityState.Deleted;
                Context.SaveChanges();
            }
        }
        /// <summary>
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool ValidarExistencia(string producto, string proveedor)
        {
            var ProductInStoock = Listar().Find(x => x.Nombre_Producto == producto);

            if (ProductInStoock != null && ProductInStoock.Nombre_Proveedor == proveedor)
            {
                //Existe
                return true;
            }
            return false;
        }
        public void RefreshDB()
        {
            using (SistemaFacturacionEntities Context = new SistemaFacturacionEntities())
            {
                foreach (var entity in Context.ChangeTracker.Entries())
                {
                    entity.Reload();
                }
            }
        }
    }
}
