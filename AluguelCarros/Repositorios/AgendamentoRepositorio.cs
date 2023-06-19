using AluguelCarros.Data;
using AluguelCarros.Models;

namespace AluguelCarros.Repositorios
{
    public class AgendamentoRepositorio : IAgendamentoRepositorio
    {
        private readonly BancoContext _bancoContext;

        public AgendamentoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public AgendamentoModel Adicionar(AgendamentoModel agendamento)
        {
            _bancoContext.Agendamentos.Add(agendamento);
            _bancoContext.SaveChanges();
            return agendamento;
        }

        public List<AgendamentoModel> BuscarTodos(int clienteId)
        {
            return _bancoContext.Agendamentos.Where(x => x.ClienteId == clienteId).ToList();
        }

        public AgendamentoModel ListarPorId(int id)
        {
            return _bancoContext.Agendamentos.FirstOrDefault(x => x.Id == id);
        }

        public bool Apagar(int id)
        {
            AgendamentoModel agendamentoDB = ListarPorId(id);

            if (agendamentoDB == null) throw new Exception("Houve um erro na exclusão dos dados do agendamento.");

            _bancoContext.Agendamentos.Remove(agendamentoDB);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}
