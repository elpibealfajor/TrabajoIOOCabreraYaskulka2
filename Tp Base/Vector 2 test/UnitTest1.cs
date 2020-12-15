using System;
using Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Vector2Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            float x = 5;
            float y = 10;

            Vector2 posicion = new Vector2(x, y);

            Assert.IsNotNull(posicion);
            Assert.AreEqual(x, posicion.X);
            Assert.AreEqual(y, posicion.Y);
        }

        [TestMethod]

        public void SumaDeVectores()
        {
            Vector2 vector1 = new Vector2(1, 1);
            Vector2 vector2 = new Vector2(9, 9);

            var resultado = vector1 + vector2;

            Assert.AreEqual(10, resultado.X);
            Assert.AreEqual(10, resultado.Y);
        }

        [TestMethod]

        public void VectoresIguales()
        {
            Vector2 vector = new Vector2(0, 0);

            var resultado = vector == Vector2.Zero;

            Assert.IsTrue(resultado);
        }

        [TestMethod]

        public void VectoresDistintos()
        {
            Vector2 vector = new Vector2(5, 15);

            var resultado = vector != Vector2.Zero;

            Assert.IsTrue(resultado);
        }

        [TestMethod]

        public void VectorToString()
        {
            Vector2 vector = new Vector2(5, 15);
            string valorEsperado = "(5, 15)";
            var resultado = vector.ToString();

            Assert.AreEqual(valorEsperado, resultado);

        }
    }
}