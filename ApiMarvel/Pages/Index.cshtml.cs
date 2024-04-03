using ApiMarvel.Repositories;
using ApiMarvel.Repositories.DTOs;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApiMarvel.Pages
{
    public class IndexModel : PageModel
    {
        //cria��o das vari�veis
        private readonly ILogger<IndexModel> _logger;
        private readonly MarvelRepository _marvelRepository;
        public List<ComicResult> Comics = new List<ComicResult>();
        
        // construtor
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            _marvelRepository = new MarvelRepository();
        }

        //m�todo de busca por todas as revistas, de acordo com o SearchInput
        public async Task OnGetAsync(string searchInput)
        {
            //busca de acordo com o SearchInput
            if (!string.IsNullOrWhiteSpace(searchInput))
            {

                // capturar todas as revistar e armazenar na vari�vel comicsData
                var comicsData = await _marvelRepository.GetComicsByTitleAsync(searchInput);
                Console.WriteLine(comicsData);

                // limpeza da lista
                Comics.Clear();

                //la�o para adicionar cada quadrinho a lista
                foreach (ComicResult comic in comicsData.Data.Results)
                {
                    Comics.Add(comic);
                }
            }
        }
    }
}
