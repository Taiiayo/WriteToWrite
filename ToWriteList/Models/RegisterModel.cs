using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToWriteList.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Email isn't specified")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password isn't specified")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Pass is incorrect")]
        public string ConfirmPassword { get; set; }

    }
}
