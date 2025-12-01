using AutoMapper;
using Fiap.Web.InclusivaJobs.Data.Repository;
using Fiap.Web.InclusivaJobs.Models;
using Fiap.Web.InclusivaJobs.ViewModels;
using InclusivaJobs.ViewModels;

namespace Fiap.Web.InclusivaJobs.Services
{
	public class VagaService : IVagaService
	{
		private readonly IVagaRepository _vagaRepository;
		private readonly IMapper _mapper;

		public VagaService(IVagaRepository vagaRepository, IMapper mapper)
		{
			_vagaRepository = vagaRepository;
			_mapper = mapper;
		}

		public async Task<VagaExibicaoViewModel> GetByIdAsync(int id)
		{
			var vaga = await _vagaRepository.GetByIdAsync(id);
			return _mapper.Map<VagaExibicaoViewModel>(vaga);
		}

		public async Task<IEnumerable<VagaExibicaoViewModel>> GetAllAsync()
		{
			var vagas = await _vagaRepository.GetAllAsync();
			return _mapper.Map<IEnumerable<VagaExibicaoViewModel>>(vagas);
		}

		public async Task<(IEnumerable<VagaExibicaoViewModel> Vagas, int TotalCount, int PageNumber, int PageSize)>
			GetVagasInclusivasAsync(int pageNumber, int pageSize)
		{
			var (vagas, totalCount) = await _vagaRepository.GetVagasInclusivasAsync(pageNumber, pageSize);
			var vagasViewModel = _mapper.Map<IEnumerable<VagaExibicaoViewModel>>(vagas);

			return (vagasViewModel, totalCount, pageNumber, pageSize);
		}

		public async Task<VagaExibicaoViewModel> CreateAsync(VagaCadastroViewModel viewModel)
		{
			if (viewModel.VagasPCD && viewModel.QuantidadeVagasPCD <= 0)
			{
				throw new ArgumentException("Quantidade de vagas PCD deve ser maior que zero quando VagasPCD é true");
			}

			if (viewModel.DataExpiracao <= DateTime.UtcNow)
			{
				throw new ArgumentException("Data de expiração deve ser futura");
			}

			var vaga = _mapper.Map<Vaga>(viewModel);
			var vagaCriada = await _vagaRepository.AddAsync(vaga);
			return _mapper.Map<VagaExibicaoViewModel>(vagaCriada);
		}

		public async Task<object> GetEstatisticasDiversidadeAsync()
		{
			return await _vagaRepository.GetEstatisticasDiversidadeAsync();
		}
	}
}