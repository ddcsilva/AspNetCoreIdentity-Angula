using System.ComponentModel.DataAnnotations;
using System;

namespace GerenciamentoUsuarios.API.Models
{
    public class Morador : Usuario
    {
        [Required(ErrorMessage = "A data de entrada é obrigatória.")]
        public DateTime DataEntrada { get; set; }

        public DateTime? DataSaida { get; set; }
    }
}
