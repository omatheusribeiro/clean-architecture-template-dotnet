using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace clean_architecture_dotnet.Application.ViewModels.Users
{
    public class UserAddressViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "It is necessary to enter the address street.")]
        [MinLength(10)]
        [MaxLength(100)]
        [DisplayName("Street")]
        public string Street { get; set; } = string.Empty;

        [Required(ErrorMessage = "It is necessary to enter the address number.")]
        [MinLength(1)]
        [MaxLength(5)]
        [DisplayName("Number")]
        public int Number { get; set; }

        [MinLength(1)]
        [MaxLength(50)]
        [DisplayName("Complement")]
        public string Complement { get; set; } = string.Empty;

        [Required(ErrorMessage = "It is necessary to provide the address neighborhood.")]
        [MinLength(5)]
        [MaxLength(100)]
        [DisplayName("Neighborhood")]
        public string Neighborhood { get; set; } = string.Empty;

        [Required(ErrorMessage = "It is necessary to provide the address city.")]
        [MinLength(5)]
        [MaxLength(100)]
        [DisplayName("City")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "It is necessary to provide the address state.")]
        [MinLength(5)]
        [MaxLength(100)]
        [DisplayName("State")]
        public string State { get; set; } = string.Empty;

        [Required(ErrorMessage = "It is necessary to provide the address country.")]
        [MinLength(5)]
        [MaxLength(100)]
        [DisplayName("Country")]
        public string Country { get; set; } = string.Empty;

        [Required(ErrorMessage = "It is necessary to provide the address zip code.")]
        [MinLength(8)]
        [MaxLength(9)]
        [DisplayName("ZipCode")]
        public string ZipCode { get; set; } = string.Empty;
    }
}
