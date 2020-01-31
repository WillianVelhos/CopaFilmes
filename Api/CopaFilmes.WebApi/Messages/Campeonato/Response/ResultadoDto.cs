namespace CopaFilmes.WebApi.Messages.Campeonato.Response
{
    public class ResultadoDto
    {
        public FilmeDto Vencedor { get; set; }

        public FilmeDto Derrotado { get; set; }
    }
}
