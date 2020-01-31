using AutoMapper;
using CopaFilmes.Domain.Model;
using CopaFilmes.Domain.Services;
using CopaFilmes.WebApi.Messages.Campeonato.Request;
using CopaFilmes.WebApi.Messages.Campeonato.Response;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaFilmes.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CampeonatoController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly RealizarCampeonatoService _realizarCampeonatoService;

        public CampeonatoController(IMapper mapper, RealizarCampeonatoService realizarCampeonatoService)
        {
            _mapper = mapper;
            _realizarCampeonatoService = realizarCampeonatoService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CampeonatoRequest request)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(request);
            }

            var filmes = _mapper.Map<List<Filme>>(request.Filmes);

            var resultado = _realizarCampeonatoService.RelizarCampeonato(filmes);

            return Response(_mapper.Map<ResultadoDto>(resultado));
        }
    }
}
