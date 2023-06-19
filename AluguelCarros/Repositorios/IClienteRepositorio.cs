using AluguelCarros.Models;

namespace AluguelCarros.Repositorios
{
    public interface IClienteRepositorio
    {
        ClienteModel BuscarPorLogin(string Email);
        ClienteModel ListarPorId(int id);
        List<ClienteModel> BuscarTodos();
        ClienteModel Adicionar(ClienteModel cliente);
        ClienteModel Atualizar(ClienteModel cliente);
        bool Apagar(int id);

    }
}
