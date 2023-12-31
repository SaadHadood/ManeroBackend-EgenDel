﻿using ManeroProject.Models;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models;

public class Category
{
    [Key]
    public int CategoryId { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    public List<Product> Products { get; set; } = new List<Product>();
}
