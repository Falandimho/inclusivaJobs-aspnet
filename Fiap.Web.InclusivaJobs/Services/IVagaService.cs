using Fiap.Web.InclusivaJobs.ViewModels;
using InclusivaJobs.ViewModels;

namespace Fiap.Web.InclusivaJobs.Services
{
	public interface IVagaService
	{
		Task<VagaExibicaoViewModel> GetByIdAsync(int id);
		Task<IEnumerable<VagaExibicaoViewModel>> GetAllAsync();
		Task<(IEnumerable<VagaExibicaoViewModel> Vagas, int TotalCount, int PageNumber, int PageSize)>
			GetVagasInclusivasAsync(int pageNumber, int pageSize);
		Task<VagaExibicaoViewModel> CreateAsync(VagaCadastroViewModel viewModel);
		Task<object> GetEstatisticasDiversidadeAsync();
	}
}