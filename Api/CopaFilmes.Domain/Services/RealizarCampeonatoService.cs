using CopaFilmes.Domain.Model;
using System.Collections.Generic;
using System.Linq;

namespace CopaFilmes.Domain.Services
{
    public class RealizarCampeonatoService
    {
        public Resultado RelizarCampeonato(List<Filme> filmes)
        {
            filmes = filmes.OrderBy(x => x.Titulo).ToList();

            var fases = new List<List<Partida>>();

            fases.Add(CriarPrimeiraFaseEliminatoria(filmes));

            while (fases.Last().Count() != 1)
            {
                fases.Add(CriarProximaFase(fases.Last().Select(x => x.Resultado.Vencedor).ToList()));
            }

            return fases.Last().Last().Resultado;
        }

        private List<Partida> CriarPrimeiraFaseEliminatoria(List<Filme> filmes)
        {
            var primeiraFase = new List<Partida>();

            for (int i = 0; i < filmes.Count() / 2; i++)
                primeiraFase.Add(new Partida(filmes[i], filmes[filmes.Count() - (1 + i)]));

            return primeiraFase;
        }

        private List<Partida> CriarProximaFase(List<Filme> filmes)
        {
            var fase = new List<Partida>();

            for (int i = 0; i <= filmes.Count() / 2; i += 2)
                fase.Add(new Partida(filmes[i], filmes[i + 1]));

            return fase;
        }
    }
}
