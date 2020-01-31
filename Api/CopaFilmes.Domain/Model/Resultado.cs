namespace CopaFilmes.Domain.Model
{
    public class Resultado
    {
        public Resultado(Filme vencedor, Filme derrotado)
        {
            Vencedor = vencedor;
            Derrotado = derrotado;
        }

        public Filme Vencedor { get; }

        public Filme Derrotado { get; }

        public static Resultado Criar(Filme primeiroLugar, Filme segundoLuga)
        {
            return new Resultado(primeiroLugar, segundoLuga);
        }
    }
}
