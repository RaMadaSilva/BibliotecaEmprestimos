using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaEmprestimos.Models.ViewModel
{
    public class ResultViewModel<T>
    {
        public T Data { get; private set; }
        public List<string> Errors { get; set; } = new();

        public ResultViewModel(T data, List<string> errors)
        {
            Data = data;
            Errors = errors;
        }

        public ResultViewModel(T data)
        {
            Data = data;
        }

        public ResultViewModel(List<string> errors)
        {
            Errors = errors;
        }
        public ResultViewModel(string error)
        {
            Errors.Add(error);
        }

        public ResultViewModel(T data, string error)
        {
            Data = data;
            Errors.Add(error);
        }

    }
}