using System.ComponentModel.DataAnnotations;

namespace VegBasket.Api.Data.Entities;

public class Address
{
    [Key]
    public long Id { get; set; }
    
    public int UserId { get; set; }

    [Required, Length(2, 15)]
    public string Name { get; set; }

    [Required, Length(5, 250)]
    public string AddressText { get; set; }
    public bool IsDefault { get; set; }

    public virtual User User { get; set; }
}
