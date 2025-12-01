using AutoMapper;
using Fiap.Web.InclusivaJobs.Models;
using Fiap.Web.InclusivaJobs.ViewModels;
using InclusivaJobs.ViewModels;

namespace Fiap.Web.InclusivaJobs.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<VagaCadastroViewModel, Vaga>();
			CreateMap<Vaga, VagaExibicaoViewModel>();
		}
	}
}