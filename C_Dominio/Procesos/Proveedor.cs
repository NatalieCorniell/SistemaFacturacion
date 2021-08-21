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
            db.SaveChanges();
        }
        public List<TProveedor> Listar()
        {
            return db.TProveedors.ToList();
        }
        public void Editar(int index, TProveedor Element)
        {
            db.TProveedors.ToList()[index] = Element;
            db.SaveChanges();
        }
        public void Eliminar(int index)
        {
            db.TProveedors.ToList().RemoveAt(index);
            db.SaveChanges();
        }
        /// <summary>
        /// in testing....
        /// </summary>
        /// <param name="list"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public TProveedor GetElement(List<TProveedor> list, int index)
        {
            return list[index];
        }
    }
}
