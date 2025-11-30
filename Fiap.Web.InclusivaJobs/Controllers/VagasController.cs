using Microsoft.AspNetCore.Mvc;
using InclusivaJobs.ViewModels;

namespace InclusivaJobs.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class VagasController : ControllerBase
	{
		// Lista temporária em memória
		private static List<VagaExibicaoViewModel> _vagas = new()
		{
			new VagaExibicaoViewModel
			{
				Id = 1,
				Titulo = "Desenvolvedor .NET Inclusivo",
				Empresa = "Tech Company",
				Localizacao = "São Paulo/SP",
				Salario = 5000,
				OfereceAcessibilidade = true,
				VagasPCD = true,
				QuantidadeVagasPCD = 2,
				Ativa = true
			}
		};

		[HttpGet]
		public ActionResult<IEnumerable<VagaExibicaoViewModel>> Get()
		{
			return Ok(_vagas);
		}

		[HttpGet("{id}")]
		public ActionResult<VagaExibicaoViewModel> Get(int id)
		{
			var vaga = _vagas.FirstOrDefault(v => v.Id == id);
			if (vaga == null)
				return NotFound(new { message = "Vaga não encontrada" });

			return Ok(vaga);
		}

		[HttpPost]
		public ActionResult<VagaExibicaoViewModel> Post([FromBody] VagaCadastroViewModel viewModel)
		{
			var novaVaga = new VagaExibicaoViewModel
			{
				Id = _vagas.Count + 1,
				Titulo = viewModel.Titulo,
				Descricao = viewModel.Descricao,
				Empresa = viewModel.Empresa,
				Localizacao = viewModel.Localizacao,
				Salario = viewModel.Salario,
				OfereceAcessibilidade = viewModel.OfereceAcessibilidade,
				RecursosAcessibilidade = viewModel.RecursosAcessibilidade,
				VagasPCD = viewModel.VagasPCD,
				QuantidadeVagasPCD = viewModel.QuantidadeVagasPCD,
				Ativa = true,
				DataCriacao = DateTime.Now,
				DataExpiracao = viewModel.DataExpiracao
			};

			_vagas.Add(novaVaga);

			return CreatedAtAction(nameof(Get), new { id = novaVaga.Id }, novaVaga);
		}
	}
}