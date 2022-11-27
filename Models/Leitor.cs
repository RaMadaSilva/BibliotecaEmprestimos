
namespace BibliotecaEmprestimos.Models
{
    public class Leitor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Telefone { get; set; }
        public string Email { get; set; }
        public List<Livro> Livros { get; set; } = new();
        public List<Emprestimo> Emprestimos { get; set; } = new();

        public Leitor(string nome, DateTime datanascimento, int telefone, string email)
        {
            Nome = nome;
            DataNascimento = datanascimento;
            Telefone = telefone;
            Email = email;
        }
    }
}