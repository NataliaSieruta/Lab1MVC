using System.ComponentModel.DataAnnotations;
namespace RecipeApp.Models
{
    public class Category
    {
        public int Id { get; set; }

        
        public string Name { get; set; } = null!;

        public ICollection<Recipe> Recipes { get; set; } = null!;
    }
}