using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea2Listas
{
    public class ListaEnlazada
    {
        public Nodo cabeza;
        public Nodo cola;
        public int tamano;

        public ListaEnlazada()
        {
            cabeza = null;
            cola = null;
            tamano = 0;
        }

        public void AgregarNodoFinal(int dato)
        {
            tamano = tamano + 1;
            Nodo nuevoNodo = new Nodo(dato);
            if (cabeza == null)
            {
                cabeza = nuevoNodo;
                cola = nuevoNodo;
            }
            else
            {

            }
        }
    }
}
