using C_Datos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Dominio.Procesos
{
    public class Cliente
    {

        readonly SistemaFacturacionEntities db = new SistemaFacturacionEntities();

        public void Guardar(TCliente model)
        {
            db.TClientes.Add(model);
            db.Entry(model).State = EntityState.Added;
            db.SaveChanges();
        }
        public List<TCliente> Listar()
        {
            return db.TClientes.ToList();
        }
        public void Editar(TCliente Element)
        {
            var cliente = new TCliente();
            using (var context = new SistemaFacturacionEntities())
            {
                cliente = (context.TClientes.Where(a => a.Id_Cliente == Element.Id_Cliente)).SingleOrDefault();
            }

            if (cliente != null)
            {
                cliente.Nombre = Element.Nombre;
                cliente.RNC = Element.RNC;
                cliente.Telefono = Element.Telefono;
                cliente.Correo = Element.Correo;
            }

            using (var dbcontext = new SistemaFacturacionEntities())
            {
                if (cliente != null)
                {
                    dbcontext.Entry(cliente).State = EntityState.Modified;
                    dbcontext.SaveChanges();
                }
            }
        }
        public void Eliminar(int index)
        {
            using (SistemaFacturacionEntities Context = new SistemaFacturacionEntities())
            {
                TCliente cliente = new TCliente { Id_Cliente = index };
                Context.Entry(cliente).State = EntityState.Deleted;
                Context.SaveChanges();
            }
        }
    }
}
