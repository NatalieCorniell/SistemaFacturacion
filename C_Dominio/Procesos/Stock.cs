using C_Datos;
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
            db.Entry(model).State = EntityState.Added;
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
                producto = (context.TStockProducts.Where(a => a.Id_Stock == Element.Id_Stock)).SingleOrDefault();
            }

            if (producto != null)
            {
                producto.Id_Producto = Element.Id_Producto;
                producto.Cantidad = Element.Cantidad;
            }

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
                TStockProduct producto = new TStockProduct { Id_Producto = index };
                Context.Entry(producto).State = EntityState.Deleted;
                Context.SaveChanges();
            }
        }
        /// <summary>
        /// in testing....
        /// </summary>
        /// <param name="list"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public TStockProduct GetElement(List<TStockProduct> list, int index)
        {
            return list[index];
        }
    }
}
