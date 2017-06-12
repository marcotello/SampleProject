using SampleProject.CustomModelValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleProject.Models
{
    public class EmployeeViewModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(10)]
        [Display(Name = "Name")]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string PasswordConfirmation { get; set; }

        [Range(18, 70)]
        public int Age { get; set; }

        [ValidDate]
        public DateTime RetireDate { get; set; }
    }
}
