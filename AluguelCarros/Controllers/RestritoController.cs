using AluguelCarros.Filters;
using Microsoft.AspNetCore.Mvc;

namespace AluguelCarros.Controllers
{
    [PaginaParaClienteLogado]
    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
