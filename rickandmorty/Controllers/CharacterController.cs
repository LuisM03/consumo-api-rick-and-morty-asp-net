using Microsoft.AspNetCore.Mvc;
using rickandmorty.Models;
using System.Diagnostics;
using rickandmorty.Services;

namespace rickandmorty.Controllers
{
    public class CharacterController : Controller
    {
        private readonly RickAndMortyServices serviceApi;

        public CharacterController(RickAndMortyServices serviceApi)
        {
            this.serviceApi = serviceApi;
        }

        public async Task<IActionResult> Index()
        {
            var query = 0;
            if (HttpContext.Request.Query["page"].ToString() != "")
            {
                query = int.Parse(HttpContext.Request.Query["page"].ToString());
            }else
            {
                query = 0;
            }


            CharactersResponse response = await serviceApi.GetCharacters(query);
            ViewBag.Page = query;
            ViewBag.AmountCharacters = response.info.count;

            List<Character> characters = response.results;
            
            return View(characters);
        }
        
        public async Task<IActionResult> Detail(int id)
        {
            string path = HttpContext.Request.Path;
            string[] pathSegments = path.Split('/');

            int lastSegment = int.Parse(pathSegments[pathSegments.Length - 1]);
            Character character = await serviceApi.GetCharacter(lastSegment);
            ViewBag.Character = character;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}