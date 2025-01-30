using System.ComponentModel.DataAnnotations;

namespace OnlineMarket.Models;

public class Product
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }

    [Required]
    public string? Description { get; set; }

    [Required]
    public decimal Price { get; set; }

    [Required]
    public string? ImagePath { get; set; }
    public int Stock { get; set; }

    // Foreign key
    [Required]
    public int CategoryId { get; set; }

    // Navigation property
    public Category? Category { get; set; }
}


