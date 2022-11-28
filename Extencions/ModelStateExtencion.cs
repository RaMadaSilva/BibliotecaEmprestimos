using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BibliotecaEmprestimos.Extencions
{
    public static class ModelStateExtencion
    {
        public static List<string> GetError(this ModelStateDictionary modelState)
        {
            var result = new List<string>();
            foreach (var item in modelState.Values)
                result.AddRange(item.Errors.Select(error => error.ErrorMessage));
            return result;
        }

    }
}