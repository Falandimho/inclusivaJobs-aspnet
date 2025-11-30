using Microsoft.AspNetCore.Mvc;
using InclusivaJobs.ViewModels;

namespace InclusivaJobs.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UsuariosController : ControllerBase
	{
		// Lista temporária em memória - depois substituímos por banco de dados
		private static List<UsuarioExibicaoViewModel> _usuarios = new()
		{
			new UsuarioExibicaoViewModel { Id = 1, Nome = "Admin", Email = "admin@inclusivajobs.com", Role = "ADMIN", Ativo = true },
			new UsuarioExibicaoViewModel { Id = 2, Nome = "Empresa Teste", Email = "empresa@teste.com", Role = "EMPRESA", Ativo = true }
		};

		[HttpGet]
		public ActionResult<IEnumerable<UsuarioExibicaoViewModel>> Get()
		{
			return Ok(_usuarios);
		}

		[HttpGet("{id}")]
		public ActionResult<UsuarioExibicaoViewModel> Get(int id)
		{
			var usuario = _usuarios.FirstOrDefault(u => u.Id == id);
			if (usuario == null)
				return NotFound(new { message = "Usuário não encontrado" });

			return Ok(usuario);
		}

		[HttpPost]
		public ActionResult<UsuarioExibicaoViewModel> Post([FromBody] UsuarioCadastroViewModel viewModel)
		{
			// Validação básica
			if (_usuarios.Any(u => u.Email == viewModel.Email))
				return BadRequest(new { message = "Email já cadastrado" });

			var novoUsuario = new UsuarioExibicaoViewModel
			{
				Id = _usuarios.Count + 1,
				Nome = viewModel.Nome,
				Email = viewModel.Email,
				Role = viewModel.Role.ToString(),
				Ativo = true,
				DataCriacao = DateTime.Now
			};

			_usuarios.Add(novoUsuario);

			return CreatedAtAction(nameof(Get), new { id = novoUsuario.Id }, novoUsuario);
		}
	}
}