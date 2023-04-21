using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace GerenciamentoUsuarios.API.Models
{
    public class Funcao : IdentityRole
    {
        [Required(ErrorMessage = "A descrição é obrigatória.")]
        [StringLength(100, ErrorMessage = "A descrição deve ter no máximo 100 caracteres.")]
        public string Descricao { get; set; }
    }
}
