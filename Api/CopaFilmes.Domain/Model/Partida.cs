using CopaFilmes.Domain.Handlers;

namespace CopaFilmes.Domain.Model
{
    public class Partida
    {
        public Partida(Filme competidor1, Filme competidor2)
        {
            Competidor1 = competidor1;
            Competidor2 = competidor2;

            Resultado = RealizarPartida();
        }

        public Filme Competidor1 { get; }

        public Filme Competidor2 { get; }

        public Resultado Resultado { get; }

        private Resultado RealizarPartida()
        {
            var validacaoNota = new NotaHandler();
            var validacaoTitulo = new TituloHandler();

            validacaoNota.RegisterNext(validacaoTitulo);

            return validacaoNota.HandleRequest(Competidor1, Competidor2);
        }
    }
}
