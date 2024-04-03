using ApiMarvel.Repositories.DTOs;
using ApiMarvel.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApiMarvel.Pages
{
    //herança
    public class CharacterModel : PageModel 
    {
        //criação das variáveis
        private readonly ILogger<CharacterModel> _logger;
        private readonly MarvelRepository _marvelRepository;
        public List<CharacterResult> Characters = new List<CharacterResult>();
        
        //Construtor
        public CharacterModel(ILogger<CharacterModel> logger)
        {
            _logger = logger;
            _marvelRepository = new MarvelRepository();

        }

        //criação do método para obter a lista de personagens pelo ID da revista
        public async Task OnGetAsync(int comicId)
        {
            // criação de variável para receber o ID da revista
            var characterData = await _marvelRepository.GetCharacterByComicAsync(comicId);

            // limpeza da lista
            Characters.Clear();

            // loop para preencher a lista de personagens com todos os personagens obtidos
            foreach (var character in characterData.Data.Results)
            {
                Characters.Add(character);
            }
        }
    }

}
