using CopaFilmes.Domain.Notifications;
using System.Collections.Generic;

namespace CopaFilmes.WebApi.Messages.Filme.Response
{
    public class FilmeResponse 
    {
        public List<FilmeDto> Filmes { get; set; }
    }
}
