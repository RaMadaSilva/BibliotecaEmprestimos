
namespace BibliotecaEmprestimos.Models
{
    public class Emprestimo
    {
        public int Id { get; set; }
        public DateTime DataEprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }
        public Leitor Leitor { get; set; }
        public List<Livro> Livros { get; set; } = new();

    }
}