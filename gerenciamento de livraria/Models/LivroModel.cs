using System.ComponentModel.DataAnnotations;

namespace gerenciamento_de_livraria.Models
{
    public class LivroModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "o nome do livro é obrigatorio")]
        [MaxLength(100)]
        public string Nome { get; set; } = string.Empty;


        [Required(ErrorMessage = ("o nome do autor é obrigatorio"))]
        [MaxLength(100)]
        public string Autor { get; set; } = string.Empty;


        [Required(ErrorMessage = ("adicione uma descricão sobre o livro"))]
        [MaxLength(200)]
        public string Descricao { get; set; } = string.Empty;


        [Required(ErrorMessage = ("selecione uma categoria"))]
        public string Categoria { get; set; } = string.Empty;


        [Required(ErrorMessage = "o preço é obrigatorio")]
        [Range(0.01, 1000.0, ErrorMessage = "preço invalido")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal? Preco { get; set; }


        [Required(ErrorMessage ="o estoque é obrigatorio")]
        [Range(1, 10000, ErrorMessage ="estoque invalido")]
        public int? Estoque { get; set; }






    }
}
