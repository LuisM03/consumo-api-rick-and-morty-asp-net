using Microsoft.AspNetCore.Mvc;
using rickandmorty.Models;
using rickandmorty.Services;

namespace rickandmorty.Controllers
{
    public class LocationController : Controller
    {
        private readonly RickAndMortyServices serviceApi;

        public LocationController(RickAndMortyServices serviceApi)
        {
            this.serviceApi = serviceApi;
        }

        public async Task<IActionResult> Index()
        {
            var query = 0;
            if (HttpContext.Request.Query["page"].ToString() != "")
            {
                query = int.Parse(HttpContext.Request.Query["page"].ToString());
            }
            else
            {
                query = 0;
            }


            LocationResponse response = await serviceApi.GetLocations(query);
            ViewBag.Page = query;
            ViewBag.AmountCharacters = response.info.count;

            List<Location> locations = response.results;

            return View(locations);
        }

        public async Task<IActionResult> Detail(int id)
        {
            string path = HttpContext.Request.Path;
            string[] pathSegments = path.Split('/');

            int lastSegment = int.Parse(pathSegments[pathSegments.Length - 1]);
            Location location = await serviceApi.GetLocation(lastSegment);
            ViewBag.Location = location;
            ViewBag.Residents = location.residents;
            return View();
        }
    }
}
