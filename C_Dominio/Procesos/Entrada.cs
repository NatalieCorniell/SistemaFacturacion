using C_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Dominio.Procesos
{
    public class Entrada
    {
        readonly SistemaFacturacionEntities db = new SistemaFacturacionEntities();

        public List<TEntrada> Listar()
        {
            return db.TEntradas.ToList();
        }
    }
}
