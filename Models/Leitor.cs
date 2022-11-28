
namespace BibliotecaEmprestimos.Models
{
    public class Leitor
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public int Telefone { get; set; }
        public string Email { get; set; } = string.Empty;
        public List<Livro> Livros { get; set; } = new();
        public List<Emprestimo> Emprestimos { get; set; } = new();
    }
}