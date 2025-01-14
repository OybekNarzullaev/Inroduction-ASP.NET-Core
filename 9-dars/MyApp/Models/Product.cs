using System.ComponentModel.DataAnnotations;

namespace MyApp.Models;

public class Product
{
    [Required]
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string? Name { get; set; }

    [Required]
    [Range(01, 1000)]
    public decimal Price { get; set; }

    [Required]
    [StringLength(256)]
    public string? Description { get; set; }

    [Required]
    public string? ImageUrl { get; set; }
}