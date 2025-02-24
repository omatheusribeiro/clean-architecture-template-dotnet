using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace clean_architecture_dotnet.Application.ViewModels.Sales
{
    public class SaleViewModel
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "It is necessary to enter the total value.")]
        [DisplayName("TotalValue")]
        public decimal TotalValue { get; set; }

        [Required(ErrorMessage = "It is necessary to enter the user id.")]
        [DisplayName("UserId")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "It is necessary to provide the product id.")]
        [DisplayName("ProductId")]
        public int ProductId { get; set; }
    }
}
