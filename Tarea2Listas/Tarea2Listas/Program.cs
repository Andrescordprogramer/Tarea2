namespace Tarea2Listas
{
    public interface IList 
    {
        void InsertInOrder(int value);
        int DeleteFirst();
        int DeleteLast();
        bool DeleteValue(int value);
        int GetMiddle();
        void MergeSorted(ListaDoble listA, ListaDoble listB, SortDirection direction);
    }

    public enum SortDirection
    {
        Ascending,
        Descending
    }
    
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int a = 1;
            if (a == 1)
            {
                ListaDoble listaA = new ListaDoble();
                ListaDoble listaB = new ListaDoble();

                listaA.InsertInOrder(1);
                listaA.InsertInOrder(3);
                listaA.InsertInOrder(5);

                listaB.InsertInOrder(2);
                listaB.InsertInOrder(4);
                listaB.InsertInOrder(6);

                listaA.MergeSorted(listaA, listaB, SortDirection.Descending);

                // Imprimir todos los elementos de la lista
                Nodo current = listaA.cabeza;
                while (current != null)
                {
                    Console.WriteLine(current.Valor);
                    current = current.Siguiente;
                }
            }
            else
            {
                ListaDoble listaA = new ListaDoble();
                ListaDoble listaB = new ListaDoble();

                listaA.InsertInOrder(1);
                listaA.InsertInOrder(3);
                listaA.InsertInOrder(5);

                listaB.InsertInOrder(2);
                listaB.InsertInOrder(4);
                listaB.InsertInOrder(6);

                listaA.MergeSorted(listaA, listaB, SortDirection.Ascending);

                // Imprimir todos los elementos de la lista
                Nodo current = listaA.cabeza;
                while (current != null)
                {
                    Console.WriteLine(current.Valor);
                    current = current.Siguiente;
                }
            }
        }

    }
}