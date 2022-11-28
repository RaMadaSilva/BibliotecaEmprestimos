using System.ComponentModel.DataAnnotations;

namespace BibliotecaEmprestimos.Models.ViewModel
{
    public class LeitorViewModel
    {

        [Required(ErrorMessage = "O Nome do Leitor é Obrigatorio")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "A Data de nascimento do Leitor é Obrigatorio")]
        public DateTime DataNascimento { get; set; }
        public int Telefone { get; set; }

        [EmailAddress(ErrorMessage = "O referido email é invalido!")]
        public string Email { get; set; } = string.Empty;
    }
}
