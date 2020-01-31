using CopaFilmes.Domain.Services;
using Xunit;

namespace CopaFilmes.Test
{
    public class RealizarCampeonatoServiceTest
    {
        [Fact]
        public void Vingadores_Primeiro_Lugar_Os_Incriveis_Em_Segundo()
        {
            var filmes = FilmesFactory.PrimeiroOitoFilmes();

            var resultado = new RealizarCampeonatoService().RelizarCampeonato(filmes);

            Assert.Equal("Vingadores: Guerra Infinita", resultado.Vencedor.Titulo);
            Assert.Equal("Os Incríveis 2", resultado.Derrotado.Titulo);
        }
    }
}
