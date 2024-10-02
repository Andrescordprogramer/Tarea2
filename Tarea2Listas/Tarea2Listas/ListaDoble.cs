using Tarea2Listas;

// Clase que representa una lista doblemente enlazada
public class ListaDoble
{
    public Nodo cabeza; // Primer nodo de la lista
    public Nodo cola; // Último nodo de la lista
    public int tamano; // Tamaño de la lista
    private Nodo medio; // Para guardar la referencia al nodo medio

    // Constructor de la clase ListaDoble
    public ListaDoble()
    {
        cabeza = null;
        cola = null;
        tamano = 0;
        medio = null;
    }

    // Método privado para actualizar la referencia del nodo medio
    private void ActualizarMedio()
    {
        int medioIndex = tamano / 2;
        Nodo actual = cabeza;
        for (int i = 0; i < medioIndex; i++)
        {
            actual = actual.Siguiente;
        }
        medio = actual;
    }

    // Método para insertar un valor en orden en la lista
    public void InsertInOrder(int value)
    {
        Nodo nuevoNodo = new Nodo(value);

        if (cabeza == null)
        {
            cabeza = nuevoNodo;
            cola = nuevoNodo;
        }
        else if (cabeza.Valor >= value)
        {
            nuevoNodo.Siguiente = cabeza;
            cabeza.Anterior = nuevoNodo;
            cabeza = nuevoNodo;
        }
        else
        {
            Nodo aux = cabeza;
            while (aux.Siguiente != null && aux.Siguiente.Valor < value)
            {
                aux = aux.Siguiente;
            }
            if (aux.Siguiente == null)
            {
                aux.Siguiente = nuevoNodo;
                nuevoNodo.Anterior = aux;
                cola = nuevoNodo;
            }
            else
            {
                aux.Siguiente.Anterior = nuevoNodo;
                nuevoNodo.Siguiente = aux.Siguiente;
                aux.Siguiente = nuevoNodo;
                nuevoNodo.Anterior = aux;
            }
        }
        tamano++;
        ActualizarMedio();
    }

    // Método para añadir un nodo al final de la lista
    public void AddLast(int Value)
    {
        Nodo nuevoNodo = new Nodo(Value);

        if (cabeza == null)
        {
            cabeza = nuevoNodo;
            cola = nuevoNodo;
        }
        else
        {
            cola.Siguiente = nuevoNodo;
            nuevoNodo.Anterior = cola;
            cola = nuevoNodo;
        }
    }

    // Método para eliminar el primer nodo de la lista
    public int DeleteFirst()
    {
        int eliminado = cabeza.Valor;
        cabeza = cabeza.Siguiente;
        cabeza.Anterior = null;
        tamano--;
        ActualizarMedio();
        return eliminado;
    }

    // Método para eliminar el último nodo de la lista
    public int DeleteLast()
    {
        int eliminado = cola.Valor;
        cola = cola.Anterior;
        cola.Siguiente = null;
        tamano--;
        ActualizarMedio();
        return eliminado;
    }

    // Método para eliminar un nodo con un valor específico de la lista
    public bool DeleteValue(int value)
    {
        Nodo aux = cabeza;

        while (aux.Siguiente != null && aux.Siguiente.Valor != value)
        {
            aux = aux.Siguiente;
        }

        if (aux.Siguiente == null)
        {
            return false;
        }
        else
        {
            if (aux.Siguiente.Siguiente == null)
            {
                cola = aux;
                aux.Siguiente = null;
            }
            else
            {
                aux.Siguiente = aux.Siguiente.Siguiente;
                aux.Siguiente.Anterior = aux;
            }
            tamano--;
            ActualizarMedio();
            return true;
        }
    }

    // Método para invertir la lista
    public void Invertir()
    {
        if (cabeza == null || cabeza.Siguiente == null)
        {
            return;
        }

        Nodo actual = cabeza;
        Nodo temporal = null;

        // Intercambiamos los punteros de 'Siguiente' y 'Anterior' de todos los nodos.
        while (actual != null)
        {
            temporal = actual.Anterior;
            actual.Anterior = actual.Siguiente;
            actual.Siguiente = temporal;
            actual = actual.Anterior; // Avanzamos al siguiente nodo (antes era Anterior).
        }

        // Intercambiamos la cabeza y la cola.
        temporal = cabeza;
        cabeza = cola;
        cola = temporal;

        // Actualizamos la referencia al nodo medio después de la inversión.
        ActualizarMedio();
    }

    // Método para obtener el valor del nodo medio
    public int GetMiddle()
    {
        if (medio == null) throw new InvalidOperationException("La lista está vacía");
        return medio.Valor;
    }

    // Método para fusionar dos listas ordenadas en una nueva lista ordenada
    public void MergeSorted(ListaDoble listA, ListaDoble listB, SortDirection direction)
    {
        if (listA == null || listB == null)
        {
            throw new ArgumentNullException("listA y listB no pueden estar vacias");
        }

        if (direction == SortDirection.Ascending)
        {
            ListaDoble mergedList = new ListaDoble();

            Nodo currentA = listA.cabeza;
            Nodo currentB = listB.cabeza;

            while (currentA != null && currentB != null)
            {
                if (currentA.Valor <= currentB.Valor)
                {
                    mergedList.AddLast(currentA.Valor);
                    currentA = currentA.Siguiente;
                }
                else
                {
                    mergedList.AddLast(currentB.Valor);
                    currentB = currentB.Siguiente;
                }
            }

            while (currentA != null)
            {
                mergedList.AddLast(currentA.Valor);
                currentA = currentA.Siguiente;
            }

            while (currentB != null)
            {
                mergedList.AddLast(currentB.Valor);
                currentB = currentB.Siguiente;
            }

            cabeza = mergedList.cabeza;
            cola = mergedList.cola;
            tamano = mergedList.tamano;
            medio = mergedList.medio;
        }
        else if (direction == SortDirection.Descending)
        {
            ListaDoble mergedList = new ListaDoble();
            mergedList.MergeSorted(listA, listB, SortDirection.Ascending);
            mergedList.Invertir();
            listA.cabeza = mergedList.cabeza;
            listA.cola = mergedList.cola;
            listA.tamano = mergedList.tamano;
            listA.medio = mergedList.medio;
        }
    }
}
