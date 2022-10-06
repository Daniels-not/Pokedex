using Application.Models;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using Persistence.Models;
using Pokedex.Models;
using System.Diagnostics;

namespace Pokedex.Controllers
{
    public class RegionController : Controller
    {
        private readonly PokemonServices _services;

        public RegionController(PokemonContext pokedata)
        {
            _services = new(pokedata);
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Application.Models.PokemonRegion> data = await _services.GetPokemonRegion();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Application.Models.SavePokemonRegion region)
        {
            if (ModelState.IsValid)
            {
                await _services.CreatePokemonRegion(region);
                return RedirectToAction("Index");
            }

            return View();

        }

        public async Task<IActionResult> Update(int id)
        {
            var data = await _services.GetPokemonRegionById(id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Application.Models.SavePokemonRegion region)
        {
            if (ModelState.IsValid)
            {
                await _services.UpdatePokemonRegion(region);
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var data = await _services.GetPokemonRegionById(id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (ModelState.IsValid)
            {
                await _services.DeletePokemonRegion(id);
                return RedirectToAction("Index");
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}