using gerenciamento_de_livraria.Data;
using gerenciamento_de_livraria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace gerenciamento_de_livraria.Controllers
{
    public class LivroController : Controller
    {
       
        private readonly AppDbContext _context;
        
       
        public LivroController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        
        public async Task<IActionResult> Index()
        {
            var livros = await _context.Livro.ToListAsync();

            return View(livros);
        }


        [HttpGet]
        public IActionResult CriarLivro()
        {

            return View();
        }



        [HttpPost]
        public async Task<IActionResult> CriarLivro(LivroModel livro)
        {
            if (ModelState.IsValid) { 
            
               await _context.Livro.AddAsync(livro);
               await _context.SaveChangesAsync();
               return RedirectToAction("Index");
            }

            return View(livro);
        }

       
        [HttpGet]
        public async Task<IActionResult> EditarLivro(int id)
        {
            var livro = await _context.Livro.FindAsync(id);
            
            if(livro == null)
            {
                return NotFound();

            }

            return View(livro);
        }

        
        [HttpPost]
        public async Task<IActionResult> EditarLivro(LivroModel livro)
        {

            if (ModelState.IsValid)
            {
                _context.Livro.Update(livro);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
               
            return View(livro);

        }


        [HttpGet]
        public async Task<IActionResult> ExcluirLivro(int id)
        {

            var livro = await _context.Livro.FindAsync(id);

            if(livro == null)
            {
                return NotFound();
            }

            return View(livro);

        }


        [HttpPost]
        public async Task<IActionResult> ExcluirLivroConfirmado(int id)
        {
            var livro = await _context.Livro.FindAsync(id);

            if (livro == null)
            {
                return NotFound(); 
            }

            _context.Livro.Remove(livro);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> DetalhesLivro(int id)
        {

            var detalhe = await _context.Livro.FindAsync(id);

            if(detalhe == null)
            {
                return NotFound();
            }

            return View(detalhe);


        }




    }
}
