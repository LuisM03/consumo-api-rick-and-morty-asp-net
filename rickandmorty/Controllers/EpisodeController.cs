using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rickandmorty.Models;
using rickandmorty.Services;

namespace rickandmorty.Controllers
{
    public class EpisodeController : Controller
    {
        private readonly RickAndMortyServices serviceApi;

        public EpisodeController(RickAndMortyServices serviceApi)
        {
            this.serviceApi = serviceApi;
        }

        // GET: EpisodeController
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


            EpisodeResponse response = await serviceApi.GetEpisodes(query);
            ViewBag.Page = query;
            ViewBag.AmountCharacters = response.info.count;

            List<Episode> episodes = response.results;
            return View(episodes);
        }

        public async Task<IActionResult> Detail(int id)
        {
            string path = HttpContext.Request.Path;
            string[] pathSegments = path.Split('/');

            int lastSegment = int.Parse(pathSegments[pathSegments.Length - 1]);
            Episode episode = await serviceApi.GetEpisode(lastSegment);
            ViewBag.Episode = episode;
            return View();
        }

        // GET: EpisodeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EpisodeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EpisodeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EpisodeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EpisodeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EpisodeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EpisodeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
