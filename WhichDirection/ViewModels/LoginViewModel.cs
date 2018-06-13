using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WhichDirection.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "必填项")]
        public string LoginName { get; set; }
        [Required(ErrorMessage = "必填项")]
        public string Password { get; set; }
    }
}