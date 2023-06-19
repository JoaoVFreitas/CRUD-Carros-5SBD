using AluguelCarros.Filters;
using AluguelCarros.Models;
using AluguelCarros.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace AluguelCarros.Controllers
{
    [PaginaParaClienteLogado]

    public class CarroController : Controller
    {
        private readonly ICarroRepositorio _carroRepositorio;

        public CarroController(ICarroRepositorio carroRepositorio)
        {
            _carroRepositorio = carroRepositorio;
        }

        public IActionResult Index()
        {
            List<CarroModel> carros = _carroRepositorio.BuscarTodos();

            return View(carros);
        }

        public IActionResult IndexPadrao()
        {
            List<CarroModel> carros = _carroRepositorio.BuscarTodos();

            return View(carros);
        }

        [PaginaRestritaSomenteAdmin]

        public IActionResult Criar()
        {
            return View();
        }

        [PaginaRestritaSomenteAdmin]

        public IActionResult Editar(int id)
        {
            CarroModel carro = _carroRepositorio.ListarPorId(id);
            return View(carro);
        }

        [PaginaRestritaSomenteAdmin]

        public IActionResult ApagarConfirmacao(int id)
        {
            CarroModel carro = _carroRepositorio.ListarPorId(id);
            return View(carro);
        }

        [PaginaRestritaSomenteAdmin]

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _carroRepositorio.Apagar(id);

                if (apagado) 
                {
                    TempData["MensagemSucesso"] = "Carro excluido com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Não foi possivel excluir o carro, tente novamente.";
                }

                TempData["MensagemSucesso"] = "Carro excluido com sucesso!";
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possivel excluir o carro, tente novamente. Detalhes do Erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [PaginaRestritaSomenteAdmin]

        [HttpPost]
        public IActionResult Criar(CarroModel carro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _carroRepositorio.Adicionar(carro);
                    TempData["MensagemSucesso"] = "Carro cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(carro);
            }
            catch (System.Exception erro) 
            {
                TempData["MensagemErro"] = $"Não foi possivel cadastrar o carro, tente novamente. Detalhes do Erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [PaginaRestritaSomenteAdmin]

        [HttpPost]
        public IActionResult Editar(CarroModel carro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    carro = _carroRepositorio.Atualizar(carro);
                    TempData["MensagemSucesso"] = "Dados do carro atualizado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(carro);
            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Não foi possivel alterar os dados do carro, tente novamente. Detalhes do Erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
