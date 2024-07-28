using System.ComponentModel.DataAnnotations;

namespace VegBasket.Api.Data.Entities;

public class User
{
    [Key]
    public int Id { get; set; }

    [Required, Length(2, 15)]
    public string Name { get; set; }

    [Required, Length(10, 100)]
    public string Email { get; set; }

    [Required, MaxLength(250)]
    public string PasswordHash { get; set; }

    [Required, Length(10, 20)]
    public string MobileNumber { get; set; }

    public virtual ICollection<Address> Addresses { get; set; }
    public virtual ICollection<Order> Orders { get; set; }
}
