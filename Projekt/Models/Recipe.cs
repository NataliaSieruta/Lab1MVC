
using System.ComponentModel.DataAnnotations;
namespace RecipeApp.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nazwa przepisu jest wymagana")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Instrukcje są wymagane")]
        public string Instructions { get; set; } = null!;

       
        public int CategoryId { get; set; }

        public Category Category { get; set; } = null!;

        public ICollection<RecipeIngredient> RecipeIngredients { get; set; } = null!;
    }
}