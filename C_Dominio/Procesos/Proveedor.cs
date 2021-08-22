using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_Datos;

namespace C_Dominio
{
    public class Proveedor
    {
       
        readonly SistemaFacturacionEntities db = new SistemaFacturacionEntities();

        public void Guardar(TProveedor model)
        {
            db.TProveedors.Add(model);
            db.Entry(model).State = EntityState.Added;
            db.SaveChanges();
        }
        public List<TProveedor> Listar()
        {
            return db.TProveedors.ToList();
        }
        public void Editar(TProveedor Element)
        {
            var proveedor = new TProveedor();
            using (var context = new SistemaFacturacionEntities())
            {
                proveedor = (context.TProveedors.Where(a => a.Id_Proveedor == Element.Id_Proveedor)).SingleOrDefault();
            }

            if (proveedor != null)
            {
                proveedor.Nombre = Element.Nombre;
                proveedor.RNC = Element.RNC;
                proveedor.Telefono = Element.Telefono;
                proveedor.Correo = Element.Correo;
            }

            using (var dbcontext = new SistemaFacturacionEntities())
            {
                if (proveedor != null)
                {
                    dbcontext.Entry(proveedor).State = EntityState.Modified;
                    dbcontext.SaveChanges();
                }
            }
        }
        public void Eliminar(int index)
        {
            using (SistemaFacturacionEntities Context = new SistemaFacturacionEntities())
            {
                TProveedor proveedor = new TProveedor { Id_Proveedor = index };
                Context.Entry(proveedor).State = EntityState.Deleted;
                Context.SaveChanges();
            }
        }
    }
}
