using System.ComponentModel.DataAnnotations;

namespace AluguelCarros.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Digite o e-mail.")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é valido.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite a senha.")]
        public string Senha { get; set; }

    }
}
