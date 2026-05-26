using RecipeApp.Models;

namespace RecipeApp.ViewModels
{
    public class RecipeCreateViewModel
    {
        public string Name { get; set; } = null!;
        public string Instructions { get; set; } = null!;
        public int CategoryId { get; set; }

        public List<int> SelectedIngredientIds { get; set; } = new();
        public List<string> Quantities { get; set; } = new();

        public List<Ingredient> Ingredients { get; set; } = new();
        public List<Category> Categories { get; set; } = new();
    }
}