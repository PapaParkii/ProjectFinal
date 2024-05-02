using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectFinal.Models;
using System;
using System.Linq;

namespace ProjectFinal.Controllers
{
    public class PokemonsController : Controller
    {
        private PokemonContext _context;

        public PokemonsController(PokemonContext ctx)
        {
            _context = ctx;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ViewResult Add()
        {
            ViewBag.Action = "Add";
            Pokemon pokemon = new Pokemon();
            TempData["message"] =
            $"{pokemon.Name} successfully added.";
            return View("AddEdit", pokemon);
        }

        [Authorize(Roles = "Admin")]
        public ViewResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            Pokemon pokemon = _context.Pokemons.Find(id);
            TempData["message"] =
            $"{pokemon.Name} successfully edited.";
            return View("AddEdit", pokemon);
        }

        [HttpPost]
        public IActionResult AddEdit(Pokemon pokemon)
        {
            if (ModelState.IsValid)
            {
                if (pokemon.PokemonId == 0)
                {
                    _context.Pokemons.Add(pokemon);
                }
                else
                {
                    _context.Pokemons.Update(pokemon);
                }
                _context.SaveChanges();
                return RedirectToAction("Pokemon");
            }
            else
            {
                return View("AddEdit", pokemon);
            }
        }

        [Route("Pokemons")]
        public ViewResult Pokemon(string region, string sortOrder)
        {
            ViewBag.NameSortParam = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            IQueryable<Pokemon> pokemons = _context.Pokemons;

            if (!string.IsNullOrEmpty(region))
            {
                pokemons = pokemons.Where(p => p.Region == region);
            }

            switch (sortOrder)
            {
                case "name_desc":
                    pokemons = pokemons.OrderByDescending(p => p.Name);
                    break;
                default:
                    pokemons = pokemons.OrderBy(p => p.Name);
                    break;
            }

            var pokemonList = pokemons.ToList();
            return View(pokemonList);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ViewResult Delete(int id)
        {
            var pokemons = _context.Pokemons.Find(id);
            return View(pokemons);
        }

        [HttpPost]
        public RedirectToActionResult Delete(Pokemon pokemons)
        {
            _context.Pokemons.Remove(pokemons);
            _context.SaveChanges();
            TempData["message"] =
    $"{pokemons.Name} successfully deleted.";
            return RedirectToAction("Pokemon", "Pokemons");
        }
    }
}