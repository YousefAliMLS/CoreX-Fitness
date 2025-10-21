using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
namespace ITI.Models
{
    public class Products
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        [StringLength(500)]
        public string Description { get; set; } = string.Empty ;
        [Required]//? nullable
        [StringLength(50)]
        public string Category { get; set; } = string.Empty;
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
        [Range(0, int.MaxValue)]
        public int stockQuantity { get; set; }

        public DateTime creationDate { get; set; } = DateTime.Now;
        public DateTime? lastUpdate { get; set; }
        
        //FK To track who created the product

        public string? createByUserId { get; set; }
        public UserApplication? createdBy { get; set; }
    }
}
