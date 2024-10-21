using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceMvc.Models;

public class Product
{
    public int ProductId { get; set; }
    public string? Name { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public int CategoryId { get; set; }
    [ValidateNever]
    public Category? Category { get; set; }
    [NotMapped]
    public IFormFile? ImageFile { get; set; }
    [DataType(DataType.Url)]
    public string? ImageUrl { get; set; } = "https://via.placeholder.com/150";
    [ValidateNever]
    public ICollection<OrderItem>? OrderItems { get; set; } = [];
    [ValidateNever]
    public ICollection<ProductIngredient>? ProductIngredients { get; set; } = [];
    
}