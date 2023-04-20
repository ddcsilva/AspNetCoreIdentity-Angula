using GerenciamentoUsuarios.API.Services;
using GerenciamentoUsuarios.API.ViewModels;
using GerenciamentoUsuarios.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GerenciamentoUsuarios.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        // UserManager ajuda a gerenciar os usuários do Identity
        private readonly UserManager<Usuario> _userManager;

        // SignInManager ajuda no processo de autenticação e login do usuário
        private readonly SignInManager<Usuario> _signInManager;

        // JwtService é um serviço personalizado para gerar tokens JWT
        private readonly JwtService _jwtService;

        public AutenticacaoController(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, JwtService jwtService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtService = jwtService;
        }

        // Registrar um novo usuário
        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar([FromBody] RegistroModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new Usuario
            {
                UserName = model.UserName,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return Ok("Usuário registrado com sucesso!");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return BadRequest(ModelState);
        }

        // Autenticar e entrar no sistema
        [HttpPost("entrar")]
        public async Task<IActionResult> Entrar([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

                if (result.Succeeded)
                {
                    var token = _jwtService.GerarToken(user);
                    return Ok(new { token });
                }
            }

            ModelState.AddModelError(string.Empty, "Usuário ou senha inválidos.");
            return BadRequest(ModelState);
        }
    }
}