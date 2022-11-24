using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaEmprestimos.Models
{
    public class Pagamento
    {
        public int Id { get; set; }
        public double Montante { get; set; }
        public Emprestimo Emprestimo { get; set; }
        public List<Livro> Livros { get; set; }

    }
}