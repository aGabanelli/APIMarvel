using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ApiMarvel.Repositories.DTOs
{
    // resposta da API para uma solicitação relacionada aos personagens
    public class CharacterResponse
    {
        public int Code { get; set; }
        public string Status { get; set; }
        public string Copyright { get; set; }
        [JsonProperty("attributionText")]
        public string AttributionText { get; set; }
        [JsonProperty("attributionHTML")]
        public string AttributionHtml { get; set; }
        public string Etag { get; set; }
        public CharacterData Data { get; set; }
    }

    //Informações específicas da API
    public class CharacterData
    {
        public int Offset { get; set; }
        public int Limit { get; set; }
        public int Total { get; set; }
        public int Count { get; set; }
        public List<CharacterResult> Results { get; set; }
    }

    //Dados retornados de um perrsonagem
    public class CharacterResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Modified { get; set; }
        public Thumbnail Thumbnail { get; set; }
        public string ResourceURI { get; set; }
        public ComicList Comics { get; set; }
        public SeriesList Series { get; set; }
        public StoryList Stories { get; set; }
        public EventList Events { get; set; }
        public List<Url> Urls { get; set; }
    }

    //imagem do personagem
    public class Thumbnail
    {
        public string Path { get; set; }
        public string Extension { get; set; }
    }

    //lista de quadrinhos associado a um personagem
    public class ComicList
    {
        public int Available { get; set; }
        public string CollectionURI { get; set; }
        public List<ComicSummary> Items { get; set; }
        public int Returned { get; set; }
    }

    // resumo do quadrinho
    public class ComicSummary
    {
        public string ResourceURI { get; set; }
        public string Name { get; set; }
    }

    //lista de séries associaddas ao quadrinho
    public class SeriesList
    {
        public int Available { get; set; }
        public string CollectionURI { get; set; }
        public List<SeriesSummary> Items { get; set; }
        public int Returned { get; set; }
    }

    // resumo da série
    public class SeriesSummary
    {
        public string ResourceURI { get; set; }
        public string Name { get; set; }
    }

    //lista de histórias associadas a um personagem
    public class StoryList
    {
        public int Available { get; set; }
        public string CollectionURI { get; set; }
        public List<StorySummary> Items { get; set; }
        public int Returned { get; set; }
    }

    // resumo da história
    public class StorySummary
    {
        public string ResourceURI { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }

    //lista de eventos associados ao personagem
    public class EventList
    {
        public int Available { get; set; }
        public string CollectionURI { get; set; }
        public List<EventSummary> Items { get; set; }
        public int Returned { get; set; }
    }

    // resumo de um evento
    public class EventSummary
    {
        public string ResourceURI { get; set; }
        public string Name { get; set; }
    }

    //url associada ao personagem
    public class Url
    {
        public string Type { get; set; }
        public string UrlLink { get; set; }
    }
}
