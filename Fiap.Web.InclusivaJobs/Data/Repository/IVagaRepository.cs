using Fiap.Web.InclusivaJobs.Models;
using InclusivaJobs.Models;

namespace Fiap.Web.InclusivaJobs.Data.Repository
{
	public interface IVagaRepository
	{
		Task<Vaga> GetByIdAsync(int id);
		Task<IEnumerable<Vaga>> GetAllAsync();
		Task<(IEnumerable<Vaga> Vagas, int TotalCount)> GetVagasInclusivasAsync(int pageNumber, int pageSize);
		Task<Vaga> AddAsync(Vaga vaga);
		Task<Vaga> UpdateAsync(Vaga vaga);
		Task<bool> DeleteAsync(int id);
		Task<object> GetEstatisticasDiversidadeAsync();
	}
}