using Fiap.Web.InclusivaJobs.Data;
using Fiap.Web.InclusivaJobs.Data.Repository;
using Fiap.Web.InclusivaJobs.Models;
using InclusivaJobs.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.InclusivaJobs.Data.Repository
{
	public class VagaRepository : IVagaRepository
	{
		private readonly ApplicationDbContext _context;

		public VagaRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<Vaga> GetByIdAsync(int id)
		{
			return await _context.Vagas.FindAsync(id);
		}

		public async Task<IEnumerable<Vaga>> GetAllAsync()
		{
			return await _context.Vagas
				.Where(v => v.Ativa)
				.OrderByDescending(v => v.DataCriacao)
				.ToListAsync();
		}

		public async Task<(IEnumerable<Vaga> Vagas, int TotalCount)> GetVagasInclusivasAsync(int pageNumber, int pageSize)
		{
			var query = _context.Vagas
				.Where(v => v.Ativa &&
						   (v.VagasPCD || v.OfereceAcessibilidade) &&
						   v.DataExpiracao > DateTime.UtcNow)
				.OrderByDescending(v => v.DataCriacao);

			var totalCount = await query.CountAsync();
			var vagas = await query
				.Skip((pageNumber - 1) * pageSize)
				.Take(pageSize)
				.ToListAsync();

			return (vagas, totalCount);
		}

		public async Task<Vaga> AddAsync(Vaga vaga)
		{
			_context.Vagas.Add(vaga);
			await _context.SaveChangesAsync();
			return vaga;
		}

		public async Task<Vaga> UpdateAsync(Vaga vaga)
		{
			_context.Vagas.Update(vaga);
			await _context.SaveChangesAsync();
			return vaga;
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var vaga = await _context.Vagas.FindAsync(id);
			if (vaga == null) return false;

			_context.Vagas.Remove(vaga);
			await _context.SaveChangesAsync();
			return true;
		}

		public async Task<object> GetEstatisticasDiversidadeAsync()
		{
			var totalVagas = await _context.Vagas.CountAsync();
			var vagasPCD = await _context.Vagas.CountAsync(v => v.VagasPCD);
			var vagasAcessibilidade = await _context.Vagas.CountAsync(v => v.OfereceAcessibilidade);
			var vagasInclusivas = await _context.Vagas.CountAsync(v => v.VagasPCD || v.OfereceAcessibilidade);

			var empresasInclusivas = await _context.Vagas
				.Where(v => v.VagasPCD || v.OfereceAcessibilidade)
				.Select(v => v.Empresa)
				.Distinct()
				.CountAsync();

			return new
			{
				TotalVagas = totalVagas,
				VagasPCD = vagasPCD,
				VagasAcessibilidade = vagasAcessibilidade,
				VagasInclusivas = vagasInclusivas,
				PercentualInclusivo = totalVagas > 0 ? Math.Round((vagasInclusivas * 100.0 / totalVagas), 2) : 0,
				EmpresasInclusivas = empresasInclusivas,
				DataColeta = DateTime.UtcNow
			};
		}
	}
}