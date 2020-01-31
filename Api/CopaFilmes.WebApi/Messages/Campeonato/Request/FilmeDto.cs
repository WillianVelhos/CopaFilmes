using System.ComponentModel.DataAnnotations;

namespace CopaFilmes.WebApi.Messages.Campeonato.Request 
{
    public class FilmeDto
    {
        [Required]
        [Display(Name = "Id")]
        public string Id { get; set; }

        [Required]
        [Display(Name = "Titulo")]
        public string Titulo { get; set; }

        [Required]
        [Display(Name = "Ano")]
        public int Ano { get; set; }

        [Required]
        [Display(Name = "Nota")]
        public decimal Nota { get; set; }
    }
}
