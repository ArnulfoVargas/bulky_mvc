using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bulky.Models.Entities;

public class Product
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    [DisplayName("Category Name")]
    public required string Title { get; set; }
    [MaxLength(300)]
    public string Description { get; set; }
    [Required]
    public required string ISBN { get; set; }
    [Required]
    public required string Author { get; set; }
    [Required]
    [DisplayName("List Price 1-50")]
    [Range(minimum: 1, maximum: 1000)]
    public decimal ListPrice { get; set; }
    
    [Required]
    [DisplayName("List Price 50+")]
    [Range(minimum: 1, maximum: 1000)]
    public decimal ListPrice50 { get; set; }
    
    [Required]
    [DisplayName("List Price 100+")]
    [Range(minimum: 1, maximum: 1000)]
    public decimal ListPrice100 { get; set; }
}