using Fiap.Web.InclusivaJobs.Services;
using Fiap.Web.InclusivaJobs.ViewModels;
using Fiap.Web.InclusivaJobs.Services;
using Fiap.Web.InclusivaJobs.ViewModels;
using InclusivaJobs.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.InclusivaJobs.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class VagasController : ControllerBase
	{
		private readonly IVagaService _vagaService;

		public VagasController(IVagaService vagaService)
		{
			_vagaService = vagaService;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<IEnumerable<VagaExibicaoViewModel>>> Get()
		{
			var vagas = await _vagaService.GetAllAsync();
			return Ok(vagas);
		}

		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<VagaExibicaoViewModel>> Get(int id)
		{
			var vaga = await _vagaService.GetByIdAsync(id);
			if (vaga == null)
				return NotFound(new { message = "Vaga não encontrada" });

			return Ok(vaga);
		}

		[HttpGet("inclusivas")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult> GetVagasInclusivas(
			[FromQuery] int pageNumber = 1,
			[FromQuery] int pageSize = 10)
		{
			if (pageNumber < 1) pageNumber = 1;
			if (pageSize < 1 || pageSize > 50) pageSize = 10;

			var (vagas, totalCount, currentPage, pageSizeUsed) =
				await _vagaService.GetVagasInclusivasAsync(pageNumber, pageSize);

			var response = new PaginationResponse<VagaExibicaoViewModel>(
				vagas, totalCount, currentPage, pageSizeUsed);

			return Ok(response);
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<ActionResult<VagaExibicaoViewModel>> Post([FromBody] VagaCadastroViewModel viewModel)
		{
			try
			{
				var novaVaga = await _vagaService.CreateAsync(viewModel);
				return CreatedAtAction(nameof(Get), new { id = novaVaga.Id }, novaVaga);
			}
			catch (ArgumentException ex)
			{
				return BadRequest(new { message = ex.Message });
			}
		}

		[HttpGet("estatisticas-diversidade")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult> GetEstatisticasDiversidade()
		{
			var estatisticas = await _vagaService.GetEstatisticasDiversidadeAsync();
			return Ok(estatisticas);
		}
	}
}