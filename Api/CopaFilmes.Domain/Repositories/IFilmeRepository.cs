using CopaFilmes.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaFilmes.Domain.Service
{
    public interface IFilmeRepository
    {
        Task<List<Filme>> ListarFilmes();
    }
}
