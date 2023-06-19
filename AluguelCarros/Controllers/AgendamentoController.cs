using AluguelCarros.Filters;
using AluguelCarros.Helper;
using AluguelCarros.Models;
using AluguelCarros.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace AluguelCarros.Controllers
{
    [PaginaParaClienteLogado]

    public class AgendamentoController : Controller
    {
        private readonly IAgendamentoRepositorio _agendamentoRepositorio;
        private readonly ICarroRepositorio _carroRepositorio;
        private readonly ISessao _sessao;

        public AgendamentoController(IAgendamentoRepositorio agendamentoRepositorio,
                                     ISessao sessao)
        {
            _agendamentoRepositorio = agendamentoRepositorio;
            _sessao = sessao;
        }

        public IActionResult Criar(int id)
        {
            AgendamentoModel agendamento = new AgendamentoModel();
            agendamento.CarroId = id;
            ClienteModel clienteLogado = _sessao.BuscarSessaoDoCliente();
            agendamento.ClienteId = clienteLogado.Id;

            _agendamentoRepositorio.Adicionar(agendamento);

            TempData["MensagemSucesso"] = "Agendamento cadastrado com sucesso!";
            return RedirectToAction("IndexPadrao", "Carro");
        }


        public IActionResult Index()
        {
            ClienteModel clienteLogado = _sessao.BuscarSessaoDoCliente();

            List<AgendamentoModel> agendamentos = _agendamentoRepositorio.BuscarTodos(clienteLogado.Id);

            return View();
        }
    }
}
