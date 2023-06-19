using AluguelCarros.Models;

namespace AluguelCarros.Repositorios
{
    public interface IAgendamentoRepositorio
    {
        AgendamentoModel ListarPorId(int id);
        List<AgendamentoModel> BuscarTodos(int clienteId);
        AgendamentoModel Adicionar(AgendamentoModel agendamento);
        bool Apagar(int id);
    }
}