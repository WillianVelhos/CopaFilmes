namespace CopaFilmes.Domain.Model
{
    public class Filme 
    {
        public Filme(string id, string titulo, int ano, decimal nota)
        {
            Id = id;
            Titulo = titulo;
            Ano = ano;
            Nota = nota;
        }

        public string Id { get; }

        public string Titulo { get; }

        public int Ano { get; }

        public decimal Nota { get; }
    }
}
