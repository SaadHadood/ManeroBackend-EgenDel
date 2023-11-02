using System.ComponentModel.DataAnnotations;

namespace WebApi.Models;

public class CategorySchema
{
    [Required]
    public string Name { get; set; } = null!;
}
