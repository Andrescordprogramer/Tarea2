using System.Security.Cryptography.X509Certificates;

public interface IList
{
    void InsertInOrder(int value);
    int DeleteFirst();
    int DeleteLast();
    bool DeleteValue(int value);
    int GetMiddle();
    void MergeSorted(IList listA, IList listB, SortDirection direction);
}


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


public class ListaDoble : IList
{
    private Nodo cabeza;
    private Nodo cola;
    private Nodo medio;
    private int contador;

    public ListaDoble()
    {
        cabeza = null;
        cola = null;
        medio = null;
        contador = 0;
    }

    public void InsertInOrder(int value)
    {
        Nodo newNode = new Nodo(value);

        if (head == null)
        {
            head = tail = middle = newNode;
        }
        else
        {
            Nodo current = head;
            while (current != null && current.Value < value)
            {
                current = current.Next;
            }

            if (current == head)
            {
                // Insertar al inicio
                newNode.Next = head;
                head.Prev = newNode;
                head = newNode;
            }
            else if (current == null)
            {
                // Insertar al final
                tail.Next = newNode;
                newNode.Prev = tail;
                tail = newNode;
            }
            else
            {
                // Insertar en medio
                newNode.Prev = current.Prev;
                newNode.Next = current;
                current.Prev.Next = newNode;
                current.Prev = newNode;
            }
        }

        count++;
        UpdateMiddle();
    }

    private void UpdateMiddle()
    {
        middle = head;
        for (int i = 0; i < count / 2; i++)
        {
            middle = middle.Next;
        }
    }

}


/*    using System;
namespace ListasEnlazadas
{
    public enum SortDirection
    {
        Ascendente,
        Descendente
    }

    public interface ILista
    {
        void InsertInOrder(int value); // Inserta un valor en orden ascendente
        int DeleteFirst(); // Elimina el primer nodo de la lista y devuelve su valor
        int DeleteLast(); // Elimina el último nodo de la lista y devuelve su valor
        bool DeleteValue(int value); // Elimina un valor específico de la lista
        int GetMiddle(); // Obtiene el elemento del medio de la lista
        void MergeSorted(ILista listA, ILista listB, SortDirection direction); // Mezcla dos listas ordenadas
    }

    public class Nodo
    {
        public int valor;
        public Nodo anterior;
        public Nodo siguiente;

        public Nodo(int valor)
        {
            this.valor = valor;
            this.anterior = null;
            this.siguiente = null;
        }
    }

    public class ListaDoble : ILista
    {
        private Nodo cabeza;
        private Nodo cola;
        private Nodo medio;
        private int tamaño;

        public ListaDoble()
        {
            cabeza = null;
            cola = null;
            medio = null;
            tamaño = 0;
        }

        public void InsertInOrder(int value)
        {
            Nodo nuevo = new Nodo(value);

            // Caso especial: la lista está vacía
            if (cabeza == null)
            {
                cabeza = cola = medio = nuevo;
                tamaño++;
                return;
            }

            // Caso especial: insertar antes de la cabeza
            if (value <= cabeza.valor)
            {
                nuevo.siguiente = cabeza;
                cabeza.anterior = nuevo;
                cabeza = nuevo;
            }
            // Caso especial: insertar después de la cola
            else if (value >= cola.valor)
            {
                nuevo.anterior = cola;
                cola.siguiente = nuevo;
                cola = nuevo;
            }
            // Caso general: insertar en medio
            else
            {
                Nodo actual = cabeza;
                while (actual != null && actual.valor < value)
                {
                    actual = actual.siguiente;
                }

                nuevo.anterior = actual.anterior;
                nuevo.siguiente = actual;
                actual.anterior.siguiente = nuevo;
                actual.anterior = nuevo;
            }

            tamaño++;
            ActualizarMedio();
        }

        public int DeleteFirst()
        {
            if (cabeza == null)
                throw new InvalidOperationException("La lista está vacía");

            int valor = cabeza.valor;

            if (cabeza == cola)
            {
                cabeza = cola = medio = null;
            }
            else
            {
                cabeza = cabeza.siguiente;
                cabeza.anterior = null;
            }

            tamaño--;
            ActualizarMedio();
            return valor;
        }

        public int DeleteLast()
        {
            if (cola == null)
                throw new InvalidOperationException("La lista está vacía");

            int valor = cola.valor;

            if (cabeza == cola)
            {
                cabeza = cola = medio = null;
            }
            else
            {
                cola = cola.anterior;
                cola.siguiente = null;
            }

            tamaño--;
            ActualizarMedio();
            return valor;
        }

        public bool DeleteValue(int value)
        {
            if (cabeza == null)
                throw new InvalidOperationException("La lista está vacía");

            Nodo actual = cabeza;

            while (actual != null)
            {
                if (actual.valor == value)
                {
                    if (actual == cabeza)
                    {
                        DeleteFirst();
                    }
                    else if (actual == cola)
                    {
                        DeleteLast();
                    }
                    else
                    {
                        actual.anterior.siguiente = actual.siguiente;
                        actual.siguiente.anterior = actual.anterior;
                        tamaño--;
                        ActualizarMedio();
                    }
                    return true;
                }
                actual = actual.siguiente;
            }

            return false;
        }

        public int GetMiddle()
        {
            if (medio == null)
                throw new InvalidOperationException("La lista está vacía");

            return medio.valor;
        }

        public void MergeSorted(ILista listA, ILista listB, SortDirection direction)
        {
            if (listA == null || listB == null)
                throw new ArgumentNullException("Las listas no pueden ser nulas");

            ListaDoble listaA = listA as ListaDoble;
            ListaDoble listaB = listB as ListaDoble;

            if (listaA == null || listaB == null)
                throw new ArgumentException("Los argumentos deben ser de tipo ListaDoble");

            Nodo actualA = listaA.cabeza;
            Nodo actualB = listaB.cabeza;

            ListaDoble nuevaLista = new ListaDoble();

            // Mezclar en orden ascendente o descendente
            while (actualA != null && actualB != null)
            {
                if ((direction == SortDirection.Ascendente && actualA.valor <= actualB.valor) ||
                    (direction == SortDirection.Descendente && actualA.valor >= actualB.valor))
                {
                    nuevaLista.InsertInOrder(actualA.valor);
                    actualA = actualA.siguiente;
                }
                else
                {
                    nuevaLista.InsertInOrder(actualB.valor);
                    actualB = actualB.siguiente;
                }
            }

            // Insertar los elementos restantes
            while (actualA != null)
            {
                nuevaLista.InsertInOrder(actualA.valor);
                actualA = actualA.siguiente;
            }

            while (actualB != null)
            {
                nuevaLista.InsertInOrder(actualB.valor);
                actualB = actualB.siguiente;
            }

            // Reemplazar la lista original con la nueva lista
            listaA.cabeza = nuevaLista.cabeza;
            listaA.cola = nuevaLista.cola;
            listaA.tamaño = nuevaLista.tamaño;
            listaA.medio = nuevaLista.medio;
        }

        // Método para actualizar el nodo medio en base al tamaño
        private void ActualizarMedio()
        {
            if (tamaño == 0)
            {
                medio = null;
            }
            else
            {
                Nodo actual = cabeza;
                for (int i = 0; i < tamaño / 2; i++)
                {
                    actual = actual.siguiente;
                }
                medio = actual;
            }
        }

        public Nodo GetHead()
        {
            return cabeza;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Crear dos listas doblemente enlazadas
            ListaDoble listA = new ListaDoble();
            ListaDoble listB = new ListaDoble();

            // Insertar valores en la lista A en orden ascendente
            listA.InsertInOrder(10);
            listA.InsertInOrder(2);
            listA.InsertInOrder(6);
            listA.InsertInOrder(25);
            listA.InsertInOrder(0);

            Console.WriteLine("Lista A en orden:");
            ImprimirLista(listA);

            // Insertar valores en la lista B en orden ascendente
            listB.InsertInOrder(11);
            listB.InsertInOrder(3);
            listB.InsertInOrder(7);
            listB.InsertInOrder(40);
            listB.InsertInOrder(50);

            Console.WriteLine("Lista B en orden:");
            ImprimirLista(listB);

            // Mezclar las listas A y B en orden ascendente
            Console.WriteLine("Mezclando las listas A y B en orden ascendente...");
            listA.MergeSorted(listA, listB, SortDirection.Ascendente);

            Console.WriteLine("Lista A después de mezclar en orden ascendente:");
            ImprimirLista(listA);

            // Eliminar el primer y último elemento
            Console.WriteLine($"Eliminando el primer elemento: {listA.DeleteFirst()}");
            Console.WriteLine($"Eliminando el último elemento: {listA.DeleteLast()}");

            Console.WriteLine("Lista A después de eliminar primer y último elemento:");
            ImprimirLista(listA);

            // Obtener el elemento medio
            Console.WriteLine($"El elemento medio es: {listA.GetMiddle()}");

            // Invertir la lista
            Console.WriteLine("Invirtiendo la lista A...");
            //InvertirLista(listA);

            Console.WriteLine("Lista A después de invertir:");
            ImprimirLista(listA);

            // Probar eliminación de un valor
            int valorEliminar = 6;
            Console.WriteLine($"Eliminando el valor {valorEliminar}: {listA.DeleteValue(valorEliminar)}");

            Console.WriteLine("Lista A después de eliminar el valor:");
            ImprimirLista(listA);
        }

        // Método auxiliar para imprimir la lista
        static void ImprimirLista(ListaDoble lista)
        {
            try
            {
                Nodo actual = lista.GetHead(); // Método auxiliar para obtener la cabeza de la lista (puedes implementarlo)
                while (actual != null)
                {
                    Console.Write(actual.valor + " ");
                    actual = actual.siguiente;
                }
                Console.WriteLine();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

         Método auxiliar para invertir la lista (usando el método DeleteLast para simplificar)
        static void InvertirLista(ListaDoble lista)
        {
            ListaDoble nuevaLista = new ListaDoble();
            while (true)
            {
                try
                {
                    nuevaLista.InsertInOrder(lista.DeleteLast());
                }
                catch (InvalidOperationException)
                {
                    break; // Cuando la lista original esté vacía, salimos del ciclo
                }
            }

            // Copiamos los valores de la lista invertida a la original
            while (true)
            {
                try
                {
                    lista.InsertInOrder(nuevaLista.DeleteFirst());
                }
                catch (InvalidOperationException)
                {
                    break; // Cuando la nueva lista esté vacía, salimos del ciclo
                }
            }
        }
    }
}*/