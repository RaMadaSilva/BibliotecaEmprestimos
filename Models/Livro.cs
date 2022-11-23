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
        public List<Autor> Autores { get; set; }
    }

}