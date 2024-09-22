using Tarea2Listas;

public class ListaDoble
{
    public Nodo cabeza;
    public Nodo cola;
    public int tamano;
    private Nodo medio; // Para guardar la referencia al nodo medio

    public ListaDoble()
    {
        cabeza = null;
        cola = null;
        tamano = 0;
        medio = null;
    }

    private void ActualizarMedio()
    {
        // Actualiza la referencia del nodo medio
        int medioIndex = tamano / 2;
        Nodo actual = cabeza;
        for (int i = 0; i < medioIndex; i++)
        {
            actual = actual.Siguiente;
        }
        medio = actual;
    }

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
        else //cabeza.valor < value
        {
            Nodo aux = cabeza;
            while(aux.Siguiente != null && aux.Siguiente.Valor < value)
            {
                aux = aux.Siguiente;
            }
            // aux es menor a value o es el último
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


    public int DeleteFirst()
    {
        int eliminado = cabeza.Valor;
        cabeza = cabeza.Siguiente;
        cabeza.Anterior = null;
        tamano--;
        ActualizarMedio();
        return eliminado;
    }

    public int DeleteLast()
    {
        int eliminado = cola.Valor;
        cola = cola.Anterior;
        cola.Siguiente = null;
        tamano--;
        ActualizarMedio();
        return eliminado;
    }

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


    public int GetMiddle()
    {
        if (medio == null) throw new InvalidOperationException("La lista está vacía");
        return medio.Valor;
    }

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
