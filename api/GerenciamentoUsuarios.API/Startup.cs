using GerenciamentoUsuarios.API.Services;
using GerenciamentoUsuarios.Core.Contexts;
using GerenciamentoUsuarios.Core.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace GerenciamentoUsuarios.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Configurar os serviços necessários para a aplicação
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            // Adicionar o JwtService como um serviço com escopo
            services.AddScoped<JwtService>();

            // Configurar o DbContext
            services.AddDbContext<DefaultContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Configurar o Identity
            services.AddIdentity<Usuario, Funcao>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<DefaultContext>();

            // Configurar a autenticação JWT
            var configuracoesJWT = Configuration.GetSection("JwtSettings");
            string secret = configuracoesJWT.GetValue<string>("Secret");
            string issuer = configuracoesJWT.GetValue<string>("Issuer");
            string audience = configuracoesJWT.GetValue<string>("Audience");

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = issuer,
                        ValidAudience = audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret))
                    };
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GerenciamentoUsuarios.API", Version = "v1" });
            });
        }

        // Configurar o pipeline de solicitação
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GerenciamentoUsuarios.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
