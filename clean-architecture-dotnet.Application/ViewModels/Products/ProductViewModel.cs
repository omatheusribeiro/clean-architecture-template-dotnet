using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace clean_architecture_dotnet.Application.ViewModels.Products
{
    public class ProductViewModel
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "It is necessary to enter the product name.")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "It is necessary to enter the product name.")]
        [MinLength(2)]
        [MaxLength(300)]
        [DisplayName("Description")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "It is necessary to provide the product value.")]
        [DisplayName("Value")]
        public decimal Value { get; set; }

        [Required(ErrorMessage = "It is necessary to provide the product type id.")]
        [DisplayName("ProductTypeId")]
        public int ProductTypeId { get; set; }
    }
}
