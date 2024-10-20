namespace EcommerceMvc.Models;

public class Ingredient
{
    public int IngredientId { get; set; }
    public string? Name { get; set; } = string.Empty;
    public ICollection<ProductIngredient>? ProductIngredients { get; set; }
}