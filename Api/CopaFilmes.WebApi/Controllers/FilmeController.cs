using AutoMapper;
using CopaFilmes.Domain.Service;
using CopaFilmes.WebApi.Messages.Filme.Response;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaFilmes.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly IFilmeRepository _filmeRepository;

        public FilmeController(IMapper mapper, IFilmeRepository filmeRepository)
        {
            _mapper = mapper;
            _filmeRepository = filmeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var fillmes = await _filmeRepository.ListarFilmes();

            return Response(_mapper.Map<List<FilmeDto>>(fillmes));
        }
    }
}
