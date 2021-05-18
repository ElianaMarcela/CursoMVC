using System.ComponentModel.DataAnnotations;

namespace CursoMVC.Models.Users
{
    public class RegisterViewModel
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "En el campo Nombre, solo está permitido ingresar letras" )]
        public string Nombre { get; set; }


        [Required]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "En el campo Apellido, solo está permitido ingresar letras")]
        public string Apellido { get; set; }


        [Required]
        [Display(Name = "Cédula")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "En el campo Cédula, solo esta permitido ingresar números")]
        public string Cedula { get; set; }


        [Required]
        [EmailAddress(ErrorMessage = "Correo inválido")]
        public string Email { get; set; }


        [Required]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage = "La contraseña debe contener almenos 5 caracteres")]
        public string Password { get; set; }


        [Required]
        [Display(Name = "Confirmar contraseña")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden")]
        public string ConfirmPassword { get; set; }
    }
}