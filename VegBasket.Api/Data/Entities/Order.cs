using System.ComponentModel.DataAnnotations;
using VegBasket.Api.Constants;

namespace VegBasket.Api.Data.Entities;

public class Order
{
    [Key]
    public long Id { get; set; }
    public int UserId { get; set; }

    public DateTime OrderDate { get; set; }

    [Range(1, int.MaxValue)]
    public int TotalItems { get; set; }

    public decimal TotalAmount { get; set; }

    [Required, MaxLength(20)]
    public string Status { get; set; } = nameof(OrderStatus.Placed);

    [Required, Length(5, 250)]
    public string Address { get; set; }

    [Required, Length(2, 15)]
    public string AddressName { get; set; }

    [MaxLength(250)]
    public string? Remark { get; set; }

    public virtual User User { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }
}
