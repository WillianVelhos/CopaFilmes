using CopaFilmes.Domain.Model;
using CopaFilmes.Domain.Service;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CopaFilmes.Infra.Data.Service
{
    public class FilmeService : IFilmeRepository
    {
        private readonly HttpClient _httpClient;

        public FilmeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Filme>> ListarFilmes()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"/api/filmes");

            HttpResponseMessage response = await _httpClient.SendAsync(request);
            string responseBody = await response.Content.ReadAsStringAsync();

            var filmes = JsonConvert.DeserializeObject<List<Filme>>(responseBody);

            return filmes;
        }
    }
}
