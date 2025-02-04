using Testing.Models;

namespace TestProject1
{
    public class UnitTest1
    {
        private readonly Operacions _operacions = new Operacions();
        [Fact]
        public void Test1()
        {

        }
        [Theory]
        [InlineData(3, 2, 5)]
        [InlineData(-1, -1, -2)]
        [InlineData(0, 5, 5)]
        public void SumarTesting(int a, int b, int c)
        {
            int resultado=Operacions.Sumar(a, b);
            Assert.Equal(c, resultado);
        }

        [Theory]
        [InlineData(5, 2, 3)]
        [InlineData(-3, -1, -2)]
        [InlineData(0, 1, -1)]
        public void RestarTesting(int a, int b, int c)
        {
            int resultado = Operacions.Restar(a, b);
            Assert.Equal(c, resultado);
        }

        [Theory]
        [InlineData(3, 2, 6)]
        [InlineData(-1, -1, 1)]
        [InlineData(0, 5, 0)]
        public void MultiplicarTesting(int a, int b, int c)
        {
            int resultado = Operacions.Multiplicar(a, b);
            Assert.Equal(c, resultado);
        }

        [Fact]
        public void DividirEntreCero()
        {
            var ex = Record.Exception(() => Operacions.Dividir(5, 0));
            Assert.Null(ex);
        }
    }
}
