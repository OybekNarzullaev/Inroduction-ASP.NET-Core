using System.ComponentModel.DataAnnotations;

namespace MyApp.Models;

public class Product
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Product name is required.")]
    [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
    public string Name { get; set; }
    [Range(0.01, 1000, ErrorMessage = "Price must be between 0.01 and 1000.")]
    public decimal Price { get; set; }
    [DataType(DataType.Date)]
    [Display(Name = "Release Date")]
    public DateTime ReleaseDate { get; set; }
}
