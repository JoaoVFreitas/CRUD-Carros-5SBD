using AluguelCarros.Enums;

namespace AluguelCarros.Models
{
    public class AgendamentoModel
    {
        public int Id { get; set;}

        public int ClienteId { get; set;}

        public int CarroId { get; set; }

        public ClienteModel Cliente { get; set;}

        public CarroModel Carro { get; set;}
    }
}
