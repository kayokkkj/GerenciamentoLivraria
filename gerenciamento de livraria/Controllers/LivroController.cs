using gerenciamento_de_livraria.Data;
using gerenciamento_de_livraria.Interfaces;
using gerenciamento_de_livraria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace gerenciamento_de_livraria.Controllers
{
    public class LivroController : Controller
    {

        private readonly ILivroRepository _repositorio;

        public LivroController(ILivroRepository repositorio)
        {
            _repositorio = repositorio;
        }



        [HttpGet]

        public async Task<IActionResult> Index(string buscar, string buscarAutor, decimal? precoMinimo, decimal? precoMaximo)
        {
            ViewData["buscarlivro"] = buscar;
            ViewData["precoMinimo"] = precoMinimo;
            ViewData["precoMaximo"] = precoMaximo;

           
            var livros = await _repositorio.BuscarLivro(buscar,buscarAutor, precoMinimo, precoMaximo);

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
            if (ModelState.IsValid)
            {

                await _repositorio.CriarLivro(livro);
                return RedirectToAction("Index");
            }

            return View(livro);
        }


        [HttpGet]
        public async Task<IActionResult> DetalhesLivro(int id)
        {
            var livro = await _repositorio.BuscarLivroId(id);

            if (livro == null) { return NotFound(); }
            
            return View(livro);
        }


        [HttpGet]
        public async Task<IActionResult> EditarLivro(int id)
        {
            var livroeditar = await _repositorio.BuscarLivroId(id);
            return View(livroeditar);
        }


        [HttpPost]
        public async Task<IActionResult> EditarLivro(LivroModel livro)
        {
            if (ModelState.IsValid)
            {
                await _repositorio.EditarLivro(livro);
                return RedirectToAction("Index");
            }
                return View(livro);
        }


        [HttpGet]
        public async Task<IActionResult> ExcluirLivro(int id)
        {
            var livro = await _repositorio.BuscarLivroId(id);
             if(livro == null) {  return NotFound(); }

               return View(livro);
        }

        [HttpPost]
        public async Task<IActionResult> ExcluirLivro(LivroModel livro)
        {
            if (livro != null)
            {
                await _repositorio.ExcluirLivro(livro);
               
            }

            return RedirectToAction("Index");
        }
    }
}
