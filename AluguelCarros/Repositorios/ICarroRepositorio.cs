using AluguelCarros.Models;

namespace AluguelCarros.Repositorios
{
    public interface ICarroRepositorio
    {
        CarroModel ListarPorId(int id);
        List<CarroModel> BuscarTodos();
        CarroModel Adicionar(CarroModel carro);
        CarroModel Atualizar(CarroModel carro);
        bool Apagar(int id);

    }
}
