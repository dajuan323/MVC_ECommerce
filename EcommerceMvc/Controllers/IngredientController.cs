using EcommerceMvc.Data;
using EcommerceMvc.Models;
using EcommerceMvc.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceMvc.Controllers
{
    public class IngredientController : Controller
    {
        private readonly IRepository<Ingredient> _ingredients;
        public IngredientController(ApplicationDbContext context)
        {
            _ingredients = new Repository<Ingredient>(context);
        }
        public async Task<IActionResult> Index()
        {
            return View(await _ingredients.GetAllAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await _ingredients.GetByIdAsync(id, new QueryOptions<Ingredient>() { Includes="ProductIngredients.Product"}));
        }

        // Ingredient/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ingredient, Name")] Ingredient ingredient)
        {
            if (ModelState.IsValid)
            {
                await _ingredients.AddAsync(ingredient);
                return RedirectToAction("Index");
            }
            return View(ingredient);
        }

        // Ingredient/Delete
        public async Task<IActionResult> Delete(int id)
        {
            return View(await _ingredients.GetByIdAsync(id, new QueryOptions<Ingredient> { Includes = "ProductIngredients.Product"}));
        }
    }
}
