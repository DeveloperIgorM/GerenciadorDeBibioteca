using Microsoft.EntityFrameworkCore;
using GerenciadorDeBibioteca.Models;

namespace GerenciadorDeBibioteca.Models
{
    public class BancoDeDados : DbContext
    {
        public DbSet<Faculdade> Faculdades { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=(localdb)\mssqllocaldb;Database=GerenciadorDeBiblioteca;Integrated Security=True");
        }
        public DbSet<GerenciadorDeBibioteca.Models.Livro> Livro { get; set; } = default!;
    }
}   
