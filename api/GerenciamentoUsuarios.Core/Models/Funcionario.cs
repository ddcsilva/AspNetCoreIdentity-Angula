using System;
using System.ComponentModel.DataAnnotations;

namespace GerenciamentoUsuarios.Core.Models
{
    public class Funcionario : Usuario
    {
        [Required]
        [StringLength(50)]
        public string Cargo { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Range(typeof(DateTime), "1900-01-01", "9999-12-31",
        ErrorMessage = "A Data de Contratação deve estar entre {1} e {2}")]
        public DateTime DataContratacao { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Range(typeof(DateTime), "1900-01-01", "9999-12-31",
        ErrorMessage = "A Data de Nascimento deve estar entre {1} e {2}")]
        public DateTime? DataDemissao { get; set; }
    }
}
