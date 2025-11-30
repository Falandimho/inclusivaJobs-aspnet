namespace InclusivaJobs.ViewModels
{
	public class VagaExibicaoViewModel
	{
		public int Id { get; set; }
		public string Titulo { get; set; } = string.Empty;
		public string Descricao { get; set; } = string.Empty;
		public string Empresa { get; set; } = string.Empty;
		public string Localizacao { get; set; } = string.Empty;
		public decimal Salario { get; set; }
		public bool OfereceAcessibilidade { get; set; }
		public string RecursosAcessibilidade { get; set; } = string.Empty;
		public bool VagasPCD { get; set; }
		public int QuantidadeVagasPCD { get; set; }
		public bool Ativa { get; set; }
		public DateTime DataCriacao { get; set; }
		public DateTime DataExpiracao { get; set; }
	}
}