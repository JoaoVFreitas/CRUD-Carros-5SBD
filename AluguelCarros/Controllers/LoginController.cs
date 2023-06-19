using AluguelCarros.Helper;
using AluguelCarros.Models;
using AluguelCarros.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace AluguelCarros.Controllers
{
    public class LoginController : Controller
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly ISessao _sessao;

        public LoginController(IClienteRepositorio clienteRepositorio,
                               ISessao sessao)
        {
            _clienteRepositorio = clienteRepositorio;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            //Se o cliente estiver logado, redirecionar para home

            if (_sessao.BuscarSessaoDoCliente() != null) return RedirectToAction("Index", "Home");

            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessaoDoCliente();

            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel) 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ClienteModel cliente = _clienteRepositorio.BuscarPorLogin(loginModel.Email);

                    if(cliente != null)
                    {
                        if (cliente.SenhaValida(loginModel.Senha))
                        {
                            _sessao.CriarSessaoDoCliente(cliente);
                            return RedirectToAction("Index", "Home");
                        }

                        TempData["MensagemErro"] = "Senha inválida. Tente novamente.";
                    }

                    TempData["MensagemErro"] = "E-mail e/ou senha inválido(s). Por favor, tente novamente.";
                }

                return View("Index");
            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Não foi possivel realizar seu login, tente novamente. Detalhes do Erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
        
        public IActionResult Criar()
        {
            return View();
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
    }
}
