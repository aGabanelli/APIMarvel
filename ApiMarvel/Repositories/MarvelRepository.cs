using ApiMarvel.Repositories.DTOs;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;

namespace ApiMarvel.Repositories
{
    public class MarvelRepository
    {
        private readonly HttpClient _httpClient;

        public MarvelRepository()
        {
            _httpClient = new HttpClient();
        }

        //gerar a chave hash para acessar a API
        private string GenerateAuthQueryParams() 
        {
            var publicKey = "89e97b73bb580dab45251dde680d174c";
            var privateKey = "ff4a1c9fde247774ae20ea59f07b1ccd90eb0f3a";

            // gerar o timestamp
            var timestamp = ((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds().ToString();

            //gerar a hashMD5
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(timestamp + privateKey + publicKey);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }

                string hash = sb.ToString();
                
                // retorno da chave hashMD5
                return $"apikey={publicKey}&hash={hash}&ts={timestamp}";
            }

        }

        //capturar a revista pelo titulo
        public async Task<ComicResponse> GetComicsByTitleAsync(string title)
        {
            //pesquisar nessa url com os parâmetros da classe anterior
            string baseUrl = "https://gateway.marvel.com:443/v1/public/comics";
            string authQueryParams = GenerateAuthQueryParams();
            string url = $"{baseUrl}?{authQueryParams}&title={title}";

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            // resposta do site
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                // retorna um json convertido para o ComicResponse
                return JsonConvert.DeserializeObject<ComicResponse>(responseBody);
            }
            else
            {
                throw new Exception($"Failed to fetch data. Status code: {response.StatusCode}");
            }
        }


        // capturar o personagem de acordo com o ID da revista
        public async Task<CharacterResponse> GetCharacterByComicAsync(int id)
        {
            //pesquisar nessa url com os parâmetros da classe anterior
            string baseUrl = $"https://gateway.marvel.com:443/v1/public/comics/{id}/characters";
            string authQueryParams = GenerateAuthQueryParams();
            string url = $"{baseUrl}?{authQueryParams}";

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                // retorna um json convertido para o CharacterResponse
                return JsonConvert.DeserializeObject<CharacterResponse>(responseBody);
            }
            else
            {
                throw new Exception($"Failed to fetch data. Status code: {response.StatusCode}");
            }

        }
    }
}
