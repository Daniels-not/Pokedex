using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using Pokedex.Models;
using System.Diagnostics;

namespace Pokedex.Controllers
{
    public class TipoController : Controller
    {

        private readonly PokemonServices _services;

        public TipoController(PokemonContext pokedata)
        {
            _services = new(pokedata);
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Application.Models.PokemonTipo> data = await _services.GetPokemonTypes();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Application.Models.SavePokemonType type)
        {
            if (ModelState.IsValid)
            {
                await _services.CreatePokemonType(type);
                return RedirectToAction("Index");
            }

            return View();

        }
        public async Task<IActionResult> Update(int id)
        {
            var data = await _services.GetPokemonTypeById(id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Application.Models.SavePokemonType type)
        {
            if (ModelState.IsValid)
            {
                await _services.UpdatePokemonType(type);
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var data = await _services.GetPokemonTypeById(id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (ModelState.IsValid)
            {
                await _services.DeletePokemonType(id);
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