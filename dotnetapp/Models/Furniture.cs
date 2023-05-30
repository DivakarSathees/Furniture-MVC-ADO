using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
    public class Furniture
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Product is required")]
        public string Product { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        public string Material { get; set; }

        public string Dimensions { get; set; }

        // [Range(typeof(decimal), "0", "79228162514264337593543950335", ErrorMessage = "Price must be a non-negative value")]
        public decimal Price { get; set; }
    }
}
