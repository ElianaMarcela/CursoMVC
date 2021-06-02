using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CursoMVC.Models.Users
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Cédula")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "En el campo Cédula, solo esta permitido ingresar números")]
        public string Login { get; set; }


        [Required]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage = "La contraseña debe contener almenos 5 caracteres")]
        public string  Password { get; set; }
    }
}