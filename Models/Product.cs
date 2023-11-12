using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsAndCategories.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Product name is required")]
        [Display(Name = "Name:")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Product description is required")]
        [Display(Name = "Description:")]
        //typename TEXT 
        [DataType(DataType.Text)]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Product price is required")]
        [Display(Name = "Price:")]
        public int Price { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public List<Association> Associations { get; set; } = new List<Association>();
    }
}