using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeBibioteca.Models
{
    public class BancoDeDados : DbContext
    {
        public DbSet<Faculdade> Faculdades { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=(localdb)\mssqllocaldb;Database=GerenciadorDeBiblioteca;Integrated security=True");
        }
    }
}   
