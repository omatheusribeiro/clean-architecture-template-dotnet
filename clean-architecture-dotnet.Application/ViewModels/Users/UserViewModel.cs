using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace clean_architecture_dotnet.Application.ViewModels.Users
{
    public class UserViewModel
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "It is necessary to enter the user first name.")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("FirstName")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "It is necessary to enter the user second name.")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("LastName")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "It is necessary to provide the user document.")]
        [MinLength(11)]
        [MaxLength(18)]
        [DisplayName("Document")]
        public string Document { get; set; } = string.Empty;

        [DisplayName("Address")]
        public UserAddressViewModel Address { get; set; } = new UserAddressViewModel();

        [DisplayName("Contact")]
        public UserContactViewModel Contact { get; set; } = new UserContactViewModel();
    }
}
