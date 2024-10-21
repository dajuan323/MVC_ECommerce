using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace EcommerceMvc.Models;

public class Ingredient
{
    public int IngredientId { get; set; }
    public string? Name { get; set; } = string.Empty;
    [ValidateNever]
    public ICollection<ProductIngredient>? ProductIngredients { get; set; } = [];
}