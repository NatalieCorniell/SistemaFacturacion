using C_Datos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Dominio.Procesos
{
    public class Mercancia
    {

        readonly SistemaFacturacionEntities db = new SistemaFacturacionEntities();

        public void Guardar(TProducto model)
        {
            db.TProductoes.Add(model);
            db.Entry(model).State = EntityState.Added;
            db.SaveChanges();
        }
        /// <summary>
        /// Listar
        /// </summary>
        /// <returns></returns>
        public List<TProducto> Listar()
        {
            return db.TProductoes.ToList();
        }
        /// <summary>
        /// Editar
        /// </summary>
        /// <param name="index"></param>
        /// <param name="Element"></param>
        public void Editar(TProducto Element)
        {
            var producto = new TProducto();
            using (var context = new SistemaFacturacionEntities())
            {
                producto = (context.TProductoes.Where(a => a.Id_Producto == Element.Id_Producto)).SingleOrDefault();
            }

            if (producto != null)
            {
                producto.Nombre = Element.Nombre;
                producto.Precio = Element.Precio;
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
                TProducto producto = new TProducto { Id_Producto = index };
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
        public TProducto GetElement(List<TProducto> list, int index)
        {
            return list[index];
        }
    }
}
