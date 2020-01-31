using CopaFilmes.Domain.Model;

namespace CopaFilmes.Domain.Handlers
{
    public class NotaHandler : IPartidaHandler
    {
        IPartidaHandler _next;

        public Resultado HandleRequest(Filme competidor1, Filme competidor2)
        {
            if (competidor1.Nota > competidor2.Nota)
                return Resultado.Criar(competidor1, competidor2);
            else if (competidor1.Nota < competidor2.Nota)
                return Resultado.Criar(competidor2, competidor1); ;

            return _next.HandleRequest(competidor1, competidor2);
        }

        public void RegisterNext(IPartidaHandler next)
        {
            _next = next;
        }
    }
}
