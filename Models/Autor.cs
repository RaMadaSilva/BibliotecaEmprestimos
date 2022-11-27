
namespace BibliotecaEmprestimos.Models
{
    public class Autor
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public List<Livro> Livros { get; set; } = new();
    }
}