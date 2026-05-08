using gerenciamento_de_livraria.Models;
using Microsoft.EntityFrameworkCore;

namespace gerenciamento_de_livraria.Data
{
    public class AppDbContext : DbContext  
    {

       public AppDbContext (DbContextOptions<AppDbContext> options) : base(options){ }

        public DbSet<LivroModel> Livro { get; set; }
    }
}
