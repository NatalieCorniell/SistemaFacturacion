using C_Datos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Dominio.Procesos
{
    public class Factura
    {

        readonly SistemaFacturacionEntities db = new SistemaFacturacionEntities();

        public void Guardar(TFacturacion model)
        {
            db.TFacturacions.Add(model);
            db.Entry(model).State = EntityState.Added;
            db.SaveChanges();
        }
        public List<TFacturacion> Listar()
        {
            return db.TFacturacions.ToList();
        }
        //public List<TCategoria> Categorias()
        //{
        //    return db.TCategorias.ToList();
        //}
        //public void Editar(TFacturacion Element)
        //{
        //    var cliente = new TFacturacion();
        //    using (var context = new SistemaFacturacionEntities())
        //    {
        //        cliente = (context.TFacturacions.Where(a => a.Id_Factura == Element.Id_Factura)).SingleOrDefault();
        //    }

        //    if (cliente != null)
        //    {
        //        cliente.Nombre = Element.Nombre;
        //        cliente.RNC = Element.RNC;
        //        cliente.Telefono = Element.Telefono;
        //        cliente.Correo = Element.Correo;
        //        cliente.Categoria = Element.Categoria;
        //    }

        //    using (var dbcontext = new SistemaFacturacionEntities())
        //    {
        //        if (cliente != null)
        //        {
        //            dbcontext.Entry(cliente).State = EntityState.Modified;
        //            dbcontext.SaveChanges();
        //        }
        //    }
        //}
        //public void Eliminar(int index)
        //{
        //    using (SistemaFacturacionEntities Context = new SistemaFacturacionEntities())
        //    {
        //        TFacturacion cliente = new TFacturacion { Id_Cliente = index };
        //        Context.Entry(cliente).State = EntityState.Deleted;
        //        Context.SaveChanges();
        //    }
        //}
    }
}
