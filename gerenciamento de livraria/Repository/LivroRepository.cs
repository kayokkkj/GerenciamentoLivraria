using AspNetCoreGeneratedDocument;
using gerenciamento_de_livraria.Data;
using gerenciamento_de_livraria.Interfaces;
using gerenciamento_de_livraria.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics.Internal;


namespace gerenciamento_de_livraria.Repository
{
    public class LivroRepository : ILivroRepository
    {
        private readonly AppDbContext _context;

        public LivroRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<LivroModel>> BuscarLivro(string buscar = null, string buscarAutor = null, decimal? precoMinimo = null, decimal? precoMaximo = null)
        {
            try
            {
                var query = _context.Livro.AsQueryable();

                if (!string.IsNullOrEmpty(buscar)) {

                    query = query.Where(p => p.Nome.ToLower().Contains(buscar.ToLower()) || 
                    p.Autor.ToLower().Contains(buscar.ToLower()));
 
                }

                if (precoMinimo.HasValue)
                {
                    query = query.Where(m => m.Preco >= precoMinimo.Value);
                }

                if(precoMaximo.HasValue)
                {
                    query = query.Where(p => p.Preco <= precoMaximo.Value);
                }
                 return await query.ToListAsync();
            }

            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            } 
        }

        public async Task CriarLivro(LivroModel livro)
        {
            try
            {
                await _context.Livro.AddAsync(livro);
                await _context.SaveChangesAsync();
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task <LivroModel> BuscarLivroId(int id)
        {
            try
            {
                return await _context.Livro.FirstOrDefaultAsync(x => x.Id == id);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task EditarLivro(LivroModel livro)
        {
            try
            {
                _context.Livro.Update(livro);
                await _context.SaveChangesAsync();
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }  
        }

        public async Task ExcluirLivro(LivroModel livro)
        {
            try
            {
                _context.Livro.Remove(livro);
                await _context.SaveChangesAsync();
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           

        }

    }
}
