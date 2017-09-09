using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyWebManager.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Haslo musi miec co najmniej 8 znakow", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Haslo")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potwierdz haslo")]
        [Compare("Password", ErrorMessage = "Hasla nie sa takie same!")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Imie")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }
    }
}
