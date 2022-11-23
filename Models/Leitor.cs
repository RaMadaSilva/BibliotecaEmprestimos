
namespace BibliotecaEmprestimos.Models
{
    public class Leitor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Telefone { get; set; }
        public string Email { get; set; }
    }
}