using AspNetCoreGeneratedDocument;
using gerenciamento_de_livraria.Data;
using gerenciamento_de_livraria.Interfaces;
using gerenciamento_de_livraria.Models;
using Microsoft.EntityFrameworkCore;


namespace gerenciamento_de_livraria.Repository
{
    public class LivroRepository : ILivroRepository
    {
        private readonly AppDbContext _context;

        public LivroRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<LivroModel>> BuscarLivro()
        {
            var livros = await _context.Livro.ToListAsync();

            return livros;
        }

        public async Task CriarLivro(LivroModel livro)
        {
            await _context.Livro.AddAsync(livro);
            await _context.SaveChangesAsync();

        }

        public async Task <LivroModel> BuscarLivroId(int id)
        {
           return await _context.Livro.FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task EditarLivro(LivroModel livro)
        {
             _context.Livro.Update(livro);
             await _context.SaveChangesAsync();
        }

        public async Task ExcluirLivro(LivroModel livro)
        {
             _context.Livro.Remove(livro);
            await _context.SaveChangesAsync();

        }

    }
}
