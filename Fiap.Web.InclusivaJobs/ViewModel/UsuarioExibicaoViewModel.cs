namespace InclusivaJobs.ViewModels
{
	public class UsuarioExibicaoViewModel
	{
		public int Id { get; set; }
		public string Nome { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string Role { get; set; } = string.Empty;
		public bool Ativo { get; set; }
		public DateTime DataCriacao { get; set; }
	}
}