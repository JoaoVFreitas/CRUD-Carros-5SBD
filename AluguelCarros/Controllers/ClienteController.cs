using AluguelCarros.Filters;
using AluguelCarros.Models;
using AluguelCarros.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace AluguelCarros.Controllers
{
    [PaginaRestritaSomenteAdmin]

    public class ClienteController : Controller
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteController(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        public IActionResult Index()
        {
            List<ClienteModel> clientes = _clienteRepositorio.BuscarTodos();

            return View(clientes);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            ClienteModel cliente = _clienteRepositorio.ListarPorId(id);
            return View(cliente);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            ClienteModel cliente = _clienteRepositorio.ListarPorId(id);
            return View(cliente);
        }

        [HttpPost]
        public IActionResult Criar(ClienteModel cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _clienteRepositorio.Adicionar(cliente);
                    TempData["MensagemSucesso"] = "Cliente cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(cliente);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possivel cadastrar o cliente, tente novamente. Detalhes do Erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _clienteRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Cliente excluido com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Não foi possivel excluir o cliente, tente novamente.";
                }

                TempData["MensagemSucesso"] = "Cliente excluido com sucesso!";
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possivel excluir o cliente, tente novamente. Detalhes do Erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Editar(ClienteSemSenhaModel clienteSemSenhaModel)
        {
            try
            {
                ClienteModel? cliente = null;

                if (ModelState.IsValid)
                {
                    cliente = new ClienteModel()
                    {
                        Id = clienteSemSenhaModel.Id,
                        Nome = clienteSemSenhaModel.Nome,
                        Email = clienteSemSenhaModel.Email,
                        Perfil = clienteSemSenhaModel.Perfil
                    };

                    cliente = _clienteRepositorio.Atualizar(cliente);
                    TempData["MensagemSucesso"] = "Dados do cliente atualizado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(cliente);
            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Não foi possivel alterar os dados do cliente, tente novamente. Detalhes do Erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
