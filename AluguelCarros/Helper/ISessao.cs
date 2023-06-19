using AluguelCarros.Models;

namespace AluguelCarros.Helper
{
    public interface ISessao
    {
        void CriarSessaoDoCliente(ClienteModel cliente);
        void RemoverSessaoDoCliente();
        ClienteModel BuscarSessaoDoCliente();
    }
}
