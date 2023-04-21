using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace GerenciamentoUsuarios.API.Models
{
    public class Usuario : IdentityUser
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [StringLength(11, ErrorMessage = "O CPF deve ter 11 caracteres.")]
        public string CPF { get; set; }
    }
}
