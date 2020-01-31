using CopaFilmes.Domain.Model;

namespace CopaFilmes.Domain.Handlers
{
    public interface IPartidaHandler
    {
        Resultado HandleRequest(Filme filme1, Filme Filme2);

        void RegisterNext(IPartidaHandler next);
    }
}
