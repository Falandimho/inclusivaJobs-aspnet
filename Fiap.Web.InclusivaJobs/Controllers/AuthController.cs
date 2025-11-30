// Controllers/AuthController.cs
using Microsoft.AspNetCore.Mvc;
using InclusivaJobs.Application.ViewModels;

namespace InclusivaJobs.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AuthController : ControllerBase
	{
		public AuthController()
		{
		}

		[HttpPost("login")]
		public async Task<ActionResult<dynamic>> Login([FromBody] LoginViewModel loginViewModel)
		{
			// Implementação temporária - vamos melhorar depois
			if (loginViewModel.Email == "admin@inclusivajobs.com" && loginViewModel.Senha == "123456")
			{
				return Ok(new
				{
					token = "token_temporario",
					tipo = "Bearer",
					expiraEm = DateTime.Now.AddHours(8)
				});
			}

			return Unauthorized(new { message = "Email ou senha inválidos" });
		}
	}
}