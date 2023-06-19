using AluguelCarros.Enums;
using System.ComponentModel.DataAnnotations;

namespace AluguelCarros.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do cliente.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o e-mail do cliente.")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é valido.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Selecione o tipo do perfil do cliente.")]
        public PerfilEnum? Perfil { get; set; }
        [Required(ErrorMessage = "Digite a senha do cliente.")]
        public string Senha { get; set; }

        public bool SenhaValida(string senha) 
        {
            return Senha == senha;
        }

        public virtual List<AgendamentoModel> Agendamentos { get; set;}
    }
}
