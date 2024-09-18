namespace Tarea2Listas
{
    public interface IList
    {
        void InsertInOrder(int value);
        int DeleteFirst();
        int DeleteLast();
        bool DeleteValue(int value);
        int GetMiddle();
        void MergeSorted(IList listA, IList listB, SortDirection direction);
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
        }

        public static string Mostrar()
        {
            return "Hello Mufasa";
        }

    }
}