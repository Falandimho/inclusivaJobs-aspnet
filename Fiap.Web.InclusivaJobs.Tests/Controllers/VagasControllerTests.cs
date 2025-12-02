using Fiap.Web.InclusivaJobs.Controllers;
using Fiap.Web.InclusivaJobs.Services;
using Fiap.Web.InclusivaJobs.ViewModels;
using InclusivaJobs.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Fiap.Web.InclusivaJobs.Tests.Controllers
{
	public class VagasControllerTests
	{
		private readonly Mock<IVagaService> _mockService;
		private readonly VagasController _controller;

		public VagasControllerTests()
		{
			_mockService = new Mock<IVagaService>();
			_controller = new VagasController(_mockService.Object);
		}

		[Fact]
		public async Task Get_ReturnsHttpStatusCode200()
		{
			// Arrange
			_mockService.Setup(s => s.GetAllAsync())
				.ReturnsAsync(new List<VagaExibicaoViewModel>());

			// Act
			var result = await _controller.Get();

			// Assert
			var actionResult = Assert.IsType<ActionResult<IEnumerable<VagaExibicaoViewModel>>>(result);
			var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
			Assert.Equal(200, okResult.StatusCode);
		}

		[Fact]
		public async Task GetById_ExistingId_ReturnsHttpStatusCode200()
		{
			// Arrange
			var vaga = new VagaExibicaoViewModel
			{
				Id = 1,
				Titulo = "Desenvolvedor .NET Inclusivo",
				Empresa = "Tech Company"
			};

			_mockService.Setup(s => s.GetByIdAsync(1))
				.ReturnsAsync(vaga);

			// Act
			var result = await _controller.Get(1);

			// Assert
			var actionResult = Assert.IsType<ActionResult<VagaExibicaoViewModel>>(result);
			var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
			Assert.Equal(200, okResult.StatusCode);
		}

		[Fact]
		public async Task GetById_NonExistingId_ReturnsHttpStatusCode404()
		{
			// Arrange
			_mockService.Setup(s => s.GetByIdAsync(999))
				.ReturnsAsync((VagaExibicaoViewModel)null);

			// Act
			var result = await _controller.Get(999);

			// Assert
			var actionResult = Assert.IsType<ActionResult<VagaExibicaoViewModel>>(result);
			var notFoundResult = Assert.IsType<NotFoundObjectResult>(actionResult.Result);
			Assert.Equal(404, notFoundResult.StatusCode);
		}

		[Fact]
		public async Task Post_ValidVaga_ReturnsHttpStatusCode201()
		{
			// Arrange
			var viewModel = new VagaCadastroViewModel
			{
				Titulo = "Nova Vaga Inclusiva",
				Empresa = "Empresa Teste",
				VagasPCD = true,
				QuantidadeVagasPCD = 2,
				DataExpiracao = DateTime.UtcNow.AddDays(30)
			};

			var vagaCriada = new VagaExibicaoViewModel
			{
				Id = 1,
				Titulo = "Nova Vaga Inclusiva",
				VagasPCD = true,
				QuantidadeVagasPCD = 2
			};

			_mockService.Setup(s => s.CreateAsync(viewModel))
				.ReturnsAsync(vagaCriada);

			// Act
			var result = await _controller.Post(viewModel);

			// Assert
			var actionResult = Assert.IsType<ActionResult<VagaExibicaoViewModel>>(result);
			var createdResult = Assert.IsType<CreatedAtActionResult>(actionResult.Result);
			Assert.Equal(201, createdResult.StatusCode);
		}
	}
}