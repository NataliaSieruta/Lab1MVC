using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeApp.Data;
using RecipeApp.Models;
using RecipeApp.ViewModels;

namespace RecipeApp.Controllers
{
    public class RecipesController : Controller
    {
        private readonly AppDbContext _context;

        public RecipesController(AppDbContext context)
        {
            _context = context;
        }

 
        public IActionResult Index(string searchString, int? categoryId)
        {
            var recipes = _context.Recipes
                .Include(r => r.Category)
                .Include(r => r.RecipeIngredients)
                    .ThenInclude(ri => ri.Ingredient)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                recipes = recipes.Where(r => r.Name.Contains(searchString));
            }

            if (categoryId.HasValue)
            {
                recipes = recipes.Where(r => r.CategoryId == categoryId);
            }

            return View(recipes.ToList());
        }

        public IActionResult Create()
        {
            var vm = new RecipeCreateViewModel
            {
                Categories = _context.Categories.ToList(),
                Ingredients = _context.Ingredients.ToList()
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(RecipeCreateViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Categories = _context.Categories.ToList();
                vm.Ingredients = _context.Ingredients.ToList();
                return View(vm);
            }

            var recipe = new Recipe
            {
                Name = vm.Name,
                Instructions = vm.Instructions,
                CategoryId = vm.CategoryId,
                RecipeIngredients = new List<RecipeIngredient>()
            };

            if (vm.SelectedIngredientIds != null)
            {
                for (int i = 0; i < vm.SelectedIngredientIds.Count; i++)
                {
                    var ingredientId = vm.SelectedIngredientIds[i];
                    var qty = vm.Quantities.ElementAtOrDefault(i);

                    if (ingredientId <= 0 || string.IsNullOrWhiteSpace(qty))
                        continue;

                    recipe.RecipeIngredients.Add(new RecipeIngredient
                    {
                        IngredientId = ingredientId,
                        Quantity = qty
                    });
                }
            }

            _context.Recipes.Add(recipe);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var recipe = _context.Recipes
                .Include(r => r.RecipeIngredients)
                .FirstOrDefault(r => r.Id == id);

            if (recipe == null)
                return NotFound();

            _context.RecipeIngredients.RemoveRange(recipe.RecipeIngredients);
            _context.Recipes.Remove(recipe);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}