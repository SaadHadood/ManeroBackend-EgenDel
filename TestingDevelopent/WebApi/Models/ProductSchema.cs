﻿using System.ComponentModel.DataAnnotations;

namespace ManeroProject.Models
{
    public class ProductSchema
    {
        [Required]
        public string Name { get; set; } = null!;
        public string? SupplierArticleNumber { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }

        [Required]
        public string CategoryName { get; set; } = null!;
    }
}
