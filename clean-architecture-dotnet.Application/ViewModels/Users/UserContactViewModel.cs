using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace clean_architecture_dotnet.Application.ViewModels.Users
{
    public class UserContactViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "It is necessary to enter the contact email.")]
        [MinLength(5)]
        [MaxLength(20)]
        [DisplayName("Email")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "It is necessary to enter the contact phone number.")]
        [MinLength(8)]
        [MaxLength(15)]
        [DisplayName("PhoneNumber")]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
