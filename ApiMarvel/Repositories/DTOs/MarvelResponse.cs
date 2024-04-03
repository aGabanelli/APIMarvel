using Newtonsoft.Json;

namespace ApiMarvel.Repositories.DTOs
{
    public class MarvelResponse
    {

    }

    // resposta da API para a busca por revistas
    public class ComicResponse
    {
        public int Code { get; set; }
        public string Status { get; set; }
        public string Copyright { get; set; }
        [JsonProperty("attributionText")]
        public string AttributionText { get; set; }
        [JsonProperty("attributionHTML")]
        public string AttributionHtml { get; set; }
        public string Etag { get; set; }
        public ComicData Data { get; set; }
    }

    // dados específicos da revista
    public class ComicData
    {
        public int Offset { get; set; }
        public int Limit { get; set; }
        public int Total { get; set; }
        public int Count { get; set; }
        public List<ComicResult> Results { get; set; }
    }

    // dados retornados pela busca
    public class ComicResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [JsonProperty("issueNumber")]
        public int IssueNumber { get; set; }
        public string Description { get; set; }
        public string Modified { get; set; }
        public List<ComicUrl> Urls { get; set; }
    }

    //url da revista
    public class ComicUrl
    {
        public string Type { get; set; }
        public string Url { get; set; }
    }

}
