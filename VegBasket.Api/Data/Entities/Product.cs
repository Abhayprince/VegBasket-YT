using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using VegBasket.Shared.Dtos;

namespace VegBasket.Api.Data.Entities;

/// <summary>
/// Fruit/Vegetable Table
/// </summary>
public class Product
{
    [Key]
    public int Id { get; set; }
        
    [Required, MaxLength(100)]    
    public string Name { get; set; }

    [Required, MaxLength(200)]
    public string ImageUrl { get; set; }

    [Range(0, double.MaxValue)]
    public decimal Price { get; set; }

    [Required, MaxLength(15)]
    public string Unit { get; set; }

    public ProductDto ToDto() =>
        new ()
        {
            Id = Id,
            Name = Name,
            ImageUrl = ImageUrl,
            Price = Price,
            Unit = Unit
        };

    private const string ImageUrlPrefix = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/main/Vegetables/";
    public static Product[] GetSeedData() =>
        [
            new () { Id = 1, Name = "Avocado", ImageUrl = $"{ImageUrlPrefix}avocado.png", Unit = "each", Price = 1.99m },
            
        ];
}
