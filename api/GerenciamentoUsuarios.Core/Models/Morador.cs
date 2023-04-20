using System.ComponentModel.DataAnnotations;
using System;

namespace GerenciamentoUsuarios.Core.Models
{
    public class Morador : Usuario
    {
        [Required]
        [StringLength(11)]
        public string CPF { get; set; }

        public DateTime DataNascimento { get; set; }
    }
}
