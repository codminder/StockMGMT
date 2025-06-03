using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models;

public class Product
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required decimal Price { get; set; }
    public required int Stock { get; set; }
    public int? DiscountPercentage { get; set; }
    [NotMapped]
    public decimal CalculateDiscounted => DiscountPercentage.HasValue ? Price * (1 - (DiscountPercentage.Value / 100m)) : Price;
}