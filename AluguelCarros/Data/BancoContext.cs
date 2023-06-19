using AluguelCarros.Data.Map;
using AluguelCarros.Models;
using Microsoft.EntityFrameworkCore;

namespace AluguelCarros.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        public DbSet<CarroModel> Carros { get; set; }
        public DbSet<ClienteModel> Clientes { get; set; } 
        public DbSet<AgendamentoModel> Agendamentos { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AgendamentoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
