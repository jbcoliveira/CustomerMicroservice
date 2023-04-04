using Data.Extensions;
using System.ComponentModel.DataAnnotations;

namespace API.ViewModels
{
    public class CustomerViewModel : ICustomerViewModel
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string SurName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(255)]
        public string Password { get; set; }

        public bool Validate()
        {
            if (string.IsNullOrEmpty(FirstName))
                return false;
            
            if (string.IsNullOrEmpty(SurName))
                return false;
            
            if (string.IsNullOrEmpty(Password))
                return false;
            

            if (!Email.IsValidEmail())
                return false;

            return true;
        }
    }
}
