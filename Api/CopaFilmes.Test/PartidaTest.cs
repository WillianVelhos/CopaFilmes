using CopaFilmes.Domain.Model;
using Xunit;

namespace CopaFilmes.Test
{
    public class PartidaTest
    {
        [Fact]
        public void Vingadores_Com_Maior_Nota_Deve_Vencer_A_Partida()
        {
            var vingadores = new Filme("ttt", "Vingadores", 2018, 10);
            var batman = new Filme("aaa", "Batman", 2018, 9);

            var partida = new Partida(vingadores, batman);

            Assert.Equal("Vingadores", partida.Resultado.Vencedor.Titulo);
        }

        [Fact]
        public void Deadpool_Com_Maior_Nota_Deve_Vencer_A_Partida()
        {
            var Deadpool = new Filme("ttt", "Deadpool", 2018, 9);
            var batman = new Filme("aaa", "Batman", 2018, 5);

            var partida = new Partida(batman, Deadpool);

            Assert.Equal("Deadpool", partida.Resultado.Vencedor.Titulo);
        }

        [Fact]
        public void Batman_Deve_Vencer_A_Partid_Por_Causa_Ordem_Alfabetica()
        {
            var vingadores = new Filme("ttt", "Vingadores", 2018, 10);
            var batman = new Filme("aaa", "Batman", 2018, 10);

            var partida = new Partida(vingadores, batman);

            Assert.Equal("Batman", partida.Resultado.Vencedor.Titulo);
        }

        [Fact]
        public void Deadpool_Deve_Vencer_A_Partid_Por_Causa_Ordem_Alfabetica()
        {
            var Deadpool = new Filme("ttt", "Deadpool", 2018, 8);
            var vingadores = new Filme("aaa", "Vingadores", 2018, 8);

            var partida = new Partida(vingadores, Deadpool);

            Assert.Equal("Deadpool", partida.Resultado.Vencedor.Titulo);
        }
    }
}
