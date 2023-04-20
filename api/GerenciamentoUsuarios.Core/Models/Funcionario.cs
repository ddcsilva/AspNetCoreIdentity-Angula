using System;
using System.ComponentModel.DataAnnotations;

namespace GerenciamentoUsuarios.Core.Models
{
    public class Funcionario : Usuario
    {
        [Required]
        [StringLength(50)]
        public string Cargo { get; set; }

        public DateTime DataContratacao { get; set; }

        public DateTime? DataDemissao { get; set; }
    }
}
