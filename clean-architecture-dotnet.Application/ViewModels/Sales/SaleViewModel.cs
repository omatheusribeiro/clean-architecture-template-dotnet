using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace clean_architecture_dotnet.Application.ViewModels.Sales
{
    public class SaleViewModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "It is necessary to enter the total value.")]
        [JsonPropertyName("totalValue")]
        public decimal TotalValue { get; set; }

        [Required(ErrorMessage = "It is necessary to enter the user id.")]
        [JsonPropertyName("userId")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "It is necessary to provide the product id.")]
        [JsonPropertyName("productId")]
        public int ProductId { get; set; }
    }
}
