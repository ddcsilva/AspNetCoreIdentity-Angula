using System;
using System.ComponentModel.DataAnnotations;

namespace GerenciamentoUsuarios.API.Models
{
    public class Funcionario : Usuario
    {
        [Required(ErrorMessage = "A data de contratação é obrigatória.")]
        public DateTime DataContratacao { get; set; }

        public DateTime? DataDemissao { get; set; }

        [Required(ErrorMessage = "O cargo é obrigatório.")]
        [StringLength(50, ErrorMessage = "O cargo deve ter no máximo 50 caracteres.")]
        public string Cargo { get; set; }

        [Required(ErrorMessage = "É necessário informar se o usuário é um administrador.")]
        public bool IsAdministrador { get; set; }
    }
}
