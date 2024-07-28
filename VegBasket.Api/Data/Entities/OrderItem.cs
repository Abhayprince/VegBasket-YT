using System.ComponentModel.DataAnnotations;

namespace VegBasket.Api.Data.Entities;

public class OrderItem
{
    [Key]
    public long Id { get; set; }
    public long OrderId { get; set; }

    [Required, MaxLength(100)]
    public string ProductName { get; set; }

    [Range(0, double.MaxValue)]
    public decimal Price { get; set; }

    [Range(1, 1000)]
    public int Quantity { get; set; }

    [Required, MaxLength(15)]
    public string Unit { get; set; }

    // Nullable, because product might be deleted in future,
    // or maybe vendor is not dealing with this product anymore
    public int? ProductId { get; set; }

    public virtual Order Order { get; set; }
}
