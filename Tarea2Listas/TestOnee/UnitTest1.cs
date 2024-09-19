using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tarea2Listas;

namespace TestOne
{
    [TestClass]
    public class UnitTest1
    {
        private ListaDoble lista;

        [TestInitialize]
        public void Configuracion()
        {
            lista = new ListaDoble();
        }

        [TestMethod]
        public void InsertarEnOrden_DebeInsertarEnOrdenAscendente()
        {
            lista.InsertInOrder(10);
            lista.InsertInOrder(5);
            lista.InsertInOrder(15);

            Assert.AreEqual(5, lista.cabeza.Valor);
            Assert.AreEqual(10, lista.cabeza.Siguiente.Valor);
            Assert.AreEqual(15, lista.cola.Valor);
        }

        [TestMethod]
        public void EliminarPrimero_DebeEliminarElPrimerElemento()
        {
            lista.InsertInOrder(10);
            lista.InsertInOrder(5);
            lista.InsertInOrder(15);

            int valorEliminado = lista.DeleteFirst();

            Assert.AreEqual(10, lista.cabeza.Valor);
            Assert.AreEqual(2, lista.tamano);
            Assert.AreEqual(5, valorEliminado);
        }

        [TestMethod]
        public void EliminarUltimo_DebeEliminarElUltimoElemento()
        {
            lista.InsertInOrder(10);
            lista.InsertInOrder(5);
            lista.InsertInOrder(15);

            int valorEliminado = lista.DeleteLast();

            Assert.AreEqual(10, lista.cola.Valor);
            Assert.AreEqual(2, lista.tamano);
            Assert.AreEqual(15, valorEliminado);
        }

        [TestMethod]
        public void EliminarValor_DebeEliminarUnValorEspecifico()
        {
            lista.InsertInOrder(10);
            lista.InsertInOrder(5);
            lista.InsertInOrder(15);

            bool resultado = lista.DeleteValue(10);

            Assert.IsTrue(resultado);
            Assert.AreEqual(2, lista.tamano);
            Assert.AreEqual(15, lista.cabeza.Siguiente.Valor);
        }

        [TestMethod]
        public void EliminarValor_DebeRetornarFalsoSiValorNoEncontrado()
        {
            lista.InsertInOrder(10);
            lista.InsertInOrder(5);
            lista.InsertInOrder(15);

            bool resultado = lista.DeleteValue(20);

            Assert.IsFalse(resultado);
            Assert.AreEqual(3, lista.tamano);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ObtenerMedio_DebeLanzarExcepcionSiEstaVacia()
        {
            lista.GetMiddle();
        }

        [TestMethod]
        public void ObtenerMedio_DebeRetornarElementoMedio()
        {
            lista.InsertInOrder(10);
            lista.InsertInOrder(5);
            lista.InsertInOrder(15);

            int valorMedio = lista.GetMiddle();

            Assert.AreEqual(10, valorMedio);
        }

        [TestMethod]
        public void Invertir_DebeInvertirLaLista()
        {
            lista.InsertInOrder(1);
            lista.InsertInOrder(2);
            lista.InsertInOrder(3);

            lista.Invertir();

            Assert.AreEqual(3, lista.cabeza.Valor);
            Assert.AreEqual(2, lista.cabeza.Siguiente.Valor);
            Assert.AreEqual(1, lista.cola.Valor);
        }

        [TestMethod]
        public void MezclarOrdenado_DebeMezclarDosListasEnOrdenAscendente()
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

            Assert.AreEqual(1, listaA.cabeza.Valor);
            Assert.AreEqual(2, listaA.cabeza.Siguiente.Valor);
            Assert.AreEqual(6, listaA.cola.Valor);
        }

        [TestMethod]
        public void MezclarOrdenado_DebeMezclarDosListasEnOrdenDescendente()
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

            Assert.AreEqual(6, listaA.cabeza.Valor);
            Assert.AreEqual(5, listaA.cabeza.Siguiente.Valor);
            Assert.AreEqual(1, listaA.cola.Valor);
        }
    }
}
