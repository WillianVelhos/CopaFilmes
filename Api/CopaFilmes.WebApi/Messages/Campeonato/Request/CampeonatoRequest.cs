using CopaFilmes.WebApi.Data_Annotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CopaFilmes.WebApi.Messages.Campeonato.Request
{
    public class CampeonatoRequest
    {
        [Required]
        [Display(Name = "Filmes")]
        [EnsureEightElement(ErrorMessage = "É obrigatório enviar 8 filmes.")]
        public ICollection<FilmeDto> Filmes { get; set; }
    }
}
