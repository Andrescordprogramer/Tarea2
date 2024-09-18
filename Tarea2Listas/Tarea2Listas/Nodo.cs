using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea2Listas
{
    public class Nodo
    {
        public int Valor { get; set; }
        public Nodo Siguiente { get; set; }
        public Nodo Anterior { get; set; }

        public Nodo(int valor)
        {
            Valor = valor;
            Siguiente = null;
            Anterior = null;
        }
    }
}
