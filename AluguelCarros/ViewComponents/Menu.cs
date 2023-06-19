using AluguelCarros.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AluguelCarros.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string sessaoCliente = HttpContext.Session.GetString("sessaoClienteLogado");

            if (string.IsNullOrWhiteSpace(sessaoCliente)) return null;

            ClienteModel cliente = JsonConvert.DeserializeObject<ClienteModel>(sessaoCliente);

            return View(cliente);
        }

    }
}