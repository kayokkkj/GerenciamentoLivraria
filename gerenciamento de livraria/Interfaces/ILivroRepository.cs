namespace gerenciamento_de_livraria.Interfaces;
using gerenciamento_de_livraria.Models;




public interface ILivroRepository
{
    Task<List<LivroModel>> BuscarLivro();

    Task CriarLivro(LivroModel livro);

    Task <LivroModel> BuscarLivroId(int id);
    Task EditarLivro(LivroModel Livro);
    Task ExcluirLivro(LivroModel livro);

}
