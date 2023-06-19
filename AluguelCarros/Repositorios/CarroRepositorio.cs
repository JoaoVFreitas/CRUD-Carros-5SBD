using AluguelCarros.Data;
using AluguelCarros.Models;

namespace AluguelCarros.Repositorios
{
    public class CarroRepositorio : ICarroRepositorio
    {
        private readonly BancoContext _bancoContext;

        public CarroRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public CarroModel ListarPorId(int id)
        {
            return _bancoContext.Carros.FirstOrDefault(x => x.Id == id);
        }

        public List<CarroModel> BuscarTodos()
        {
            return _bancoContext.Carros.ToList();
        }

        public CarroModel Adicionar(CarroModel carro)
        {
            _bancoContext.Carros.Add(carro);
            _bancoContext.SaveChanges();
            return carro;
        }

        public CarroModel Atualizar(CarroModel carro)
        {
            CarroModel carroDB = ListarPorId(carro.Id);

            if (carroDB == null) throw new Exception("Houve um erro na atualização dos dados do carro.");

            carroDB.Marca = carro.Marca;
            carroDB.Modelo = carro.Modelo;
            carroDB.Ano = carro.Ano;
            carroDB.Diaria = carro.Diaria;
            carroDB.Placa = carro.Placa;

            _bancoContext.Carros.Update(carroDB);
            _bancoContext.SaveChanges();

            return carroDB;
        }

        public bool Apagar(int id)
        {
            CarroModel carroDB = ListarPorId(id);

            if (carroDB == null) throw new Exception("Houve um erro na exclusão dos dados do carro.");

            _bancoContext.Carros.Remove(carroDB);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}
