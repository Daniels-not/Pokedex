using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;
using Persistence;
using Persistence.Models;
using Application.Models;
using Application.Services;

namespace Pokedex.Controllers
{
    public class PokemonController : Controller
    {
        private readonly PokemonServices _services;

        public PokemonController(PokemonContext pokedata)
        {
            _services = new(pokedata);
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<PokemonsModel> data = await _services.GetPokemon();
            return View(data);   
        }

        public async Task<IActionResult> Home()
        {
            ViewBag.Regions = await _services.GetPokemonRegion();
            ViewBag.Types = await _services.GetPokemonTypes();
            IEnumerable<PokemonsModel> data = await _services.GetPokemon();
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Home(int CategoryID, string pokemonName)
        {
            ViewBag.Regions = await _services.GetPokemonRegion();
            IEnumerable<PokemonsModel> data = await _services.GetPokemonFiltered(pokemonName, CategoryID);
            return View(data);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Regions = await _services.GetPokemonRegion();
            ViewBag.Types = await _services.GetPokemonTypes();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Application.Models.SavePokemon pokemon)
        {
            if(ModelState.IsValid)
            {
                await _services.CreatePokemon(pokemon);
                return RedirectToAction("Index");
            }

            return View();

        }

        public async Task<IActionResult> Update(int id)
        {
            ViewBag.Regions = await _services.GetPokemonRegion();
            ViewBag.Types = await _services.GetPokemonTypes();
            var data = await _services.GetPokemonById(id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Application.Models.SavePokemon pokemon)
        {
            if (ModelState.IsValid)
            {
                await _services.UpdatePokemon(pokemon);
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var data = await _services.GetPokemonById(id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (ModelState.IsValid)
            {
                await _services.DeletePokemon(id);
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}