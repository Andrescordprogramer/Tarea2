namespace TestOnee
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string saludo = Tarea2Listas.Program.Mostrar();
            Assert.AreEqual("Hello Mufasa", saludo);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Tarea2Listas.ListaEnlazada lista = new Tarea2Listas.ListaEnlazada();
            lista.AgregarNodoFinal(5);
            Assert.AreEqual(1, lista.tamano);
        }
    }
}