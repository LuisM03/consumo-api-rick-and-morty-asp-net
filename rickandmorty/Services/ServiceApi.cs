using Newtonsoft.Json;
using rickandmorty.Models;
using System.Net.Http.Headers;
using System.Text;
namespace rickandmorty.Services;

    public class ServiceApi: RickAndMortyServices
    {
        private static string baseUrl;

        public ServiceApi()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();

            baseUrl = builder.GetSection("ApiSettings:baseUrl").Value;
        }

        public async Task<Character> GetCharacter(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            Character character = new Character();
            var response = await client.GetAsync("/api/character/" + id);
            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Character>(json_respuesta);
                character = resultado;    
            }
            return character;
        }

    public async Task<Location> GetLocation(int id)
    {
        var client = new HttpClient();
        client.BaseAddress = new Uri(baseUrl);
        Location location = new Location();
        var response = await client.GetAsync("/api/location/" + id);
        if (response.IsSuccessStatusCode)
        {
            var json_respuesta = await response.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<Location>(json_respuesta);
            location = resultado;
        }
        return location;
    }

    async Task<LocationResponse> RickAndMortyServices.GetLocations(int page = 0)
    {
        var client = new HttpClient();
        client.BaseAddress = new Uri(baseUrl);
        LocationResponse response = new LocationResponse();
        var getResponse = await client.GetAsync("/api/location?page=" + page);
        if (getResponse.IsSuccessStatusCode)
        {
            var json_respuesta = await getResponse.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<LocationResponse>(json_respuesta);
            response = resultado;
        }
        return response;
    }

    async Task<CharactersResponse> RickAndMortyServices.GetCharacters(int page = 0)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            CharactersResponse response = new CharactersResponse();
            var getResponse = await client.GetAsync("/api/character/?page="+page);
            if (getResponse.IsSuccessStatusCode)
            {
                var json_respuesta = await getResponse.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<CharactersResponse>(json_respuesta);
                response = resultado;
            }
            return response;
        }

    async Task<EpisodeResponse> RickAndMortyServices.GetEpisodes(int page = 0)
    {
        var client = new HttpClient();
        client.BaseAddress = new Uri(baseUrl);
        EpisodeResponse response = new EpisodeResponse();
        var getResponse = await client.GetAsync("/api/episode?page=" + page);
        if (getResponse.IsSuccessStatusCode)
        {
            var json_respuesta = await getResponse.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<EpisodeResponse>(json_respuesta);
            response = resultado;
        }
        return response;
    }

    public async  Task<Episode> GetEpisode(int id)
    {
        var client = new HttpClient();
        client.BaseAddress = new Uri(baseUrl);
        Episode episode = new Episode();
        var response = await client.GetAsync("/api/episode/" + id);
        if (response.IsSuccessStatusCode)
        {
            var json_respuesta = await response.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<Episode>(json_respuesta);
            episode = resultado;
        }
        return episode;
    }
}