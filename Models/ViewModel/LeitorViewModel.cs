using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaEmprestimos.Models.ViewModel
{
    public class LeitorViewModel
    {

        public string Nome { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public int Telefone { get; set; }
        public string Email { get; set; } = string.Empty;
    }
}