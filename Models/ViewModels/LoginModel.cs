using System.ComponentModel.DataAnnotations;

namespace Market.Models.ViewModels
{
    public class LoginModel
    {
        [EmailAddress, Required, Display(Name = "Email: ")]
        public string Email { get; set; }

        [DataType(DataType.Password), Required, Display(Name = "Pasword: ")]
        public string Password { get; set; }

        [Display(Name = "Remember you? ")]
        public bool Remember { get; set; }

        public string ReturnUrl { get; set; }
    }
}
