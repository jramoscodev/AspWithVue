using System.ComponentModel.DataAnnotations;


namespace CommonDomain.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Campo es requerido")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Campo es requerido")]
        public string Password { get; set; }
    }
}
