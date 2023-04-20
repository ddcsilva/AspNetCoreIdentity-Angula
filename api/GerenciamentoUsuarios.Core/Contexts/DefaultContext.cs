using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoUsuarios.Core.Contexts
{
    public class DefaultContext : IdentityDbContext<Usuario, Funcao, int>
    {
        public DefaultContext(DbContextOptions<DefaultContext> options) : base (options)
        {
        }

        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Morador> Moradores { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
