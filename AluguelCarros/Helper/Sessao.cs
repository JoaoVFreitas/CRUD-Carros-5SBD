using AluguelCarros.Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace AluguelCarros.Helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContext;

        public Sessao(IHttpContextAccessor httpContext)
        {
            
            _httpContext = httpContext;   
        }

        public ClienteModel BuscarSessaoDoCliente()
        {
            string sessaoCliente = _httpContext.HttpContext.Session.GetString("sessaoClienteLogado");

            if (string.IsNullOrEmpty(sessaoCliente)) return null;

            return JsonConvert.DeserializeObject<ClienteModel>(sessaoCliente);
        }

        public void CriarSessaoDoCliente(ClienteModel cliente)
        {
            string valor = JsonConvert.SerializeObject(cliente);

            _httpContext.HttpContext.Session.SetString("sessaoClienteLogado", valor);
        }

        public void RemoverSessaoDoCliente()
        {
            _httpContext.HttpContext.Session.Remove("sessaoClienteLogado");
        }
    }
}
