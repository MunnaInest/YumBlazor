using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YumBlazor.Data
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Enter Name ?")]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string? SpecialTag { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }
        public string? ImageUrl { get; set; }
    }
}
