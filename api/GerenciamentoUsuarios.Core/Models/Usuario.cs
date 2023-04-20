using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace GerenciamentoUsuarios.Core.Models
{
    public class Usuario : IdentityUser<int>
    {
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
    }
}
