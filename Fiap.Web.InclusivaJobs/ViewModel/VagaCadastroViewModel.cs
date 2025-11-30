using System.ComponentModel.DataAnnotations;

namespace InclusivaJobs.ViewModels
{
	public class VagaCadastroViewModel
	{
		[Required(ErrorMessage = "Título é obrigatório")]
		[StringLength(100, ErrorMessage = "Título deve ter no máximo 100 caracteres")]
		public string Titulo { get; set; } = string.Empty;

		[Required(ErrorMessage = "Descrição é obrigatória")]
		[StringLength(1000, ErrorMessage = "Descrição deve ter no máximo 1000 caracteres")]
		public string Descricao { get; set; } = string.Empty;

		[Required(ErrorMessage = "Empresa é obrigatória")]
		public string Empresa { get; set; } = string.Empty;

		public string Localizacao { get; set; } = string.Empty;

		[Range(0, double.MaxValue, ErrorMessage = "Salário deve ser positivo")]
		public decimal Salario { get; set; }

		public bool OfereceAcessibilidade { get; set; }
		public string RecursosAcessibilidade { get; set; } = string.Empty;
		public bool VagasPCD { get; set; }

		[Range(0, int.MaxValue, ErrorMessage = "Quantidade deve ser positiva")]
		public int QuantidadeVagasPCD { get; set; }

		public DateTime DataExpiracao { get; set; }
	}
}