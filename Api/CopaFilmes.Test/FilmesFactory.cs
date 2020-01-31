using CopaFilmes.Domain.Model;
using System.Collections.Generic;

namespace CopaFilmes.Test
{
    public class FilmesFactory
    {
        public static List<Filme> PrimeiroOitoFilmes()
        {
            return new List<Filme>()
            {
                new Filme("tt3606756" , "Os Incríveis 2",2018,8.5m),
                new Filme("tt4881806" , "urassic World: Reino Ameaçado",2018,6.7m),
                new Filme("tt5164214" , "Oito Mulheres e um Segredo",2018,6.3m),
                new Filme("tt7784604" , "Hereditário",2018,7.8m),
                new Filme("tt4154756" , "Vingadores: Guerra Infinita",2018,8.8m),
                new Filme("tt5463162" , "Deadpool 2",2018,8.1m),
                new Filme("tt3778644" , "Han Solo: Uma História Star Wars",2018,7.2m),
                new Filme("tt3501632" , "Thor: Ragnarok",2018,7.9m)
            };
        }
    }
}
