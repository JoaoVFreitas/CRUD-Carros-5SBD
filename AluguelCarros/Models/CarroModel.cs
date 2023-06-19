using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AluguelCarros.Models
{
    public class CarroModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite a marca do carro.")]
        public string? Marca { get; set; }
        [Required(ErrorMessage = "Digite o modelo do carro.")]
        public string? Modelo { get; set; }
        [Required(ErrorMessage = "Digite o ano do carro.")]
        public int? Ano { get; set; }
        [Required(ErrorMessage = "Digite a diária do carro.")]
        public double? Diaria { get; set; }
        [Required(ErrorMessage = "Digite a placa do carro.")]
        public string? Placa { get; set; }

        public virtual List<AgendamentoModel> Agendamentos { get; set; }
    }
}
