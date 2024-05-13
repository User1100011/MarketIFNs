using System.ComponentModel.DataAnnotations;

namespace Market.Models.ViewModels
{
    public class RegistrationModel
    {
        [Required, Display(Name = "Name: ")]
        public string Name { get; set; }

        [EmailAddress, Required, Display(Name = "Email: ")]
        public string Email { get; set; }

        [DataType(DataType.Password), Required, Display(Name = "Pasword: ")]
        public string Password { get; set; }



        [Phone, Display(Name = "PhoneNumber: ")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Remember you? ")]
        public bool Remember { get; set; }


        public string ReturnUrl { get; set; }
    }
}
