using rickandmorty.Models;

namespace rickandmorty.Services
{
    public interface RickAndMortyServices
    {
        Task<CharactersResponse> GetCharacters(int page = 0);
        Task<Character> GetCharacter(int id);
        Task<LocationResponse> GetLocations(int page = 0);
        Task<Location> GetLocation(int id);
        Task<EpisodeResponse> GetEpisodes(int page = 0);
        Task<Episode> GetEpisode(int id);
    }
}
