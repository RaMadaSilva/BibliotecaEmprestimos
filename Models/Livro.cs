using BibliotecaEmprestimos.Models.Enums;

namespace BibliotecaEmprestimos.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public Genero Genero { get; set; }
        public int AnoEdicao { get; set; }
        public int NumeroPag { get; set; }
        public int QuandidadeDisponivel { get; set; }
        public double PrecoUnidade { get; set; }
        public List<Autor> Autores { get; set; } = new();
        public List<Emprestimo> Emprestimos { get; set; } = new();
        public List<Leitor> Leitores { get; set; } = new();
    }

}