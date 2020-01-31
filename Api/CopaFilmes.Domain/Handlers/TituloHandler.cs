using CopaFilmes.Domain.Model;

namespace CopaFilmes.Domain.Handlers
{
    public class TituloHandler : IPartidaHandler
    {
        IPartidaHandler _next;

        public Resultado HandleRequest(Filme competidor1, Filme competidor2)
        {
            if (string.Compare(competidor1.Titulo, competidor2.Titulo) == -1)
            {
                return Resultado.Criar(competidor1, competidor2); ;
            }

            return Resultado.Criar(competidor2, competidor1); ;
        }

        public void RegisterNext(IPartidaHandler next)
        {
            _next = next;
        }
    }
}
