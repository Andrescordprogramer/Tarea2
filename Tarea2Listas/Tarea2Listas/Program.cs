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
        }
    }
}