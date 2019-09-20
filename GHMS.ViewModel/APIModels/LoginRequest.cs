using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GHMS.ViewModel.APIModels
{
    public class LoginRequest
    {
        [Required]
        [Display(Name = "Hospital Code")]
        public string HospitalCode { get; set; }
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
